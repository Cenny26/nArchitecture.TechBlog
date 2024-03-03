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
        var article = new Article()
        {
            Title = articleAddDto.Title,
            Content = articleAddDto.Content,
            CategoryId = articleAddDto.CategoryId,
            UserId = userId
        };

        await _unitOfWork.GetRepository<Article>().AddAsync(article);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
    {
        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
        var map = _mapper.Map<List<ArticleDto>>(articles);
        return map;
    }
}