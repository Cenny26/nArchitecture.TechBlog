using TechBlog.Entity.DTOs.Articles;

namespace TechBlog.Service.Services.Abstractions;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllArticleAsync();
}