using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingSocialMediaAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMediaAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedMediaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaAccounts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"),
                column: "ConcurrencyStamp",
                value: "33f4fa6e-1da0-4dd6-abec-58b4b2daf657");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"),
                column: "ConcurrencyStamp",
                value: "93c4665e-53ce-435a-a496-54907d782004");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"),
                column: "ConcurrencyStamp",
                value: "83b65fc4-f11e-4403-85e8-9bcebbb79c42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7ae54a0-5ba2-4839-acce-bb53b7c34514", "AQAAAAIAAYagAAAAELDOzXp/lbnfhPyuleLcrmSU2ftUXCaJPZG3foQJ8oPi7scLRpboSdJGpV+t1R7vQA==", "023465ea-106a-4a98-b053-d3221c71aaf1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aa3c442-2fe7-4abf-a185-816ed58ce241", "AQAAAAIAAYagAAAAEE4Vj18eUKwwie0N4fC0wRdMGwGN5YO+9bj7Xjzwi4owaWwkg9rUS3FqYTs6ZPYWUQ==", "f8ea3e2f-39cf-4060-baf7-dfb7c470d517" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 13, 25, 40, 833, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 13, 25, 40, 833, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("adb79c2d-b859-4ee6-acfa-8a81bf83fd68"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 13, 25, 40, 833, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.InsertData(
                table: "SocialMediaAccounts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "IsDeleted", "MediaLink", "MediaName", "ModifiedBy", "ModifiedDate", "NormalizedMediaName" },
                values: new object[,]
                {
                    { new Guid("2df0aaa8-40cb-40de-a4fa-63540fe153fc"), "superadmin", new DateTime(2024, 4, 14, 13, 25, 40, 834, DateTimeKind.Local).AddTicks(4095), null, null, false, "https://www.linkedin.com/in/Kennans26", "linkedin", null, null, "LINKEDIN" },
                    { new Guid("4ec83ac3-0c40-437a-90c6-9717187d5b73"), "superadmin", new DateTime(2024, 4, 14, 13, 25, 40, 834, DateTimeKind.Local).AddTicks(4110), null, null, false, "https://www.instagram.com/Kennans26", "instagram", null, null, "INSTAGRAM" },
                    { new Guid("546dd057-c6d3-4f86-ab9a-f34db0808455"), "superadmin", new DateTime(2024, 4, 14, 13, 25, 40, 834, DateTimeKind.Local).AddTicks(4107), null, null, false, "https://www.github.com/Cenny26", "github", null, null, "GITHUB" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMediaAccounts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"),
                column: "ConcurrencyStamp",
                value: "591460c4-64ee-4472-a24e-d2a043c8399b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"),
                column: "ConcurrencyStamp",
                value: "f9fd7b63-f75e-413f-a1ab-25efba2040e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"),
                column: "ConcurrencyStamp",
                value: "4978d896-c7df-422b-a5a8-fb86febbd177");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a32b68b9-6c63-4de6-85d4-151932a9c331", "AQAAAAIAAYagAAAAEGaQ3QByvsw3iXEjVmoi3A4GrUj2aCHoMmuKd6MJxjD4LVxSouSjCI1va6/qi4k08w==", "0e97b976-9e0c-46f9-ab90-c5e934cfe509" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7113c9dc-7b93-4c7a-99dc-0bb9cb879b27", "AQAAAAIAAYagAAAAEDZq4vGjDUglTOltrzlDws3cs382kV4Z56ayZf8P7rwyczK11h9mXigf1zNrcVsB2w==", "84c1e52b-8ea9-43ab-b590-72e4265e140d" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 11, 12, 50, 50, 45, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 11, 12, 50, 50, 45, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("adb79c2d-b859-4ee6-acfa-8a81bf83fd68"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 11, 12, 50, 50, 45, DateTimeKind.Local).AddTicks(1569));
        }
    }
}
