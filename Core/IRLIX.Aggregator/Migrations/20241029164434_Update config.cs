using Microsoft.EntityFrameworkCore.Migrations;
using ShuttleX.Meas.Geos;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class Updateconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_Zones_ZoneEntityId",
                table: "Contractors");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Zones_ParentEntityId",
                table: "Zones");

            migrationBuilder.DropTable(
                name: "PolygonGeos");

            migrationBuilder.DropIndex(
                name: "IX_Contractors_ZoneEntityId",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "ContractorWorkDuringDayMaxTime",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "ZoneEntityId",
                table: "Contractors");

            migrationBuilder.RenameColumn(
                name: "ParentEntityId",
                table: "Zones",
                newName: "ParentZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Zones_ParentEntityId",
                table: "Zones",
                newName: "IX_Zones_ParentZoneId");

            migrationBuilder.CreateTable(
                name: "ZonePolygonGeos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Geo = table.Column<Geo>(type: "jsonb", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonePolygonGeos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZonePolygonGeos_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "dd452660-c403-41bf-8109-50c860238b18", "7888D67B-3252-4A1C-B02F-317FCE093D96", "bc68af5b-c71a-4b77-8c16-10e1664db87c", "7888d67b-3252-4a1c-b02f-317fce093d96" });

            migrationBuilder.CreateIndex(
                name: "IX_ZonePolygonGeos_ZoneId",
                table: "ZonePolygonGeos",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Zones_ParentZoneId",
                table: "Zones",
                column: "ParentZoneId",
                principalTable: "Zones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Zones_ParentZoneId",
                table: "Zones");

            migrationBuilder.DropTable(
                name: "ZonePolygonGeos");

            migrationBuilder.RenameColumn(
                name: "ParentZoneId",
                table: "Zones",
                newName: "ParentEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Zones_ParentZoneId",
                table: "Zones",
                newName: "IX_Zones_ParentEntityId");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ContractorWorkDuringDayMaxTime",
                table: "Zones",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tariffs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ZoneEntityId",
                table: "Contractors",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PolygonGeos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonGeos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolygonGeos_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "1a9ec6fc-0d9e-4448-be1e-f15fe6848419", "5EA585C7-9930-4ECF-AC90-1E99F7AA02AF", "067f826f-f962-412b-b023-c881d2fe448e", "5ea585c7-9930-4ecf-ac90-1e99f7aa02af" });

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_ZoneEntityId",
                table: "Contractors",
                column: "ZoneEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonGeos_ZoneId",
                table: "PolygonGeos",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_Zones_ZoneEntityId",
                table: "Contractors",
                column: "ZoneEntityId",
                principalTable: "Zones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Zones_ParentEntityId",
                table: "Zones",
                column: "ParentEntityId",
                principalTable: "Zones",
                principalColumn: "Id");
        }
    }
}
