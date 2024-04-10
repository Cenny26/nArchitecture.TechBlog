using TechBlog.Entity.Entites;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.Services.Abstractions
{
    public interface IVisitorService
    {
        Task<List<Visitor>> GetAllVisitorsAsync();
        Task<Visitor> GetVisitorAsync(string ipAddress);
        Task<List<ArticleVisitor>> GetAllArticleVisitorsAsync();
        Task<Article> GetArticleForVisitorAsync(Guid articleId);
        Task CreateVisitorAsync(Visitor visitor);
        Task UpdateArticleViewCountForVisitorIpAddress(Article article);
        Task CreateArticleVisitorAsync(ArticleVisitor addArticleVisitor);
    }
}
