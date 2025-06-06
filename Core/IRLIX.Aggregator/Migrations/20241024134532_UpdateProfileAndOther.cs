using Microsoft.EntityFrameworkCore.Migrations;
using ShuttleX.Meas.Geos;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfileAndOther : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileGeoEntity_Profiles_ProfileId",
                table: "ProfileGeoEntity");

            migrationBuilder.DropTable(
                name: "ContractorGeos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileGeoEntity",
                table: "ProfileGeoEntity");

            migrationBuilder.RenameTable(
                name: "ProfileGeoEntity",
                newName: "ProfileGeos");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileGeoEntity_ProfileId",
                table: "ProfileGeos",
                newName: "IX_ProfileGeos_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileGeos",
                table: "ProfileGeos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "0b95d38e-57e1-4078-ac74-c175a43dab55", "22A89BDC-B77A-44FD-BD34-576C00426AA7", "c6fd6e40-99b7-4935-b4ff-eabd9f922bfe", "22a89bdc-b77a-44fd-bd34-576c00426aa7" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileGeos_Profiles_ProfileId",
                table: "ProfileGeos",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileGeos_Profiles_ProfileId",
                table: "ProfileGeos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileGeos",
                table: "ProfileGeos");

            migrationBuilder.RenameTable(
                name: "ProfileGeos",
                newName: "ProfileGeoEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileGeos_ProfileId",
                table: "ProfileGeoEntity",
                newName: "IX_ProfileGeoEntity_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileGeoEntity",
                table: "ProfileGeoEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContractorGeos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Geo = table.Column<Geo>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorGeos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorGeos_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "7c7bd0dd-5412-41c5-af51-01a63ca6f55c", "344D87C6-52D6-421D-885A-764F941091A3", "8ce7bc56-5441-4c66-9504-1eb6ebabfedd", "344d87c6-52d6-421d-885a-764f941091a3" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractorGeos_ContractorId",
                table: "ContractorGeos",
                column: "ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileGeoEntity_Profiles_ProfileId",
                table: "ProfileGeoEntity",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
