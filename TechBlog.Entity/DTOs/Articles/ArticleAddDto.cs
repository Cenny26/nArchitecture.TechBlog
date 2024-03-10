using Microsoft.AspNetCore.Http;
using TechBlog.Entity.DTOs.Categories;

namespace TechBlog.Entity.DTOs.Articles
{
    public class ArticleAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile Photo { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
