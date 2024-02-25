using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.Entites;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArticleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Article>> GetAllArticleAsync()
    {
        return await _unitOfWork.GetRepository<Article>().GetAllAsync();
    }
}