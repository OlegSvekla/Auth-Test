using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatonSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlatonContractorCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DefaultPayoutCardToken = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatonContractorCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatonPassengerCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    DefaultPaymentMethodId = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatonPassengerCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatonContractorPayoutTransactions",
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
                    table.PrimaryKey("PK_PlatonContractorPayoutTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatonContractorPayoutTransactions_PlatonContractorCustomer~",
                        column: x => x.PlatonContractorCustomerId,
                        principalTable: "PlatonContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatonPassengerPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentResult = table.Column<string>(type: "text", nullable: true),
                    PaymentStatus = table.Column<string>(type: "text", nullable: true),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    JsonAdditionalData = table.Column<string>(type: "jsonb", nullable: true),
                    PlatonPassengerCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatonPassengerPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatonPassengerPaymentTransactions_PlatonPassengerCustomers~",
                        column: x => x.PlatonPassengerCustomerId,
                        principalTable: "PlatonPassengerCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatonPassengerWallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    ExpMonth = table.Column<long>(type: "bigint", nullable: true),
                    ExpYear = table.Column<long>(type: "bigint", nullable: true),
                    Fingerprint = table.Column<string>(type: "text", nullable: true),
                    Funding = table.Column<string>(type: "text", nullable: true),
                    EncodedCardNumber = table.Column<string>(type: "text", nullable: false),
                    CardToken = table.Column<string>(type: "text", nullable: false),
                    ThreeDSecureSupported = table.Column<bool>(type: "boolean", nullable: false),
                    Wallet = table.Column<string>(type: "text", nullable: true),
                    PlatonPassengerCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatonPassengerWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatonPassengerWallets_PlatonPassengerCustomers_PlatonPasse~",
                        column: x => x.PlatonPassengerCustomerId,
                        principalTable: "PlatonPassengerCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatonContractorPayoutTransactions_PlatonContractorCustomer~",
                table: "PlatonContractorPayoutTransactions",
                column: "PlatonContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatonPassengerPaymentTransactions_PlatonPassengerCustomerId",
                table: "PlatonPassengerPaymentTransactions",
                column: "PlatonPassengerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatonPassengerWallets_PlatonPassengerCustomerId",
                table: "PlatonPassengerWallets",
                column: "PlatonPassengerCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatonContractorPayoutTransactions");

            migrationBuilder.DropTable(
                name: "PlatonPassengerPaymentTransactions");

            migrationBuilder.DropTable(
                name: "PlatonPassengerWallets");

            migrationBuilder.DropTable(
                name: "PlatonContractorCustomers");

            migrationBuilder.DropTable(
                name: "PlatonPassengerCustomers");
        }
    }
}
