using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entities;

namespace TechBlog.Entity.DTOs.Articles
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Image Image { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public AppUser User { get; set; }
        public string CreatedBy { get; set; }
        public int ViewCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}