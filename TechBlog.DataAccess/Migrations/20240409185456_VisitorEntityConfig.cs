using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class VisitorEntityConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a44b42f6-6fcf-43c6-8a11-cbda403753a5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bbc4e44c-1577-463f-8523-b1cfddf0606a"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("4b2d98ff-3659-4b4e-9cd1-50c689f06ad2"), new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"), "ASP.NET Core is a cross-platform framework for building modern web applications. Developed by Microsoft, it provides developers with a powerful set of tools for creating scalable and high-performance web applications. ASP.NET Core is built on top of the .NET Core runtime, offering improved performance and flexibility compared to its predecessor. It supports various programming languages, including C#, F#, and Visual Basic, allowing developers to choose the language they are most comfortable with. ASP.NET Core follows a modular and lightweight architecture, enabling developers to optimize their applications for different deployment scenarios. With features like dependency injection, middleware pipeline, and built-in security mechanisms, ASP.NET Core simplifies the development process and promotes best practices in web development. Overall, ASP.NET Core is a modern and versatile framework for building next-generation web applications.", "Admin", new DateTime(2024, 4, 9, 22, 54, 54, 819, DateTimeKind.Local).AddTicks(7549), null, null, new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"), false, null, null, "ASP.NET Core test blog", new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"), 10 },
                    { new Guid("d53bdc9d-c131-4f1c-b4f2-3c8c44e6164f"), new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"), "C# is a powerful programming language developed by Microsoft. It is widely used for building various types of applications, including desktop, web, and mobile apps. C# is known for its simplicity and ease of use, making it a popular choice among developers. It offers strong typing, object-oriented programming features, and support for modern programming paradigms. With C#, developers can write efficient and maintainable code for their projects. The language is continuously evolving, with new features and improvements being introduced regularly. Overall, C# is a fundamental tool for software development in the Microsoft ecosystem.", "Admin", new DateTime(2024, 4, 9, 22, 54, 54, 819, DateTimeKind.Local).AddTicks(7582), null, null, new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"), false, null, null, "C# test blog", new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"), 25 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"),
                column: "ConcurrencyStamp",
                value: "9f8e09ea-952b-481c-8f9c-f5a6d9cf8cb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"),
                column: "ConcurrencyStamp",
                value: "e37b29c2-c9f1-40de-a584-19548ca8eef5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"),
                column: "ConcurrencyStamp",
                value: "690ac33c-476b-4ced-aee0-3593ad92c00b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13d02ca2-8fb1-41bb-a4f0-9c32a0723147", "AQAAAAIAAYagAAAAELCbzG3BwBWFR/2O0dxAgO0GcQ06Tmk8ww9IBBqjwpGtKr8dNN7PhVqyjTphi3MAWw==", "96d288b4-ef66-4e5b-9da7-d2fc95896b10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8cba7d9-0a11-49a7-bc42-1dde8a5fccf0", "AQAAAAIAAYagAAAAEKbu813werf6muxbl7JW48MTBLft/xKAIDDB8mzTX0Xtdy30qQP+i1lbm4NGDZMO/Q==", "8f4e8fad-4bc2-4aaf-997a-22c776939b6a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 9, 22, 54, 54, 820, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 9, 22, 54, 54, 820, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 9, 22, 54, 54, 820, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 9, 22, 54, 54, 820, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("adb79c2d-b859-4ee6-acfa-8a81bf83fd68"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 9, 22, 54, 54, 820, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4b2d98ff-3659-4b4e-9cd1-50c689f06ad2"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d53bdc9d-c131-4f1c-b4f2-3c8c44e6164f"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("a44b42f6-6fcf-43c6-8a11-cbda403753a5"), new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"), "ASP.NET Core is a cross-platform framework for building modern web applications. Developed by Microsoft, it provides developers with a powerful set of tools for creating scalable and high-performance web applications. ASP.NET Core is built on top of the .NET Core runtime, offering improved performance and flexibility compared to its predecessor. It supports various programming languages, including C#, F#, and Visual Basic, allowing developers to choose the language they are most comfortable with. ASP.NET Core follows a modular and lightweight architecture, enabling developers to optimize their applications for different deployment scenarios. With features like dependency injection, middleware pipeline, and built-in security mechanisms, ASP.NET Core simplifies the development process and promotes best practices in web development. Overall, ASP.NET Core is a modern and versatile framework for building next-generation web applications.", "Admin", new DateTime(2024, 3, 26, 23, 26, 28, 633, DateTimeKind.Local).AddTicks(2605), null, null, new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"), false, null, null, "ASP.NET Core test blog", new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"), 10 },
                    { new Guid("bbc4e44c-1577-463f-8523-b1cfddf0606a"), new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"), "C# is a powerful programming language developed by Microsoft. It is widely used for building various types of applications, including desktop, web, and mobile apps. C# is known for its simplicity and ease of use, making it a popular choice among developers. It offers strong typing, object-oriented programming features, and support for modern programming paradigms. With C#, developers can write efficient and maintainable code for their projects. The language is continuously evolving, with new features and improvements being introduced regularly. Overall, C# is a fundamental tool for software development in the Microsoft ecosystem.", "Admin", new DateTime(2024, 3, 26, 23, 26, 28, 633, DateTimeKind.Local).AddTicks(2614), null, null, new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"), false, null, null, "C# test blog", new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"), 25 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"),
                column: "ConcurrencyStamp",
                value: "9e788b03-6aaa-4495-b827-8790e7cc8698");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"),
                column: "ConcurrencyStamp",
                value: "bd6e1ec4-89be-46f7-af55-942b331df56b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"),
                column: "ConcurrencyStamp",
                value: "0ca8921e-a996-4e28-8711-89783985a842");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05763aff-ab49-4332-bfe4-184922dee03a", "AQAAAAIAAYagAAAAEB2DOBiBI8dMz5bEs54em/eDw/yTA/ggnWG9xqnCnMEQes8oSx3rrJ29HRI5ZbKKHQ==", "1d9f8db0-73fa-4af8-98e7-f8f3379fb297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f45f0866-d090-442a-9dba-3a1f6eccfc1a", "AQAAAAIAAYagAAAAEJQA/OKqJ3PAam14E8n3uaND7MQAHTI34ihIo1PI5+GeyV6fbTL/ZnnNzCMcjJv5OA==", "f7c87ba7-b285-41b5-b75b-e0f17cf16527" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 23, 26, 28, 633, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 23, 26, 28, 633, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 23, 26, 28, 633, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 23, 26, 28, 633, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("adb79c2d-b859-4ee6-acfa-8a81bf83fd68"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 23, 26, 28, 633, DateTimeKind.Local).AddTicks(5254));
        }
    }
}
