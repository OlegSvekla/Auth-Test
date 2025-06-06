using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketEntityIntoPrizeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                table: "Prizes",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "d0b4535b-45b1-4a28-af44-7322bff01e50", "6BA6C6BE-3EDF-4953-A917-ACAE04D25362", "c2ec28d6-d7f5-46d9-9326-db8242ae5a20", "6ba6c6be-3edf-4953-a917-acae04d25362" });

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_TicketId",
                table: "Prizes",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Tickets_TicketId",
                table: "Prizes",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Tickets_TicketId",
                table: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Prizes_TicketId",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Prizes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "ea67ee50-18b2-4d67-a75f-aa00ee8456b5", "E01C7C41-4092-4B5A-A717-20EE1E19C9BD", "1687a219-1297-4e4a-959d-d5be860a3422", "e01c7c41-4092-4b5a-a717-20ee1e19c9bd" });
        }
    }
}
