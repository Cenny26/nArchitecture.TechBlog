using TechBlog.Entity.Entites;

namespace TechBlog.Service.Services.Abstractions;

public interface IArticleService
{
    Task<List<Article>> GetAllArticleAsync();
}