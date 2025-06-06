using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "7c7bd0dd-5412-41c5-af51-01a63ca6f55c", "344D87C6-52D6-421D-885A-764F941091A3", "8ce7bc56-5441-4c66-9504-1eb6ebabfedd", "344d87c6-52d6-421d-885a-764f941091a3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "a9bc2c4c-874f-449a-9b5a-5a2b61f4fe61", "114D3FB7-E867-4D31-B5BF-7068072D6AA8", "3b77a8ae-d7ea-4cfb-95fc-129ba8c16db0", "114d3fb7-e867-4d31-b5bf-7068072d6aa8" });
        }
    }
}
