using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingSocialMediaAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2df0aaa8-40cb-40de-a4fa-63540fe153fc"));

            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("4ec83ac3-0c40-437a-90c6-9717187d5b73"));

            migrationBuilder.DeleteData(
                table: "SocialMediaAccounts",
                keyColumn: "Id",
                keyValue: new Guid("546dd057-c6d3-4f86-ab9a-f34db0808455"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
