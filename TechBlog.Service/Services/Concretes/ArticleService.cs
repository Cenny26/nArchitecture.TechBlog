using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entities;
using TechBlog.Service.Bases;
using TechBlog.Service.Extensions;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Service.Services.Abstractions.Storage;

#nullable disable

namespace TechBlog.Service.Services.Concretes
{
    public class ArticleService : BaseHandler, IArticleService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<ArticleService> _logger;
        private readonly ClaimsPrincipal _user;
        private readonly IStorage _localStorage;
        public ArticleService(IUnitOfWork _unitOfWork, IMapper _mapper, IHttpContextAccessor accessor, ILogger<ArticleService> logger, IStorage storage) : base(_unitOfWork, _mapper)
        {
            _localStorage = storage;
            _accessor = accessor;
            _logger = logger;
            _user = _accessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("CreateArticleAsync", "called"));

            try
            {
                Guid userId = _user.GetLoggedInUserId();
                string userEmail = _user.GetLoggedInEmail();

                // note: in the current situation there should be only 1 photo/image for a article
                FormFileCollection articlePhoto = new FormFileCollection();
                articlePhoto.Add(articleAddDto.Photo);

                // done: refactoring was carried out with IStorage, UploadAsync method
                List<(string fileName, string pathOrContainerName)> fileDatas = await _localStorage.UploadAsync(FileInfoConsts.FullyArticleImageDirWithoutHostEnv, articlePhoto);

                Image image = new Image(fileDatas.FirstOrDefault().fileName, articleAddDto.Photo.ContentType, userEmail);

                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                var article = new Article(articleAddDto.Title, articleAddDto.Content, articleAddDto.CategoryId, image.Id, userId, userEmail);

                await _unitOfWork.GetRepository<Article>().AddAsync(article);
                await _unitOfWork.SaveAsync(); // Both of image and article entities

                _logger.LogDebug(FormatLogMessages.EventDebug("CreateArticleAsync", "completed"));
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("creating", "a new article"));
                throw;
            }
        }

        public async Task<Article> GetArticleForVisitorAsync(Guid articleId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetArticleForVisitorAsync", "called"));

            try
            {
                var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == articleId);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetArticleForVisitorAsync", "completed"));
                return article;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the article"));
                throw;
            }
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoriesNonDeletedAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllArticlesWithCategoriesNonDeletedAsync", "called"));

            try
            {
                var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
                var map = _mapper.Map<List<ArticleDto>>(articles);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllArticlesWithCategoriesNonDeletedAsync", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the non deleted articles with categories"));
                throw;
            }
        }

        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetArticleWithCategoryNonDeletedAsync", "called"));

            try
            {
                var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image, u => u.User);
                var map = _mapper.Map<ArticleDto>(article);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetArticleWithCategoryNonDeletedAsync", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the non deleted article with category"));
                throw;
            }
        }

        public async Task<List<RecommendedArticleDto>> GetRandomlyRecommendedArticlesAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetRandomRecommendedArticlesAsync", "called"));

            try
            {
                var randomCount = 3;
                var random = new Random();

                var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync();
                var randomArticles = articles.Count() >= randomCount
                                    ? articles.OrderBy(x => random.Next()).Take(randomCount)
                                    : articles;
                var map = _mapper.Map<List<RecommendedArticleDto>>(randomArticles);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetRandomRecommendedArticlesAsync", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the recommended articles"));
                throw;
            }
        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("UpdateArticleAsync", "called"));

            try
            {
                string userEmail = _user.GetLoggedInEmail();

                Article article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);
                Image articleImage = article.Image;
                Guid articleImageId = articleImage.Id;

                _mapper.Map(articleUpdateDto, article);

                // todo: in the current situation, image editing is done manually after the mapping process, this requires refactoring!
                article.ImageId = articleImageId;
                article.Image = articleImage;
                article.ModifiedDate = DateTime.Now;
                article.ModifiedBy = userEmail;

                await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await _unitOfWork.SaveAsync();

                // The update notification need to updating article's title to showing its content on screen:
                _logger.LogDebug(FormatLogMessages.EventDebug("UpdateArticleAsync", "completed"));
                return article.Title;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("updating", "the article"));
                throw;
            }
        }

        public async Task UpdateArticleViewCountForVisitorIpAddress(Article article)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("UpdateArticleViewCountForVisitorIpAddress", "called"));

            try
            {
                await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("UpdateArticleViewCountForVisitorIpAddress", "completed"));
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("updating", "the article's view count"));
                throw;
            }
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("SafeDeleteArticleAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

                article.IsDeleted = true;
                article.ModifiedBy = userEmail;
                article.ModifiedDate = DateTime.Now;
                article.DeletedTime = DateTime.Now;
                article.DeletedBy = userEmail;

                await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await _unitOfWork.SaveAsync();

                // The delete notification need to deleting article's title to showing its content on screen:
                _logger.LogDebug(FormatLogMessages.EventDebug("SafeDeleteArticleAsync", "completed"));
                return article.Title;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("safely deleting", "the article"));
                throw;
            }
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoriesDeletedAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllArticlesWithCategoriesDeletedAsync", "called"));

            try
            {
                var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
                var map = _mapper.Map<List<ArticleDto>>(articles);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllArticlesWithCategoriesDeletedAsync", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the deleted articles with categories"));
                throw;
            }
        }

        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("UndoDeleteArticleAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

                article.IsDeleted = false;
                article.ModifiedBy = userEmail;
                article.ModifiedDate = DateTime.Now;
                article.DeletedTime = null;
                article.DeletedBy = null;

                await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await _unitOfWork.SaveAsync();

                // The delete notification need to deleting article's title to showing its content on screen:
                _logger.LogDebug(FormatLogMessages.EventDebug("UndoDeleteArticleAsync", "completed"));
                return article.Title;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("undoing", "the deleted article"));
                throw;
            }
        }

        public async Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllByPagingAsync", "called"));

            try
            {
                pageSize = pageSize > 20 ? 20 : pageSize;

                var articles = categoryId == null
                        ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                        : await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted, a => a.Category, i => i.Image, u => u.User);
                var sortedArticles = isAscending
                    ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllByPagingAsync", "completed"));
                return new ArticleListDto
                {
                    Articles = sortedArticles,
                    CategoryId = categoryId == null ? null : categoryId.Value,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = articles.Count,
                    IsAscending = isAscending
                };
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the all articles by paging"));
                throw;
            }
        }

        public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("SearchAsync", "called"));

            try
            {
                pageSize = pageSize > 20 ? 20 : pageSize;

                var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)), a => a.Category, i => i.Image, u => u.User);

                var sortedArticles = isAscending
                    ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                _logger.LogDebug(FormatLogMessages.EventDebug("SearchAsync", "completed"));
                return new ArticleListDto
                {
                    Articles = sortedArticles,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = articles.Count,
                    IsAscending = isAscending
                };
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the searched article"));
                throw;
            }
        }
    }
}