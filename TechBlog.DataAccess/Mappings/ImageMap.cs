using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.DataAccess.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image()
            {
                Id = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB"),
                FileName = "default-user.png",
                FileType = "image/png",
                CreatedBy = "Admin",
                IsDeleted = false
            });
        }
    }
}