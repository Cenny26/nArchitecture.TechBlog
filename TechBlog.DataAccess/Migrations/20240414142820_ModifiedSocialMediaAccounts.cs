using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedSocialMediaAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2193514a-e3da-481c-ad74-57ce36e51458"));

            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("739424c1-e3f8-4974-9e55-2375e50faffb"));

            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("9f5471ad-2835-41aa-9c45-98401d97b248"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"),
                column: "ConcurrencyStamp",
                value: "d50f188e-d6b2-4e75-98e0-4048cb3b4c8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"),
                column: "ConcurrencyStamp",
                value: "a73d6b76-92d3-4529-aa9d-bfc3fff17657");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"),
                column: "ConcurrencyStamp",
                value: "7fe0815e-1d25-42ef-b134-b173aa061732");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a657061-955d-4cca-9956-4d0719239c70", "AQAAAAIAAYagAAAAEKSf4l2QxlYZodkZc43kDtRtqKN2ag8tcylCMjO1RO2J42WHOZisrYB6d+xSTpB2ew==", "74ff0774-542b-4629-ae2c-7fa88b8874e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80abcbfd-297f-4725-a5b7-5c90dd54147a", "AQAAAAIAAYagAAAAEGQ2sPTmSjs9bdxbtcGTqCBq+X/38rl7bjhE5Q37Y39G0SfrHYaebL6tcrnfTj9Vyw==", "c55c6725-491f-43d0-a578-77d430c971ad" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 18, 28, 19, 123, DateTimeKind.Local).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 18, 28, 19, 123, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("adb79c2d-b859-4ee6-acfa-8a81bf83fd68"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 18, 28, 19, 123, DateTimeKind.Local).AddTicks(5795));

            migrationBuilder.InsertData(
                table: "SocialMediaAccounts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "IsDeleted", "MediaLink", "MediaName", "ModifiedBy", "ModifiedDate", "NormalizedMediaName" },
                values: new object[,]
                {
                    { new Guid("15e743b7-e62f-4615-ae4b-064d0b5b6663"), "superadmin@gmail.com", new DateTime(2024, 4, 14, 18, 28, 19, 124, DateTimeKind.Local).AddTicks(9012), null, null, false, "https://www.linkedin.com/in/Kennans26", "linkedin", null, null, "LINKEDIN" },
                    { new Guid("1db09880-537b-41a8-a736-b07e70bd64b1"), "superadmin@gmail.com", new DateTime(2024, 4, 14, 18, 28, 19, 124, DateTimeKind.Local).AddTicks(9025), null, null, false, "https://www.instagram.com/Kennans26", "instagram", null, null, "INSTAGRAM" },
                    { new Guid("686a2884-dfee-4390-aea7-fefec5ad6d64"), "superadmin@gmail.com", new DateTime(2024, 4, 14, 18, 28, 19, 124, DateTimeKind.Local).AddTicks(9016), null, null, false, "https://www.github.com/Cenny26", "github", null, null, "GITHUB" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("15e743b7-e62f-4615-ae4b-064d0b5b6663"));

            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("1db09880-537b-41a8-a736-b07e70bd64b1"));

            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("686a2884-dfee-4390-aea7-fefec5ad6d64"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f673fe9-4ad1-493c-ab04-b3619397deb5"),
                column: "ConcurrencyStamp",
                value: "644d593d-106f-48c1-b445-19dea5370d5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62c7c6fd-01d6-4410-9e4a-53490b59a3c7"),
                column: "ConcurrencyStamp",
                value: "eaf61c12-cc30-4609-8243-4a4a8192d39d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf78885c-c25e-4fa8-bc01-7b90eb93c840"),
                column: "ConcurrencyStamp",
                value: "37ff52a8-2822-40c7-be23-7ef5daa014f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef9cdda-913e-4e51-a905-54cbb8eb75c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0abeaea1-4fc3-48e1-8353-478fdc3bc3b0", "AQAAAAIAAYagAAAAEGKMeX20DV0x/6GBJQnuHM4ZE3rqj+2X2Es13pi4GMmstB7RsI1BmRGO+IT2+8aFrg==", "d0a8d2a1-ddb3-466b-9425-e357a595b1a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bfa84a0-7e9e-44cb-b703-9a817212eaee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d07209a8-32c6-4a9d-9e55-7c2c72608584", "AQAAAAIAAYagAAAAEI2oSNuFKyBVKvvNRajrrHy6UlVToihOT+3Ye4TYJyyQZYQ6zsdfUa91Cg/fa8VtWg==", "01151d81-14cb-4bc1-8f8c-c2ad225c45f7" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3eb72197-9048-4826-ad10-cbca7094a4d1"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 13, 28, 53, 746, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8cb5130-8ebb-429b-a048-1c70b90212fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 13, 28, 53, 746, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("adb79c2d-b859-4ee6-acfa-8a81bf83fd68"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 14, 13, 28, 53, 746, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.InsertData(
                table: "SocialMediaAccounts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedTime", "IsDeleted", "MediaLink", "MediaName", "ModifiedBy", "ModifiedDate", "NormalizedMediaName" },
                values: new object[,]
                {
                    { new Guid("2193514a-e3da-481c-ad74-57ce36e51458"), "superadmin@gmai.com", new DateTime(2024, 4, 14, 13, 28, 53, 748, DateTimeKind.Local).AddTicks(676), null, null, false, "https://www.instagram.com/Kennans26", "instagram", null, null, "INSTAGRAM" },
                    { new Guid("739424c1-e3f8-4974-9e55-2375e50faffb"), "superadmin@gmai.com", new DateTime(2024, 4, 14, 13, 28, 53, 748, DateTimeKind.Local).AddTicks(673), null, null, false, "https://www.github.com/Cenny26", "github", null, null, "GITHUB" },
                    { new Guid("9f5471ad-2835-41aa-9c45-98401d97b248"), "superadmin@gmai.com", new DateTime(2024, 4, 14, 13, 28, 53, 748, DateTimeKind.Local).AddTicks(669), null, null, false, "https://www.linkedin.com/in/Kennans26", "linkedin", null, null, "LINKEDIN" }
                });
        }
    }
}
