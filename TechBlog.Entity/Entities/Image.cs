using TechBlog.Core.Entities;
using TechBlog.Entity.Enums;

namespace TechBlog.Entity.Entites;

public class Image : EntityBase
{
    public Image()
    {
        
    }
    public Image(string fileName, string fileType, string createdBy)
    {
        FileName = fileName;
        FileType = fileType;
        CreatedBy = createdBy;
    }

    public string FileName { get; set; }
    public string FileType { get; set; }
    public ICollection<Article> Articles { get; set; }
    public ICollection<AppUser> Users { get; set; }
}