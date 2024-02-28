using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entites;

public class Category : EntityBase
{
    public string Name { get; set; }
    public ICollection<Article> Articles { get; set; }
}