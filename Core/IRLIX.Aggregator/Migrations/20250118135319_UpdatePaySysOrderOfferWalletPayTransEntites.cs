using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaySysOrderOfferWalletPayTransEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentSystemRecognizer");

            migrationBuilder.AddColumn<string>(
                name: "Last4",
                table: "PlatonContractorCustomers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AssetType",
                table: "PaySysTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "PaySysTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ZoneId",
                table: "ContractorWalletBalances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "OfferOrderPaymentTransactionLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    PassengerPaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferOrderPaymentTransactionLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferOrderPaymentTransactionLinks_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferOrderPaymentTransactionLinks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferOrderPaymentTransactionLinks_PassengerPaymentTransacti~",
                        column: x => x.PassengerPaymentTransactionId,
                        principalTable: "PassengerPaymentTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractorWalletBalances_ZoneId",
                table: "ContractorWalletBalances",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferOrderPaymentTransactionLinks_OfferId",
                table: "OfferOrderPaymentTransactionLinks",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferOrderPaymentTransactionLinks_OrderId",
                table: "OfferOrderPaymentTransactionLinks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferOrderPaymentTransactionLinks_PassengerPaymentTransacti~",
                table: "OfferOrderPaymentTransactionLinks",
                column: "PassengerPaymentTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorWalletBalances_Zones_ZoneId",
                table: "ContractorWalletBalances",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorWalletBalances_Zones_ZoneId",
                table: "ContractorWalletBalances");

            migrationBuilder.DropTable(
                name: "OfferOrderPaymentTransactionLinks");

            migrationBuilder.DropIndex(
                name: "IX_ContractorWalletBalances_ZoneId",
                table: "ContractorWalletBalances");

            migrationBuilder.DropColumn(
                name: "Last4",
                table: "PlatonContractorCustomers");

            migrationBuilder.DropColumn(
                name: "AssetType",
                table: "PaySysTypes");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PaySysTypes");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "ContractorWalletBalances");

            migrationBuilder.CreateTable(
                name: "PaymentSystemRecognizer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentSystemName = table.Column<string>(type: "text", nullable: true),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSystemRecognizer", x => x.Id);
                });
        }
    }
}
