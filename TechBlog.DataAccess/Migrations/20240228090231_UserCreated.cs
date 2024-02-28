using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7b1868a0-d8c3-49e2-ac16-26def8346713"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f4d660e2-ee69-4263-9c11-ea3220729128"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("9905f041-d2cc-4620-8bb1-ff17393ef662"), new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"), "ASP.NET Core is a cross-platform framework for building modern web applications. Developed by Microsoft, it provides developers with a powerful set of tools for creating scalable and high-performance web applications. ASP.NET Core is built on top of the .NET Core runtime, offering improved performance and flexibility compared to its predecessor. It supports various programming languages, including C#, F#, and Visual Basic, allowing developers to choose the language they are most comfortable with. ASP.NET Core follows a modular and lightweight architecture, enabling developers to optimize their applications for different deployment scenarios. With features like dependency injection, middleware pipeline, and built-in security mechanisms, ASP.NET Core simplifies the development process and promotes best practices in web development. Overall, ASP.NET Core is a modern and versatile framework for building next-generation web applications.", "Admin", new DateTime(2024, 2, 28, 13, 2, 30, 470, DateTimeKind.Local).AddTicks(5846), null, null, new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"), false, null, null, "ASP.NET Core test blog", 10 },
                    { new Guid("de8439cd-abae-4b59-a661-782cbf2edd07"), new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"), "C# is a powerful programming language developed by Microsoft. It is widely used for building various types of applications, including desktop, web, and mobile apps. C# is known for its simplicity and ease of use, making it a popular choice among developers. It offers strong typing, object-oriented programming features, and support for modern programming paradigms. With C#, developers can write efficient and maintainable code for their projects. The language is continuously evolving, with new features and improvements being introduced regularly. Overall, C# is a fundamental tool for software development in the Microsoft ecosystem.", "Admin", new DateTime(2024, 2, 28, 13, 2, 30, 470, DateTimeKind.Local).AddTicks(5865), null, null, new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"), false, null, null, "C# test blog", 25 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"), "9bfc189b-6131-4a10-ae08-fc65e07af6ad", "Superadmin", "SUPERADMIN" },
                    { new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"), "50a6811e-25ef-4c14-983a-4c5708c6dc8a", "Admin", "ADMIN" },
                    { new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"), "c1b468a4-d579-4f94-8278-bdebd1e4a02d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"), 0, "8163646d-8811-404a-bc14-8aea1ce0487c", "superadmin@gmail.com", true, "Kanan", "Huseynov", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKWZCb8WUoMx5FaeloL2eXBmcKt11ePmr3NLTNaKWBvB4Unv+cY6kYjsxWUhKy2HfQ==", "+994515268342", true, "c7080444-c846-4a18-b360-855c78fd9d2a", false, "superadmin@gmail.com" },
                    { new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"), 0, "76709b3a-63db-4e9c-8cb8-b104c3d29ae4", "admin@gmail.com", true, "Kanan", "Huseynov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKraGtpj3yKEUIUGu+r0xytEcIGevf8B/CaBRj7Kq4cP1Xh6Ocek8cOWynqbgbMO7Q==", "+994515268342", false, "94c12aa8-9b16-4752-b1c5-f2440f069f55", false, "admin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11e3fba7-16ed-4a07-9cef-bdc1f03f3e04"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 13, 2, 30, 470, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dc5c1e7e-74f3-4475-b766-a0c7d9381d25"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 13, 2, 30, 470, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 13, 2, 30, 470, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 13, 2, 30, 470, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"), new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5") },
                    { new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"), new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9905f041-d2cc-4620-8bb1-ff17393ef662"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("de8439cd-abae-4b59-a661-782cbf2edd07"));

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
    }
}
