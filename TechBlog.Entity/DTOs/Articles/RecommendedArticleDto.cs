namespace TechBlog.Entity.DTOs.Articles
{
    public class RecommendedArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
