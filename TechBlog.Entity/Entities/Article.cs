using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entities
{
    public class Article : EntityBase
    {
        public Article() { }
        public Article(string title, string content, Guid categoryId, Guid imageId, Guid userId, string createdBy)
        {
            Title = title;
            Content = content;
            CategoryId = categoryId;
            ImageId = imageId;
            UserId = userId;
            CreatedBy = createdBy;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid? ImageId { get; set; } = Guid.Parse("3EB72197-9048-4826-AD10-CBCA7094A4D1");
        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
    }
}