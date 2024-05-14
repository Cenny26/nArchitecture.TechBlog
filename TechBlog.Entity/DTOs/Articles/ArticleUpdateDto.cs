using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entities;

namespace TechBlog.Entity.DTOs.Articles
{
    public class ArticleUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        #region NoteForImageProperty
        // note: it's not possible to add a image for the article in the project's current situation
        #endregion
        public Image? Image { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }
}
