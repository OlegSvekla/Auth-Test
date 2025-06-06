using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddContentTypePropIntoBlob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "DocBlobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "4b30ac41-cd7a-46c0-97c3-bdbb48ce3e12", "59E85088-322C-4643-9CEF-AA09D62523CF", "450aed1b-b7ef-44b5-a931-02dddd1a0492", "59e85088-322c-4643-9cef-aa09d62523cf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "DocBlobs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "ca9f7a8d-3652-4d93-9d41-82637fdc7208", "1BDCCECA-4131-45B9-9D30-CDB54654B1DE", "14074154-1fb8-42a3-b2d3-721a3fd139ce", "1bdcceca-4131-45b9-9d30-cdb54654b1de" });
        }
    }
}
