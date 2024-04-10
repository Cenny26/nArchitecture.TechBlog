using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.DataAccess.Mappings;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // builder.Property(x => x.Title).HasMaxLength(150);   
        builder.HasData(new Article()
        {
            Id = Guid.NewGuid(),
            Title = "ASP.NET Core test blog",
            Content = "ASP.NET Core is a cross-platform framework for building modern web applications. Developed by Microsoft, it provides developers with a powerful set of tools for creating scalable and high-performance web applications. ASP.NET Core is built on top of the .NET Core runtime, offering improved performance and flexibility compared to its predecessor. It supports various programming languages, including C#, F#, and Visual Basic, allowing developers to choose the language they are most comfortable with. ASP.NET Core follows a modular and lightweight architecture, enabling developers to optimize their applications for different deployment scenarios. With features like dependency injection, middleware pipeline, and built-in security mechanisms, ASP.NET Core simplifies the development process and promotes best practices in web development. Overall, ASP.NET Core is a modern and versatile framework for building next-generation web applications.",
            ViewCount = 10,
            CategoryId = Guid.Parse("DC5C1E7E-74F3-4475-B766-A0C7D9381D25"),
            ImageId = Guid.Parse("A8CB5130-8EBB-429B-A048-1C70B90212FB"),
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = Guid.Parse("2EF9CDDA-913E-4E51-A905-54CBB8EB75C5")
        }, new Article()
        {
            Id = Guid.NewGuid(),
            Title = "C# test blog",
            Content = "C# is a powerful programming language developed by Microsoft. It is widely used for building various types of applications, including desktop, web, and mobile apps. C# is known for its simplicity and ease of use, making it a popular choice among developers. It offers strong typing, object-oriented programming features, and support for modern programming paradigms. With C#, developers can write efficient and maintainable code for their projects. The language is continuously evolving, with new features and improvements being introduced regularly. Overall, C# is a fundamental tool for software development in the Microsoft ecosystem.",
            ViewCount = 25,
            CategoryId = Guid.Parse("11E3FBA7-16ED-4A07-9CEF-BDC1F03F3E04"),
            ImageId = Guid.Parse("3EB72197-9048-4826-AD10-CBCA7094A4D1"),
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = Guid.Parse("8BFA84A0-7E9E-44CB-B703-9A817212EAEE")
        });
    }
}