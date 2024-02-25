﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DALExtensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bedd6acc-dae5-40e7-b645-634c4ae40c89"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ef71c28c-d1f9-4916-8a2a-314bba8aba1e"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("7b1868a0-d8c3-49e2-ac16-26def8346713"), new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"), "ASP.NET Core is a cross-platform framework for building modern web applications. Developed by Microsoft, it provides developers with a powerful set of tools for creating scalable and high-performance web applications. ASP.NET Core is built on top of the .NET Core runtime, offering improved performance and flexibility compared to its predecessor. It supports various programming languages, including C#, F#, and Visual Basic, allowing developers to choose the language they are most comfortable with. ASP.NET Core follows a modular and lightweight architecture, enabling developers to optimize their applications for different deployment scenarios. With features like dependency injection, middleware pipeline, and built-in security mechanisms, ASP.NET Core simplifies the development process and promotes best practices in web development. Overall, ASP.NET Core is a modern and versatile framework for building next-generation web applications.", "Admin", new DateTime(2024, 2, 25, 19, 1, 34, 697, DateTimeKind.Local).AddTicks(2951), null, null, new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"), false, null, null, "ASP.NET Core test blog", 10 },
                    { new Guid("f4d660e2-ee69-4263-9c11-ea3220729128"), new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"), "C# is a powerful programming language developed by Microsoft. It is widely used for building various types of applications, including desktop, web, and mobile apps. C# is known for its simplicity and ease of use, making it a popular choice among developers. It offers strong typing, object-oriented programming features, and support for modern programming paradigms. With C#, developers can write efficient and maintainable code for their projects. The language is continuously evolving, with new features and improvements being introduced regularly. Overall, C# is a fundamental tool for software development in the Microsoft ecosystem.", "Admin", new DateTime(2024, 2, 25, 19, 1, 34, 697, DateTimeKind.Local).AddTicks(2959), null, null, new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"), false, null, null, "C# test blog", 25 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 19, 1, 34, 697, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 19, 1, 34, 697, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 19, 1, 34, 697, DateTimeKind.Local).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 19, 1, 34, 697, DateTimeKind.Local).AddTicks(5727));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7b1868a0-d8c3-49e2-ac16-26def8346713"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f4d660e2-ee69-4263-9c11-ea3220729128"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("bedd6acc-dae5-40e7-b645-634c4ae40c89"), new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"), "ASP.NET Core is a cross-platform framework for building modern web applications. Developed by Microsoft, it provides developers with a powerful set of tools for creating scalable and high-performance web applications. ASP.NET Core is built on top of the .NET Core runtime, offering improved performance and flexibility compared to its predecessor. It supports various programming languages, including C#, F#, and Visual Basic, allowing developers to choose the language they are most comfortable with. ASP.NET Core follows a modular and lightweight architecture, enabling developers to optimize their applications for different deployment scenarios. With features like dependency injection, middleware pipeline, and built-in security mechanisms, ASP.NET Core simplifies the development process and promotes best practices in web development. Overall, ASP.NET Core is a modern and versatile framework for building next-generation web applications.", "Admin", new DateTime(2024, 2, 25, 14, 14, 17, 683, DateTimeKind.Local).AddTicks(9533), null, null, new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"), false, null, null, "ASP.NET Core test blog", 10 },
                    { new Guid("ef71c28c-d1f9-4916-8a2a-314bba8aba1e"), new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"), "C# is a powerful programming language developed by Microsoft. It is widely used for building various types of applications, including desktop, web, and mobile apps. C# is known for its simplicity and ease of use, making it a popular choice among developers. It offers strong typing, object-oriented programming features, and support for modern programming paradigms. With C#, developers can write efficient and maintainable code for their projects. The language is continuously evolving, with new features and improvements being introduced regularly. Overall, C# is a fundamental tool for software development in the Microsoft ecosystem.", "Admin", new DateTime(2024, 2, 25, 14, 14, 17, 683, DateTimeKind.Local).AddTicks(9540), null, null, new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"), false, null, null, "C# test blog", 25 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 14, 17, 684, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 14, 17, 684, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 14, 17, 684, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 14, 17, 684, DateTimeKind.Local).AddTicks(2262));
        }
    }
}
