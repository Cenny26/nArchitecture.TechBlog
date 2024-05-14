using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entities
{
    public class ArticleVisitor : IEntityBase
    {
        public ArticleVisitor() { }
        public ArticleVisitor(Guid articleId, int visitorId)
        {
            ArticleId = articleId;
            VisitorId = visitorId;
        }

        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
