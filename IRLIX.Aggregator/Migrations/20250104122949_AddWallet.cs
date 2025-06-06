using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripePassengerPaymentTransactions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripePassengerPaymentTransactions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripePassengerCustomers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripePassengerCustomers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripeContractorPaymentTransactions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripeContractorPaymentTransactions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripeContractorCustomers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripeContractorCustomers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "PaymentTransactionAction",
                table: "PassengerPaymentTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "PassengerPaymentTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentTransactionAction",
                table: "ContractorPaymentTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "ContractorPaymentTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BinanceContractorCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: true),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BinanceId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ContractId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceContractorCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BinancePassengerCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: true),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ContractId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinancePassengerCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractorWalletBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaySysTypeEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    AssetType = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    TotalPayoutAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalEarnedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    EarnedTodayAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    EarnedPrevOrderAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalBalanceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    HoldBalanceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    WithdrawableBalanceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorWalletBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorWalletBalances_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorWalletBalances_PaySysTypes_PaySysTypeEntityId",
                        column: x => x.PaySysTypeEntityId,
                        principalTable: "PaySysTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IncomeShuttleXPaySysPaymentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaySysTypeEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: false),
                    PaymentTransactionStatus = table.Column<string>(type: "text", nullable: false),
                    HoldExpiryDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetType = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    PaymentTransactionAction = table.Column<string>(type: "text", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalFeeAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentAmountWithFee = table.Column<decimal>(type: "numeric", nullable: false),
                    FromProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeShuttleXPaySysPaymentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeEn~",
                        column: x => x.PaySysTypeEntityId,
                        principalTable: "PaySysTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncomeShuttleXPaySysPaymentRecords_Profiles_FromProfileId",
                        column: x => x.FromProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeShuttleXPaySysPaymentRecords_Profiles_ToProfileId",
                        column: x => x.ToProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OutcomeShuttleXPaySysPaymentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaySysTypeEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: false),
                    PaymentTransactionStatus = table.Column<string>(type: "text", nullable: false),
                    PaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetType = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    PaymentTransactionAction = table.Column<string>(type: "text", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalFeeAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentAmountWithFee = table.Column<decimal>(type: "numeric", nullable: false),
                    ToProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeShuttleXPaySysPaymentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutcomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeE~",
                        column: x => x.PaySysTypeEntityId,
                        principalTable: "PaySysTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OutcomeShuttleXPaySysPaymentRecords_Profiles_ToProfileId",
                        column: x => x.ToProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinanceContractorPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: true),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PrepayId = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: true),
                    OrderStatus = table.Column<string>(type: "text", nullable: false),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BinanceContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceContractorPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinanceContractorPaymentTransactions_BinanceContractorCusto~",
                        column: x => x.BinanceContractorCustomerId,
                        principalTable: "BinanceContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinanceContractorPayoutTransactionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: true),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    RequestId = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PayoutStatus = table.Column<string>(type: "text", nullable: false),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BinanceContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceContractorPayoutTransactionEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinanceContractorPayoutTransactionEntity_BinanceContractorC~",
                        column: x => x.BinanceContractorCustomerId,
                        principalTable: "BinanceContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinancePassengerPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: true),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PrepayId = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: true),
                    OrderStatus = table.Column<string>(type: "text", nullable: false),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BinancePassengerCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinancePassengerPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinancePassengerPaymentTransactions_BinancePassengerCustome~",
                        column: x => x.BinancePassengerCustomerId,
                        principalTable: "BinancePassengerCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinanceContractorPaymentTransactions_BinanceContractorCusto~",
                table: "BinanceContractorPaymentTransactions",
                column: "BinanceContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BinanceContractorPayoutTransactionEntity_BinanceContractorC~",
                table: "BinanceContractorPayoutTransactionEntity",
                column: "BinanceContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BinancePassengerPaymentTransactions_BinancePassengerCustome~",
                table: "BinancePassengerPaymentTransactions",
                column: "BinancePassengerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorWalletBalances_ContractorId",
                table: "ContractorWalletBalances",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorWalletBalances_PaySysTypeEntityId",
                table: "ContractorWalletBalances",
                column: "PaySysTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeShuttleXPaySysPaymentRecords_FromProfileId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                column: "FromProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeShuttleXPaySysPaymentRecords_PaySysTypeEntityId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeShuttleXPaySysPaymentRecords_ToProfileId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                column: "ToProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_PaySysTypeEntityId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_ToProfileId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "ToProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinanceContractorPaymentTransactions");

            migrationBuilder.DropTable(
                name: "BinanceContractorPayoutTransactionEntity");

            migrationBuilder.DropTable(
                name: "BinancePassengerPaymentTransactions");

            migrationBuilder.DropTable(
                name: "ContractorWalletBalances");

            migrationBuilder.DropTable(
                name: "IncomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropTable(
                name: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropTable(
                name: "BinanceContractorCustomers");

            migrationBuilder.DropTable(
                name: "BinancePassengerCustomers");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionAction",
                table: "PassengerPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "PassengerPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionAction",
                table: "ContractorPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "ContractorPaymentTransactions");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripePassengerPaymentTransactions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripePassengerPaymentTransactions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripePassengerCustomers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripePassengerCustomers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripeContractorPaymentTransactions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripeContractorPaymentTransactions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripeContractorCustomers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdempotencyKey",
                table: "StripeContractorCustomers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
