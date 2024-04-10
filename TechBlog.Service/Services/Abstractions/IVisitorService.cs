using TechBlog.Entity.Entities;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.Services.Abstractions
{
    public interface IVisitorService
    {
        Task<List<Visitor>> GetAllVisitorsAsync();
        Task<Visitor> GetVisitorAsync(string ipAddress);
        Task<List<ArticleVisitor>> GetAllArticleVisitorsAsync();
        Task CreateVisitorAsync(Visitor visitor);
        Task CreateArticleVisitorAsync(ArticleVisitor addArticleVisitor);
    }
}
