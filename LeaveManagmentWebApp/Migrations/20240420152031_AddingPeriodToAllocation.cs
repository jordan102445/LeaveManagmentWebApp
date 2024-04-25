using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingPeriodToAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f811c09a-0243-4618-9e6b-ad0dc42b7774", "AQAAAAIAAYagAAAAEM33kCmyochy7MvkJInoX6e4xEyGHdjOL1HDiExBx7egzxvPRBqzKqqZJ68+eFL16g==", "6395d259-cc21-4d9e-9e98-59eddae9a0ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78413e35-1f42-4ca9-b13c-59422c69712f", "AQAAAAIAAYagAAAAEJRmN/p+0kX2LAyoj4bPRuUo9oane9K//CKcOtw7Km+TyKpDrbnD71PKyRvrq79fNw==", "786d633b-0d7e-41ab-b95a-ef4203b077b2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26c72c3a-5111-4c22-8f4d-69697c8fc470", "AQAAAAIAAYagAAAAEMvhHd6IrB06lCT1M5jn9UDUYxAWOwu0y0AczY/LlI9ZCc+Do32hQ4sGeFwnk16mdA==", "70317e85-94b3-4fdf-ac6b-f0f6a98c4a9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daa5b6c2-e153-40bf-b9bb-b5786d0e8318", "AQAAAAIAAYagAAAAEEqQ5dJ9QWE5QpucO0PzlQeiAy44SnxjgXzifKDOU4k73SjZW5/MVaamDeOaScerBQ==", "27702ff7-5bfb-4c53-93ac-fc7a7317cef3" });
        }
    }
}
