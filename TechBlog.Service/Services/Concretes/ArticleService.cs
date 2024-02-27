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

    public async Task<List<ArticleDto>> GetAllArticleAsync()
    {
        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync();
        var map = _mapper.Map<List<ArticleDto>>(articles);
        return map;
    }
}