using TechBlog.Entity.DTOs.Articles;

namespace TechBlog.Service.Services.Abstractions;

public interface IArticleService
{
    Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
    Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
    Task CreateArticleAsync(ArticleAddDto articleAddDto);
    Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
    Task<string> SafeDeleteArticleAsync(Guid articleId);
}