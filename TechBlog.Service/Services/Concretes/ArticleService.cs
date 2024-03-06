using AutoMapper;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entites;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {
        var userId = Guid.Parse("2EF9CDDA-913E-4E51-A905-54CBB8EB75C5");
        var imageId = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB");
        var article = new Article(articleAddDto.Title, articleAddDto.Content, articleAddDto.CategoryId, imageId, userId);

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

    public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
        
        article.Title = articleUpdateDto.Title;
        article.Content = articleUpdateDto.Content;
        article.CategoryId = articleUpdateDto.CategoryId;

        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();
    }

    public async Task SafeDeleteArticleAsync(Guid articleId)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

        article.IsDeleted = true;
        article.DeletedTime = DateTime.Now;

        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();
    }
}