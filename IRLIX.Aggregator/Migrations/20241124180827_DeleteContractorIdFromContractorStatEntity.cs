using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class DeleteContractorIdFromContractorStatEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractorId",
                table: "ContractorStats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "e4ed4644-e4fa-4ef1-b852-4169677fddd1", "E12B70C8-2D6F-46BC-8F88-D7DD329BBD41", "bf1b99a1-e5a0-4636-b453-48bcb5402adc", "e12b70c8-2d6f-46bc-8f88-d7dd329bbd41" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractorId",
                table: "ContractorStats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c9742c74-9001-4f24-8dbd-ec3cc706fb53", "7F079FA3-8768-4C75-9F7E-1DB867912EFB", "f39d6737-3e1c-4762-b8ed-0be5ca639d63", "7f079fa3-8768-4c75-9f7e-1db867912efb" });
        }
    }
}
