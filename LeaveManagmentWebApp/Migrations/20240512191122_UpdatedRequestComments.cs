using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRequestComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cdfb429-7e9e-4b81-89ea-a6f0a134ad08", "AQAAAAIAAYagAAAAENlcRBMEFHXKJlAFHaRUcdrR6AkeL7jMkJM6//TkSaeuaadsdmMuw7xIWxxqRIo07w==", "bdb45942-13d7-4c0b-86c9-c17a826d684b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83fb0d34-df4b-4582-aec0-1a6558ca1689", "AQAAAAIAAYagAAAAEM1L2d1YjUuu7u8aTNEfyRcl7jVfsaoV6J/avHkqNvTJCxXo4YM5DPIixWDtOT8TVw==", "b821daac-4568-448c-8645-e6b08eb522ae" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e62e8d6-d47c-4358-8ec4-aaa706c233f7", "AQAAAAIAAYagAAAAEAdCp5nO5aZ26YHein0rmf9DEgk2KJ+q2hQv43W/7aVxeGdYBljSpveeg+iqx3OjjA==", "68b7e126-dd5b-461f-a34c-944136e55c29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0876687-6da1-4e9e-96a5-328c835c1f45", "AQAAAAIAAYagAAAAENoPCB7S3wxe0BniPQ+KO3HDS2eJxHa6mjMGM0fdDwVsfUuXU6c2rGAb8WI8qGv9qg==", "90327fe6-704f-48f5-9b10-a5ed49fafaea" });
        }
    }
}
