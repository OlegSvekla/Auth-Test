using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class FixProfileVehicleForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorVehicles_ProfileVehicles_ProfileVehicleId",
                table: "ContractorVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileVehicles_ProfileVehicles_ContractorVehicleId",
                table: "ProfileVehicles");

            migrationBuilder.DropIndex(
                name: "IX_ProfileVehicles_ContractorVehicleId",
                table: "ProfileVehicles");

            migrationBuilder.DropIndex(
                name: "IX_ContractorVehicles_ProfileVehicleId",
                table: "ContractorVehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c4f2a117-13bc-4818-9b35-4c1ce10ec9a7", "AE55A529-1B57-49F4-AFC9-9AEC354E9521", "29e95b0d-45fd-49a8-bfeb-c74a2b67912f", "ae55a529-1b57-49f4-afc9-9aec354e9521" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileVehicles_ContractorVehicleId",
                table: "ProfileVehicles",
                column: "ContractorVehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileVehicles_ContractorVehicles_ContractorVehicleId",
                table: "ProfileVehicles",
                column: "ContractorVehicleId",
                principalTable: "ContractorVehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileVehicles_ContractorVehicles_ContractorVehicleId",
                table: "ProfileVehicles");

            migrationBuilder.DropIndex(
                name: "IX_ProfileVehicles_ContractorVehicleId",
                table: "ProfileVehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "0ca4c72e-13b1-4215-a4ac-725f38d36b51", "71DA9479-C9DA-411C-A3FD-3B8C1752AA2A", "ef691fba-d4d2-4fed-9ae9-a8e9b99e067c", "71da9479-c9da-411c-a3fd-3b8c1752aa2a" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileVehicles_ContractorVehicleId",
                table: "ProfileVehicles",
                column: "ContractorVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorVehicles_ProfileVehicleId",
                table: "ContractorVehicles",
                column: "ProfileVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorVehicles_ProfileVehicles_ProfileVehicleId",
                table: "ContractorVehicles",
                column: "ProfileVehicleId",
                principalTable: "ProfileVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileVehicles_ProfileVehicles_ContractorVehicleId",
                table: "ProfileVehicles",
                column: "ContractorVehicleId",
                principalTable: "ProfileVehicles",
                principalColumn: "Id");
        }
    }
}
