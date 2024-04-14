using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.DataAccess.Mappings
{
    public class SocialMediaAccountMap : IEntityTypeConfiguration<SocialMediaAccount>
    {
        public void Configure(EntityTypeBuilder<SocialMediaAccount> builder)
        {
            builder.HasKey(x => x.Id);

            var linkedinAcc = new SocialMediaAccount()
            {
                Id = Guid.NewGuid(),
                MediaName = "linkedin",
                NormalizedMediaName = "LINKEDIN",
                MediaLink = "https://www.linkedin.com/in/Kennans26",
                CreatedBy = "superadmin@gmail.com",
                CreatedDate = DateTime.Now
            };
            var githubAcc = new SocialMediaAccount()
            {
                Id = Guid.NewGuid(),
                MediaName = "github",
                NormalizedMediaName = "GITHUB",
                MediaLink = "https://www.github.com/Cenny26",
                CreatedBy = "superadmin@gmail.com",
                CreatedDate = DateTime.Now
            };
            var instagramAcc = new SocialMediaAccount()
            {
                Id = Guid.NewGuid(),
                MediaName = "instagram",
                NormalizedMediaName = "INSTAGRAM",
                MediaLink = "https://www.instagram.com/Kennans26",
                CreatedBy = "superadmin@gmail.com",
                CreatedDate = DateTime.Now
            };

            builder.HasData(linkedinAcc, githubAcc, instagramAcc);
        }
    }
}
