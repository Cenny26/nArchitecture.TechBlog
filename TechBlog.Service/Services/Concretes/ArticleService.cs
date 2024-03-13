using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entites;
using TechBlog.Entity.Enums;
using TechBlog.Service.Extensions;
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
    private readonly ClaimsPrincipal _user;

    public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor Accessor, IImageHelper imageHelper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accessor = Accessor;
        _imageHelper = imageHelper;
        _user = _accessor.HttpContext.User;
    }

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {
        var userId = _user.GetLoggedInUserId();
        var userEmail = _user.GetLoggedInEmail();

        var imageUpload = await _imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
        Image image = new Image(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);

        await _unitOfWork.GetRepository<Image>().AddAsync(image); 

        var article = new Article(articleAddDto.Title, articleAddDto.Content, articleAddDto.CategoryId, image.Id, userId, userEmail);

        await _unitOfWork.GetRepository<Article>().AddAsync(article);
        await _unitOfWork.SaveAsync(); // Both of image and article entities
    }

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
    {
        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
        var map = _mapper.Map<List<ArticleDto>>(articles);

        return map;
    }

    public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image);
        var map = _mapper.Map<ArticleDto>(article);

        return map;
    }

    public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
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
        return article.Title;
    }

    public async Task<string> SafeDeleteArticleAsync(Guid articleId)
    {
        var userEmail = _user.GetLoggedInEmail();

        var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

        article.IsDeleted = true;
        article.DeletedTime = DateTime.Now;
        article.DeletedBy = userEmail;

        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();

        // The delete notification need to deleting article's title to showing its content on screen:
        return article.Title;
    }
}