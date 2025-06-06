using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedDatesFoundPlaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "FoundPlaces",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FoundPlaces",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "00e5f679-006d-488f-86b3-c3a9683ea2af", "19370CA0-4E17-4C07-A462-9355E1BF68B5", "a9c48715-7391-45c3-90d7-66b8bddafcec", "19370ca0-4e17-4c07-a462-9355e1bf68b5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "FoundPlaces");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "FoundPlaces");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "e4ed4644-e4fa-4ef1-b852-4169677fddd1", "E12B70C8-2D6F-46BC-8F88-D7DD329BBD41", "bf1b99a1-e5a0-4636-b453-48bcb5402adc", "e12b70c8-2d6f-46bc-8f88-d7dd329bbd41" });
        }
    }
}
