using Microsoft.AspNetCore.Identity;

namespace TechBlog.Entity.Entites;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Guid ImageId { get; set; } = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB"); // Temp equality!
    public Image Image { get; set; }
    public ICollection<Article> Articles { get; set; }
}