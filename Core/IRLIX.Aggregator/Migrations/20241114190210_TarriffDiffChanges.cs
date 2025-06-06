using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class TarriffDiffChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_Tariffs_PrimaryTariffId",
                table: "Contractors");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tariffs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryTariffId",
                table: "Contractors",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "65a11d8b-f07f-451a-85ad-549f9d9f8db9", "8827463C-CF0B-48CA-A669-C8657DFF48D6", "e8183f8f-27c0-49a5-9f92-8dae64264a95", "8827463c-cf0b-48ca-a669-c8657dff48d6" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_Tariffs_PrimaryTariffId",
                table: "Contractors",
                column: "PrimaryTariffId",
                principalTable: "Tariffs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_Tariffs_PrimaryTariffId",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tariffs");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryTariffId",
                table: "Contractors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "d0b4535b-45b1-4a28-af44-7322bff01e50", "6BA6C6BE-3EDF-4953-A917-ACAE04D25362", "c2ec28d6-d7f5-46d9-9326-db8242ae5a20", "6ba6c6be-3edf-4953-a917-acae04d25362" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_Tariffs_PrimaryTariffId",
                table: "Contractors",
                column: "PrimaryTariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
