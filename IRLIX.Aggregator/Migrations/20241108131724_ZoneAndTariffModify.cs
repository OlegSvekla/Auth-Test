using Microsoft.EntityFrameworkCore.Migrations;
using ShuttleX.Meas.Geos;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class ZoneAndTariffModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseFare",
                table: "Tariffs");

            migrationBuilder.RenameColumn(
                name: "ScheduledTripMinimumPenalty",
                table: "Tariffs",
                newName: "TripMinimumPenalty");

            migrationBuilder.AddColumn<Geo>(
                name: "CenterPoint",
                table: "Zones",
                type: "jsonb",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "3740942b-4908-4426-b3b6-de1b36afde8c", "1589DF31-0781-4041-BBFB-EC5D734A01A5", "da19a2bd-d898-45ac-9867-b23d92cb84c4", "1589df31-0781-4041-bbfb-ec5d734a01a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterPoint",
                table: "Zones");

            migrationBuilder.RenameColumn(
                name: "TripMinimumPenalty",
                table: "Tariffs",
                newName: "ScheduledTripMinimumPenalty");

            migrationBuilder.AddColumn<decimal>(
                name: "BaseFare",
                table: "Tariffs",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "33b41c53-c939-4c04-bade-ebe10e39bff6", "0475B1AA-AC41-4CDF-8EBD-4D49892ADE1D", "a9ddb923-8f37-4e16-a225-04df0eff0d5f", "0475b1aa-ac41-4cdf-8ebd-4d49892ade1d" });
        }
    }
}
