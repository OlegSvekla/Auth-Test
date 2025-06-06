using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaySysAndWalletEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorWalletBalances_PaySysTypes_PaySysTypeEntityId",
                table: "ContractorWalletBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeEn~",
                table: "IncomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeE~",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_PaySysTypeEntityId",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_IncomeShuttleXPaySysPaymentRecords_PaySysTypeEntityId",
                table: "IncomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_ContractorWalletBalances_PaySysTypeEntityId",
                table: "ContractorWalletBalances");

            migrationBuilder.DropColumn(
                name: "PaySysTypeEntityId",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropColumn(
                name: "PaySysTypeEntityId",
                table: "IncomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropColumn(
                name: "PaySysTypeEntityId",
                table: "ContractorWalletBalances");

            migrationBuilder.AddColumn<Guid>(
                name: "PaySysSubscriptionTypeId",
                table: "StripeContractorSubscriptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PaySysPaymentId",
                table: "PassengerPaymentTransactions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PaySysSubscriptionTypeId",
                table: "ContractorSubscriptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "ContractorDebtSubscriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PaySysSubscriptionTypeId",
                table: "ContractorDebtSubscriptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StripeContractorSubscriptions_PaySysSubscriptionTypeId",
                table: "StripeContractorSubscriptions",
                column: "PaySysSubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_PaySysTypeId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeShuttleXPaySysPaymentRecords_PaySysTypeId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorWalletBalances_PaySysTypeId",
                table: "ContractorWalletBalances",
                column: "PaySysTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSubscriptions_PaySysSubscriptionTypeId",
                table: "ContractorSubscriptions",
                column: "PaySysSubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDebtSubscriptions_PaySysSubscriptionTypeId",
                table: "ContractorDebtSubscriptions",
                column: "PaySysSubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorDebtSubscriptions_PaySysSubscriptionTypes_PaySysS~",
                table: "ContractorDebtSubscriptions",
                column: "PaySysSubscriptionTypeId",
                principalTable: "PaySysSubscriptionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorSubscriptions_PaySysSubscriptionTypes_PaySysSubsc~",
                table: "ContractorSubscriptions",
                column: "PaySysSubscriptionTypeId",
                principalTable: "PaySysSubscriptionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorWalletBalances_PaySysTypes_PaySysTypeId",
                table: "ContractorWalletBalances",
                column: "PaySysTypeId",
                principalTable: "PaySysTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeId",
                principalTable: "PaySysTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeId",
                principalTable: "PaySysTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StripeContractorSubscriptions_PaySysSubscriptionTypes_PaySy~",
                table: "StripeContractorSubscriptions",
                column: "PaySysSubscriptionTypeId",
                principalTable: "PaySysSubscriptionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorDebtSubscriptions_PaySysSubscriptionTypes_PaySysS~",
                table: "ContractorDebtSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractorSubscriptions_PaySysSubscriptionTypes_PaySysSubsc~",
                table: "ContractorSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractorWalletBalances_PaySysTypes_PaySysTypeId",
                table: "ContractorWalletBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeId",
                table: "IncomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeId",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_StripeContractorSubscriptions_PaySysSubscriptionTypes_PaySy~",
                table: "StripeContractorSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_StripeContractorSubscriptions_PaySysSubscriptionTypeId",
                table: "StripeContractorSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_PaySysTypeId",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_IncomeShuttleXPaySysPaymentRecords_PaySysTypeId",
                table: "IncomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_ContractorWalletBalances_PaySysTypeId",
                table: "ContractorWalletBalances");

            migrationBuilder.DropIndex(
                name: "IX_ContractorSubscriptions_PaySysSubscriptionTypeId",
                table: "ContractorSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_ContractorDebtSubscriptions_PaySysSubscriptionTypeId",
                table: "ContractorDebtSubscriptions");

            migrationBuilder.DropColumn(
                name: "PaySysSubscriptionTypeId",
                table: "StripeContractorSubscriptions");

            migrationBuilder.DropColumn(
                name: "PaySysSubscriptionTypeId",
                table: "ContractorSubscriptions");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "ContractorDebtSubscriptions");

            migrationBuilder.DropColumn(
                name: "PaySysSubscriptionTypeId",
                table: "ContractorDebtSubscriptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaySysPaymentId",
                table: "PassengerPaymentTransactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaySysTypeEntityId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaySysTypeEntityId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaySysTypeEntityId",
                table: "ContractorWalletBalances",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_PaySysTypeEntityId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeShuttleXPaySysPaymentRecords_PaySysTypeEntityId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorWalletBalances_PaySysTypeEntityId",
                table: "ContractorWalletBalances",
                column: "PaySysTypeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorWalletBalances_PaySysTypes_PaySysTypeEntityId",
                table: "ContractorWalletBalances",
                column: "PaySysTypeEntityId",
                principalTable: "PaySysTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeEn~",
                table: "IncomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeEntityId",
                principalTable: "PaySysTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeShuttleXPaySysPaymentRecords_PaySysTypes_PaySysTypeE~",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "PaySysTypeEntityId",
                principalTable: "PaySysTypes",
                principalColumn: "Id");
        }
    }
}
