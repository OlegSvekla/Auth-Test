using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class Linkcontractorstatisticidtocontractor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorStats_Contractors_ContractorId",
                table: "ContractorStats");

            migrationBuilder.DropIndex(
                name: "IX_ContractorStats_ContractorId",
                table: "ContractorStats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c9742c74-9001-4f24-8dbd-ec3cc706fb53", "7F079FA3-8768-4C75-9F7E-1DB867912EFB", "f39d6737-3e1c-4762-b8ed-0be5ca639d63", "7f079fa3-8768-4c75-9f7e-1db867912efb" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorStats_Contractors_Id",
                table: "ContractorStats",
                column: "Id",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorStats_Contractors_Id",
                table: "ContractorStats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "3528956e-5c6a-4386-9d92-7a717257c036", "9720FD25-F22E-44AC-AD63-54320AB88F06", "0d4b90d8-5bbc-46b6-864e-36232b9de61a", "9720fd25-f22e-44ac-ad63-54320ab88f06" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractorStats_ContractorId",
                table: "ContractorStats",
                column: "ContractorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorStats_Contractors_ContractorId",
                table: "ContractorStats",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
