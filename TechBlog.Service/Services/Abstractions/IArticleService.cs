using TechBlog.Entity.DTOs.Articles;

namespace TechBlog.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task<List<ArticleDto>> GetAllArticlesWithCategoriesNonDeletedAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoriesDeletedAsync();
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
    }
}