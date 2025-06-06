using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRouteEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccurateGeometries_Routes_RouteId",
                table: "AccurateGeometries");

            migrationBuilder.DropColumn(
                name: "Geometry",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "TrafficLoad",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "AccurateGeometries",
                newName: "LegId");

            migrationBuilder.RenameIndex(
                name: "IX_AccurateGeometries_RouteId",
                table: "AccurateGeometries",
                newName: "IX_AccurateGeometries_LegId");

            migrationBuilder.CreateTable(
                name: "RouteLegs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DurationSec = table.Column<double>(type: "double precision", nullable: false),
                    DistanceMtr = table.Column<double>(type: "double precision", nullable: false),
                    Geometry = table.Column<string>(type: "text", nullable: false),
                    TrafficLoad = table.Column<string>(type: "text", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteLegs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteLegs_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteLegs_RouteId",
                table: "RouteLegs",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccurateGeometries_RouteLegs_LegId",
                table: "AccurateGeometries",
                column: "LegId",
                principalTable: "RouteLegs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccurateGeometries_RouteLegs_LegId",
                table: "AccurateGeometries");

            migrationBuilder.DropTable(
                name: "RouteLegs");

            migrationBuilder.RenameColumn(
                name: "LegId",
                table: "AccurateGeometries",
                newName: "RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_AccurateGeometries_LegId",
                table: "AccurateGeometries",
                newName: "IX_AccurateGeometries_RouteId");

            migrationBuilder.AddColumn<string>(
                name: "Geometry",
                table: "Routes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrafficLoad",
                table: "Routes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AccurateGeometries_Routes_RouteId",
                table: "AccurateGeometries",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
