using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entites;
using TechBlog.Entity.Enums;
using TechBlog.Service.Extensions;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Helpers.Images.Abstractions;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Service.Services.Concretes;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _accessor;
    private readonly IImageHelper _imageHelper;
    private readonly ILogger<ArticleService> _logger;
    private readonly ClaimsPrincipal _user;

    public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor, IImageHelper imageHelper, ILogger<ArticleService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accessor = accessor;
        _imageHelper = imageHelper;
        _logger = logger;
        _user = _accessor.HttpContext.User;
    }

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {
        _logger.LogDebug(FormatLogMessages.EventDebug("CreateArticleAsync", "called"));

        try
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var imageUpload = await _imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
            Image image = new Image(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);

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
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image);
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

    public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        _logger.LogDebug(FormatLogMessages.EventDebug("UpdateArticleAsync", "called"));

        try
        {
            var userEmail = _user.GetLoggedInEmail();

            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);

            if (articleUpdateDto.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);

                var imageUpload = await _imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                Image image = new Image(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);

                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;
            }

            _mapper.Map(articleUpdateDto, article);
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

    public async Task<string> SafeDeleteArticleAsync(Guid articleId)
    {
        _logger.LogDebug(FormatLogMessages.EventDebug("SafeDeleteArticleAsync", "called"));

        try
        {
            var userEmail = _user.GetLoggedInEmail();

            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
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
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = false;
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
}