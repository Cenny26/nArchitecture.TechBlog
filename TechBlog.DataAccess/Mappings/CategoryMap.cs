using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entites;

namespace TechBlog.DataAccess.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category()
        {
            Id = Guid.Parse("DC5C1E7E-74F3-4475-B766-A0C7D9381D25"),
            Name = "ASP.NET Core",
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        }, new Category()
        {
            Id = Guid.Parse("11E3FBA7-16ED-4A07-9CEF-BDC1F03F3E04"),
            Name = "C#",
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        });
    }
}