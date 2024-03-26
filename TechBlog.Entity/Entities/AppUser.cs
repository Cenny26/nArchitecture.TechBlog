using Microsoft.AspNetCore.Identity;
using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entites;

public class AppUser : IdentityUser<Guid>, IEntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ImageId { get; set; } = Guid.Parse("b4a97b95-d0da-4d56-8a9c-ed43ccae72e7");
    public Image Image { get; set; }
    public ICollection<Article> Articles { get; set; }
}