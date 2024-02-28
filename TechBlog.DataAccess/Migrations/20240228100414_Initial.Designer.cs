﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechBlog.DataAccess.Context;

#nullable disable

namespace TechBlog.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240228100414_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechBlog.Entity.Entites.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"),
                            ConcurrencyStamp = "817fe947-c2a7-4b5b-851d-88da9ccfb791",
                            Name = "Superadmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"),
                            ConcurrencyStamp = "d8123cf5-6b5c-422e-8a45-22680fa982d1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"),
                            ConcurrencyStamp = "f78ec356-1cb0-4870-b492-d38539f8315b",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c85195b1-ac3c-4ea8-a7de-e4ed8cf761a9",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Kanan",
                            ImageId = new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                            LastName = "Huseynov",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAg5+NFYWmlTiwg6DUwAgDB83c9ZLdfpCZX8s0zSOubmbLEDs4lEAqkxg3SRague1w==",
                            PhoneNumber = "+994515268342",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "78dfd8d3-fec6-4763-8710-f58d6eed92d0",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "54d94caf-a3c5-4b49-b96a-8a754c125db5",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Kanan",
                            ImageId = new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                            LastName = "Huseynov",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEI+Rg5VnQwxrcfbg8XjCgSNrdvX1APWbvtvMnzhgpjD6W/zT0RpmNf3NALUo+lwhqg==",
                            PhoneNumber = "+994515268342",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "05a57a43-e906-4ff4-a007-4cfb7dcb77f6",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                            RoleId = new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5")
                        },
                        new
                        {
                            UserId = new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                            RoleId = new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7")
                        });
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a90f53fb-17b7-4b5f-9e87-94d43dda4cfe"),
                            CategoryId = new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"),
                            Content = "ASP.NET Core is a cross-platform framework for building modern web applications. Developed by Microsoft, it provides developers with a powerful set of tools for creating scalable and high-performance web applications. ASP.NET Core is built on top of the .NET Core runtime, offering improved performance and flexibility compared to its predecessor. It supports various programming languages, including C#, F#, and Visual Basic, allowing developers to choose the language they are most comfortable with. ASP.NET Core follows a modular and lightweight architecture, enabling developers to optimize their applications for different deployment scenarios. With features like dependency injection, middleware pipeline, and built-in security mechanisms, ASP.NET Core simplifies the development process and promotes best practices in web development. Overall, ASP.NET Core is a modern and versatile framework for building next-generation web applications.",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 28, 14, 4, 12, 761, DateTimeKind.Local).AddTicks(8067),
                            ImageId = new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                            IsDeleted = false,
                            Title = "ASP.NET Core test blog",
                            UserId = new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                            ViewCount = 10
                        },
                        new
                        {
                            Id = new Guid("3728c8fc-ad9e-4650-b571-14b1a2677865"),
                            CategoryId = new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"),
                            Content = "C# is a powerful programming language developed by Microsoft. It is widely used for building various types of applications, including desktop, web, and mobile apps. C# is known for its simplicity and ease of use, making it a popular choice among developers. It offers strong typing, object-oriented programming features, and support for modern programming paradigms. With C#, developers can write efficient and maintainable code for their projects. The language is continuously evolving, with new features and improvements being introduced regularly. Overall, C# is a fundamental tool for software development in the Microsoft ecosystem.",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 28, 14, 4, 12, 761, DateTimeKind.Local).AddTicks(8090),
                            ImageId = new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                            IsDeleted = false,
                            Title = "C# test blog",
                            UserId = new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                            ViewCount = 25
                        });
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 28, 14, 4, 12, 762, DateTimeKind.Local).AddTicks(835),
                            IsDeleted = false,
                            Name = "ASP.NET Core"
                        },
                        new
                        {
                            Id = new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 28, 14, 4, 12, 762, DateTimeKind.Local).AddTicks(842),
                            IsDeleted = false,
                            Name = "C#"
                        });
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 28, 14, 4, 12, 762, DateTimeKind.Local).AddTicks(2339),
                            FileName = "images/test/aspnetcore",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 28, 14, 4, 12, 762, DateTimeKind.Local).AddTicks(2348),
                            FileName = "images/test/csharp",
                            FileType = "jpg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppRoleClaim", b =>
                {
                    b.HasOne("TechBlog.Entity.Entites.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUser", b =>
                {
                    b.HasOne("TechBlog.Entity.Entites.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserClaim", b =>
                {
                    b.HasOne("TechBlog.Entity.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserLogin", b =>
                {
                    b.HasOne("TechBlog.Entity.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserRole", b =>
                {
                    b.HasOne("TechBlog.Entity.Entites.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBlog.Entity.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUserToken", b =>
                {
                    b.HasOne("TechBlog.Entity.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.Article", b =>
                {
                    b.HasOne("TechBlog.Entity.Entites.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBlog.Entity.Entites.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId");

                    b.HasOne("TechBlog.Entity.Entites.AppUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.AppUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("TechBlog.Entity.Entites.Image", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}