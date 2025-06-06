using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class OutcomeIncome1to1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IncomeRecordId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_IncomeRecordId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "IncomeRecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeShuttleXPaySysPaymentRecords_IncomeShuttleXPaySysPay~",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                column: "IncomeRecordId",
                principalTable: "IncomeShuttleXPaySysPaymentRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeShuttleXPaySysPaymentRecords_IncomeShuttleXPaySysPay~",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeShuttleXPaySysPaymentRecords_IncomeRecordId",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropColumn(
                name: "IncomeRecordId",
                table: "OutcomeShuttleXPaySysPaymentRecords");
        }
    }
}
