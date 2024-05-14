using Microsoft.AspNetCore.Identity;
using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB");
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}