using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaceStopPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatonContractorPayoutTransactions");

            migrationBuilder.RenameColumn(
                name: "StopPointAddress",
                table: "OrderStopPoints",
                newName: "StopPointPlace");

            migrationBuilder.RenameColumn(
                name: "StopPointAddress",
                table: "OfferStopPoints",
                newName: "StopPointPlace");

            migrationBuilder.AddColumn<string>(
                name: "StopPointFullAddress",
                table: "OrderStopPoints",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StopPointFullAddress",
                table: "OfferStopPoints",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PlatonContractorPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PayoutStatus = table.Column<string>(type: "text", nullable: true),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    JsonAdditionalData = table.Column<string>(type: "jsonb", nullable: true),
                    PlatonContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatonContractorPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatonContractorPaymentTransactions_PlatonContractorCustome~",
                        column: x => x.PlatonContractorCustomerId,
                        principalTable: "PlatonContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatonContractorPaymentTransactions_PlatonContractorCustome~",
                table: "PlatonContractorPaymentTransactions",
                column: "PlatonContractorCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatonContractorPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "StopPointFullAddress",
                table: "OrderStopPoints");

            migrationBuilder.DropColumn(
                name: "StopPointFullAddress",
                table: "OfferStopPoints");

            migrationBuilder.RenameColumn(
                name: "StopPointPlace",
                table: "OrderStopPoints",
                newName: "StopPointAddress");

            migrationBuilder.RenameColumn(
                name: "StopPointPlace",
                table: "OfferStopPoints",
                newName: "StopPointAddress");

            migrationBuilder.CreateTable(
                name: "PlatonContractorPayoutTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatonContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    JsonAdditionalData = table.Column<string>(type: "jsonb", nullable: true),
                    PayoutStatus = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatonContractorPayoutTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatonContractorPayoutTransactions_PlatonContractorCustomer~",
                        column: x => x.PlatonContractorCustomerId,
                        principalTable: "PlatonContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatonContractorPayoutTransactions_PlatonContractorCustomer~",
                table: "PlatonContractorPayoutTransactions",
                column: "PlatonContractorCustomerId");
        }
    }
}
