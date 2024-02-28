using Microsoft.AspNetCore.Identity;

namespace TechBlog.Entity.Entites;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Guid ImageId { get; set; }
    public Image Image { get; set; }
    public ICollection<Article> Articles { get; set; }
}