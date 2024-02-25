using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entites;

namespace TechBlog.DataAccess.Mappings;

public class ImageMap : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasData(new Image()
        {
            Id = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB"),
            FileName = "images/test/aspnetcore",
            FileType = "jpg",
            CreatedBy = "Admin",
            IsDeleted = false
        }, new Image()
        {
            Id = Guid.Parse("3EB72197-9048-4826-AD10-CBCA7094A4D1"),
            FileName = "images/test/csharp",
            FileType = "jpg",
            CreatedBy = "Admin",
            IsDeleted = false
        });
    }
}