using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddToRecordWalletConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FromWalletId",
                table: "OutcomeShuttleXPaySysPaymentRecords",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ToProfileUserType",
                table: "IncomeShuttleXPaySysPaymentRecords",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ToProfileWalletId",
                table: "IncomeShuttleXPaySysPaymentRecords",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromWalletId",
                table: "OutcomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropColumn(
                name: "ToProfileUserType",
                table: "IncomeShuttleXPaySysPaymentRecords");

            migrationBuilder.DropColumn(
                name: "ToProfileWalletId",
                table: "IncomeShuttleXPaySysPaymentRecords");
        }
    }
}
