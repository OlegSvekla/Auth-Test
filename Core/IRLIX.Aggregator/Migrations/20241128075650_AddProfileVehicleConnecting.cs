using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileVehicleConnecting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "ContractorVehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "ContractorVehicles");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "ContractorVehicles");

            migrationBuilder.DropColumn(
                name: "Vin",
                table: "ContractorVehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractorVehicleId",
                table: "ProfileVehicles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileVehicleId",
                table: "ContractorVehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ContractorVehicleId",
                table: "ProfileVehicles");

            migrationBuilder.DropColumn(
                name: "ProfileVehicleId",
                table: "ContractorVehicles");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "ContractorVehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "ContractorVehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "ContractorVehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vin",
                table: "ContractorVehicles",
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
    }
}
