using Microsoft.EntityFrameworkCore.Migrations;
using ShuttleX.Meas.Geos;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLotteryAndProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_AspNetUsers_WinnerId",
                table: "Prizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_OwnerId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "FoundPlacesML");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Waypoints",
                newName: "Geo");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Waypoints",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TicketCode",
                table: "Tickets",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prizes",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "33b41c53-c939-4c04-bade-ebe10e39bff6", "0475B1AA-AC41-4CDF-8EBD-4D49892ADE1D", "a9ddb923-8f37-4e16-a225-04df0eff0d5f", "0475b1aa-ac41-4cdf-8ebd-4d49892ade1d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Profiles_WinnerId",
                table: "Prizes",
                column: "WinnerId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Contractors_Id",
                table: "Profiles",
                column: "Id",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Passengers_Id",
                table: "Profiles",
                column: "Id",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Profiles_OwnerId",
                table: "Tickets",
                column: "OwnerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Profiles_WinnerId",
                table: "Prizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Contractors_Id",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Passengers_Id",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Profiles_OwnerId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Waypoints");

            migrationBuilder.RenameColumn(
                name: "Geo",
                table: "Waypoints",
                newName: "Location");

            migrationBuilder.AlterColumn<string>(
                name: "TicketCode",
                table: "Tickets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prizes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "FoundPlacesML",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CityOrLocality = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FullAddress = table.Column<string>(type: "text", nullable: false),
                    Geo = table.Column<Geo>(type: "jsonb", nullable: false),
                    Place = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundPlacesML", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "6027e93a-0f3a-4ee1-87dd-038d0d6abcce", "EE2A2D78-8B39-42F2-BEEA-2B81018D7949", "720bbe82-d55b-4b8f-8ff0-3b56a335ecf1", "ee2a2d78-8b39-42f2-beea-2b81018d7949" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_AspNetUsers_WinnerId",
                table: "Prizes",
                column: "WinnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_OwnerId",
                table: "Tickets",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
