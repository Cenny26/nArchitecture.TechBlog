using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.DataAccess.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("2EF9CDDA-913E-4E51-A905-54CBB8EB75C5"),
                RoleId = Guid.Parse("2F673FE9-4AD1-493C-AB04-B3619397DEB5")
            }, new AppUserRole
            {
                UserId = Guid.Parse("8BFA84A0-7E9E-44CB-B703-9A817212EAEE"),
                RoleId = Guid.Parse("62C7C6FD-01D6-4410-9E4A-53490B59A3C7")
            });
        }
    }
}