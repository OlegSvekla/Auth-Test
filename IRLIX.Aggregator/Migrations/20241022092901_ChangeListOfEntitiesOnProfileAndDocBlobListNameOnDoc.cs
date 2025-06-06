using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class ChangeListOfEntitiesOnProfileAndDocBlobListNameOnDoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "ca9f7a8d-3652-4d93-9d41-82637fdc7208", "1BDCCECA-4131-45B9-9D30-CDB54654B1DE", "14074154-1fb8-42a3-b2d3-721a3fd139ce", "1bdcceca-4131-45b9-9d30-cdb54654b1de" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c2c2cd44-0f91-4fc9-8f76-800eb32e7188", "1E6A184A-CCD1-4E7B-98B0-519E11EEE51D", "a255d167-fac4-4ac9-9b4e-c053cd56ba76", "1e6a184a-ccd1-4e7b-98b0-519e11eee51d" });
        }
    }
}
