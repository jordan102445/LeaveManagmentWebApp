using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagmentWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", null, "User", "USER" },
                    { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJointed", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4", 0, "c42492d3-f6c0-4897-8188-26b79338e9fd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAIAAYagAAAAELsTraqgM3dzrh7zPIsF2e62tCzgBEpUDBJuEwzaQE67E/oH3P7wJUuqzC7emR8u3g==", null, false, "c0e27938-af86-450a-bc51-e8ee7c8537e3", null, false, null },
                    { "d414042k-da1f-4e74-c555-415b07f89b27", 0, "7992ad1f-0fb1-4487-a9fd-b13b228a2f1e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "admin@localhost.com", null, "AQAAAAIAAYagAAAAEGyONjUhaGBrG+KjLEIottUQBaTC1/J/Egy42EFt+LHsri3NXOCSEjn76ZYecmwdLw==", null, false, "3547abeb-d27b-4cbe-ba05-6c6b6ab743ce", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4" },
                    { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d414042k-da1f-4e74-c555-415b07f89b27" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d414042k-da1f-4e74-c555-415b07f89b27" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27");
        }
    }
}
