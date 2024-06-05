using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddExistingUserAsAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d414042k-da1f-4e74-c555-415b07f89b27" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "578d11f0-fd92-475f-aa6c-89c162b143eb", "AQAAAAIAAYagAAAAEG/RfHj9FVZc7Vv0Br3u5HTcAr3FWM8czolyImz0OZKDP9dGTWjSHp2wOdVnbst8Fw==", "9a5b5725-56a9-4d63-b518-d23bc1683554" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJointed", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d514042k-da1f-4e74-c555-415b07f89b27", 0, "dfd321ca-ec74-4d00-a02d-6ca4f683a7e4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "admin@localhost.com", "AQAAAAIAAYagAAAAECEq/ADvKL9IhQcgwCfMvZFE9vdCUKK0PbCAtug5CBDsJLg5AT4/6dLdcgvOUjXgIQ==", null, false, "44c995b6-6db0-45d0-bcf2-79fb15baf6ec", null, false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d514042k-da1f-4e74-c555-415b07f89b27" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d514042k-da1f-4e74-c555-415b07f89b27" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d514042k-da1f-4e74-c555-415b07f89b27");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e99e166-24ca-48af-85d4-fcb2e5ca47d6", "AQAAAAIAAYagAAAAEHhhH3pahTFcD7c/QtMoWrxmwV2AKu8WdhLNuEuVn34Rmui3bGSGKl0/l13x0JOV7w==", "df777afc-f5a0-4db5-afb9-5f6d5e3b53c4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJointed", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d414042k-da1f-4e74-c555-415b07f89b27", 0, "c169a9e0-1f0e-4eb6-91c8-dbd7b82f0e5e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "admin@localhost.com", "AQAAAAIAAYagAAAAEJZvrpVLpfovQYR+gXBuzR5uGoeErVNcTO7gUZg1S+SjzNmeiLD4U8H2MO5VpHLVnw==", null, false, "b8c2944d-4306-4999-b443-f923d7ecd215", null, false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", "d414042k-da1f-4e74-c555-415b07f89b27" });
        }
    }
}
