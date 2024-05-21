using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Approeved",
                table: "LeaveRequests",
                newName: "Approved");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Approved",
                table: "LeaveRequests",
                newName: "Approeved");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2c8eefd-9ad0-4d1f-aea2-e29faaf6fb97", "AQAAAAIAAYagAAAAECSgtKIzPIQ41WicGeHOsIKxypYC0e9zQK1yZxx4dcBufPzJ1cNbHTlBC/MN0iMDzA==", "349c8feb-97aa-4860-916a-816ab3efc08f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d414042k-da1f-4e74-c555-415b07f89b27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "605d9007-b126-4b4b-a9b9-2bfa222e63c5", "AQAAAAIAAYagAAAAEOWB7iT3IXkmlqlEtBWhj2MMRX1VvEYVJ3FCNJmKcMvFLjAADB0rzEbgMcxWiWWyfw==", "01bed0b1-21d9-4dfa-851d-7399a75a9e75" });
        }
    }
}
