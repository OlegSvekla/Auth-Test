using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddPickUpRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Orders_OrderId",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Routes",
                newName: "PickUpOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_OrderId",
                table: "Routes",
                newName: "IX_Routes_PickUpOrderId");

            migrationBuilder.AddColumn<Guid>(
                name: "DropOffOrderId",
                table: "Routes",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "ea67ee50-18b2-4d67-a75f-aa00ee8456b5", "E01C7C41-4092-4B5A-A717-20EE1E19C9BD", "1687a219-1297-4e4a-959d-d5be860a3422", "e01c7c41-4092-4b5a-a717-20ee1e19c9bd" });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DropOffOrderId",
                table: "Routes",
                column: "DropOffOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Orders_DropOffOrderId",
                table: "Routes",
                column: "DropOffOrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Orders_PickUpOrderId",
                table: "Routes",
                column: "PickUpOrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Orders_DropOffOrderId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Orders_PickUpOrderId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DropOffOrderId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DropOffOrderId",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "PickUpOrderId",
                table: "Routes",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_PickUpOrderId",
                table: "Routes",
                newName: "IX_Routes_OrderId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "3740942b-4908-4426-b3b6-de1b36afde8c", "1589DF31-0781-4041-BBFB-EC5D734A01A5", "da19a2bd-d898-45ac-9867-b23d92cb84c4", "1589df31-0781-4041-bbfb-ec5d734a01a5" });

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Orders_OrderId",
                table: "Routes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
