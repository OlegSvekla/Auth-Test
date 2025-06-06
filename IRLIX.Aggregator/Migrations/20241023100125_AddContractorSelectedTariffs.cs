using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddContractorSelectedTariffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorEntityTariffEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "PickUpRouteId",
                table: "ReceivedOfferContractors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "CurrentWarnings",
                table: "Contractors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Contractors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance",
                table: "ContractorStats",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EarnedToday",
                table: "ContractorStats",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalEarnedForWholePeriod",
                table: "ContractorStats",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalWarnings",
                table: "ContractorStats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContractorSelectedTariffs",
                columns: table => new
                {
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    TariffId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorSelectedTariffs", x => new { x.ContractorId, x.TariffId });
                    table.ForeignKey(
                        name: "FK_ContractorSelectedTariffs_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorSelectedTariffs_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "a9bc2c4c-874f-449a-9b5a-5a2b61f4fe61", "114D3FB7-E867-4D31-B5BF-7068072D6AA8", "3b77a8ae-d7ea-4cfb-95fc-129ba8c16db0", "114d3fb7-e867-4d31-b5bf-7068072d6aa8" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedOfferContractors_PickUpRouteId",
                table: "ReceivedOfferContractors",
                column: "PickUpRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSelectedTariffs_TariffId",
                table: "ContractorSelectedTariffs",
                column: "TariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedOfferContractors_Routes_PickUpRouteId",
                table: "ReceivedOfferContractors",
                column: "PickUpRouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedOfferContractors_Routes_PickUpRouteId",
                table: "ReceivedOfferContractors");

            migrationBuilder.DropTable(
                name: "ContractorSelectedTariffs");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedOfferContractors_PickUpRouteId",
                table: "ReceivedOfferContractors");

            migrationBuilder.DropColumn(
                name: "PickUpRouteId",
                table: "ReceivedOfferContractors");

            migrationBuilder.DropColumn(
                name: "CurrentWarnings",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "ContractorStats");

            migrationBuilder.DropColumn(
                name: "EarnedToday",
                table: "ContractorStats");

            migrationBuilder.DropColumn(
                name: "TotalEarnedForWholePeriod",
                table: "ContractorStats");

            migrationBuilder.DropColumn(
                name: "TotalWarnings",
                table: "ContractorStats");

            migrationBuilder.CreateTable(
                name: "ContractorEntityTariffEntity",
                columns: table => new
                {
                    SelectedTariffContractorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectedTariffsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorEntityTariffEntity", x => new { x.SelectedTariffContractorsId, x.SelectedTariffsId });
                    table.ForeignKey(
                        name: "FK_ContractorEntityTariffEntity_Contractors_SelectedTariffCont~",
                        column: x => x.SelectedTariffContractorsId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorEntityTariffEntity_Tariffs_SelectedTariffsId",
                        column: x => x.SelectedTariffsId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "4b30ac41-cd7a-46c0-97c3-bdbb48ce3e12", "59E85088-322C-4643-9CEF-AA09D62523CF", "450aed1b-b7ef-44b5-a931-02dddd1a0492", "59e85088-322c-4643-9cef-aa09d62523cf" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractorEntityTariffEntity_SelectedTariffsId",
                table: "ContractorEntityTariffEntity",
                column: "SelectedTariffsId");
        }
    }
}
