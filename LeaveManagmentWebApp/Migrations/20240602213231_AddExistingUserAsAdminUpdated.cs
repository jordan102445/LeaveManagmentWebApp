using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagmentWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddExistingUserAsAdminUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d514042k-da1f-4e74-c555-415b07f89b27" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d514042k-da1f-4e74-c555-415b07f89b27");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJointed", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0ck1dc22-19f1-4216-9876-4f7a0f8fa5b4", 0, "82a79e95-b442-4d7e-8b8d-0261ffa2333a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "user@localhost.com", "AQAAAAIAAYagAAAAELbEJftkFDIc7xgHf+KCUpF6D76QqNB1gl1U1T7BPpiRwu2PE8HG0byoeyhu6zGXrA==", null, false, "046a432f-99ee-4efa-9a57-d20737feff4d", null, false, "user@localhost.com" },
                    { "d614042k-da1f-4e74-c555-415b07f89b27", 0, "a42feb2c-bac7-4f0e-b856-897d900407e4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "admin@localhost.com", "AQAAAAIAAYagAAAAECPbUpJ8RrlB9LcsE0ix4HiNYJOw+rdsF7GnVJZTop8upCqdBWFostoOLvVVvecIyw==", null, false, "bcad8d7a-5616-49fb-ba44-d4af97f8a30e", null, false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", "0ck1dc22-19f1-4216-9876-4f7a0f8fa5b4" },
                    { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d614042k-da1f-4e74-c555-415b07f89b27" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", "0ck1dc22-19f1-4216-9876-4f7a0f8fa5b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d614042k-da1f-4e74-c555-415b07f89b27" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ck1dc22-19f1-4216-9876-4f7a0f8fa5b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d614042k-da1f-4e74-c555-415b07f89b27");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJointed", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4", 0, "578d11f0-fd92-475f-aa6c-89c162b143eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "user@localhost.com", "AQAAAAIAAYagAAAAEG/RfHj9FVZc7Vv0Br3u5HTcAr3FWM8czolyImz0OZKDP9dGTWjSHp2wOdVnbst8Fw==", null, false, "9a5b5725-56a9-4d63-b518-d23bc1683554", null, false, "user@localhost.com" },
                    { "d514042k-da1f-4e74-c555-415b07f89b27", 0, "dfd321ca-ec74-4d00-a02d-6ca4f683a7e4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "admin@localhost.com", "AQAAAAIAAYagAAAAECEq/ADvKL9IhQcgwCfMvZFE9vdCUKK0PbCAtug5CBDsJLg5AT4/6dLdcgvOUjXgIQ==", null, false, "44c995b6-6db0-45d0-bcf2-79fb15baf6ec", null, false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4" },
                    { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d514042k-da1f-4e74-c555-415b07f89b27" }
                });
        }
    }
}
