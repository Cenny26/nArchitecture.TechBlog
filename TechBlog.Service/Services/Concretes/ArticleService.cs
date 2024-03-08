using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entites;
using TechBlog.Service.Extensions;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Service.Services.Concretes;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _accessor;
    private readonly ClaimsPrincipal _user;

    public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor Accessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accessor = Accessor;
        _user = _accessor.HttpContext.User;
    }

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {
        var userId = _user.GetLoggedInUserId();
        var userEmail = _user.GetLoggedInEmail();
        var imageId = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB");
        var article = new Article(articleAddDto.Title, articleAddDto.Content, articleAddDto.CategoryId, imageId, userId, userEmail);

        await _unitOfWork.GetRepository<Article>().AddAsync(article);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
    {
        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
        var map = _mapper.Map<List<ArticleDto>>(articles);
        return map;
    }

    public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category);
        var map = _mapper.Map<ArticleDto>(article);
        return map;
    }

    public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        var userEmail = _user.GetLoggedInEmail();

        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);

        article.Title = articleUpdateDto.Title;
        article.Content = articleUpdateDto.Content;
        article.CategoryId = articleUpdateDto.CategoryId;
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