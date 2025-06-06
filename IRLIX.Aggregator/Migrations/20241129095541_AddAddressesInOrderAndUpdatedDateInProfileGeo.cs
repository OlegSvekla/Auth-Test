using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressesInOrderAndUpdatedDateInProfileGeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "ProfileGeos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "ProfileGeos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EstimatedArriveToPickUpDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DropOffAddress",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DropOffPlace",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PickUpAddress",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PickUpPlace",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StopPointAddress",
                table: "OrderStopPoints",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c5f6453f-3b51-425a-aee5-2ca272067159", "DD36E3E9-EE90-45E5-8515-B02FFBB8286C", "8e40e132-65da-4bdb-b865-8e77455292c4", "dd36e3e9-ee90-45e5-8515-b02ffbb8286c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "ProfileGeos");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ProfileGeos");

            migrationBuilder.DropColumn(
                name: "DropOffAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DropOffPlace",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickUpAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickUpPlace",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StopPointAddress",
                table: "OrderStopPoints");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EstimatedArriveToPickUpDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c4f2a117-13bc-4818-9b35-4c1ce10ec9a7", "AE55A529-1B57-49F4-AFC9-9AEC354E9521", "29e95b0d-45fd-49a8-bfeb-c74a2b67912f", "ae55a529-1b57-49f4-afc9-9aec354e9521" });
        }
    }
}
