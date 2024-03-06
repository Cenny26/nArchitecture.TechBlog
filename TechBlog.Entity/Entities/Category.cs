using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entites;

public class Category : EntityBase
{
    public Category()
    {
        
    }
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public ICollection<Article> Articles { get; set; }
}