using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsersUsernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "26c72c3a-5111-4c22-8f4d-69697c8fc470", true, "user@localhost.com", "AQAAAAIAAYagAAAAEMvhHd6IrB06lCT1M5jn9UDUYxAWOwu0y0AczY/LlI9ZCc+Do32hQ4sGeFwnk16mdA==", "70317e85-94b3-4fdf-ac6b-f0f6a98c4a9f", "user@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "daa5b6c2-e153-40bf-b9bb-b5786d0e8318", true, "ADMIN@LOCALHOST.COM", "admin@localhost.com", "AQAAAAIAAYagAAAAEEqQ5dJ9QWE5QpucO0PzlQeiAy44SnxjgXzifKDOU4k73SjZW5/MVaamDeOaScerBQ==", "27702ff7-5bfb-4c53-93ac-fc7a7317cef3", "admin@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c42492d3-f6c0-4897-8188-26b79338e9fd", false, null, "AQAAAAIAAYagAAAAELsTraqgM3dzrh7zPIsF2e62tCzgBEpUDBJuEwzaQE67E/oH3P7wJUuqzC7emR8u3g==", "c0e27938-af86-450a-bc51-e8ee7c8537e3", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7992ad1f-0fb1-4487-a9fd-b13b228a2f1e", false, "admin@localhost.com", null, "AQAAAAIAAYagAAAAEGyONjUhaGBrG+KjLEIottUQBaTC1/J/Egy42EFt+LHsri3NXOCSEjn76ZYecmwdLw==", "3547abeb-d27b-4cbe-ba05-6c6b6ab743ce", null });
        }
    }
}
