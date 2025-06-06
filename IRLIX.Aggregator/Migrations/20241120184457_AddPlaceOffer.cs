using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaceOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DropOffPlace",
                table: "Offers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PickUpPlace",
                table: "Offers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "3528956e-5c6a-4386-9d92-7a717257c036", "9720FD25-F22E-44AC-AD63-54320AB88F06", "0d4b90d8-5bbc-46b6-864e-36232b9de61a", "9720fd25-f22e-44ac-ad63-54320ab88f06" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOffPlace",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "PickUpPlace",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "65a11d8b-f07f-451a-85ad-549f9d9f8db9", "8827463C-CF0B-48CA-A669-C8657DFF48D6", "e8183f8f-27c0-49a5-9f92-8dae64264a95", "8827463c-cf0b-48ca-a669-c8657dff48d6" });
        }
    }
}
