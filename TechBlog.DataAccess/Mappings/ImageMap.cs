using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.DataAccess.Mappings;

public class ImageMap : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasData(new Image()
        {
            Id = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB"),
            FileName = "images/test/meaninuser",
            FileType = "png",
            CreatedBy = "Admin",
            IsDeleted = false
        }, new Image()
        {
            Id = Guid.Parse("ADB79C2D-B859-4EE6-ACFA-8A81BF83FD68"),
            FileName = "images/test/meanoutuser",
            FileType = "png",
            CreatedBy = "Admin",
            IsDeleted = false
        }, new Image()
        {
            Id = Guid.Parse("3EB72197-9048-4826-AD10-CBCA7094A4D1"),
            FileName = "images/test/meanproduct",
            FileType = "jpg",
            CreatedBy = "Admin",
            IsDeleted = false
        });
    }
}