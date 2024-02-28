using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entites;

public class Image : EntityBase
{
    public string FileName { get; set; }
    public string FileType { get; set; }
    public ICollection<Article> Articles { get; set; }
    public ICollection<AppUser> Users { get; set; }
}