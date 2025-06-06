using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentTransactionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerPaymentTransactions_PassengerCustomers_PassengerCu~",
                table: "PassengerPaymentTransactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PassengerCustomerId",
                table: "PassengerPaymentTransactions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerPaymentTransactions_PassengerCustomers_PassengerCu~",
                table: "PassengerPaymentTransactions",
                column: "PassengerCustomerId",
                principalTable: "PassengerCustomers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerPaymentTransactions_PassengerCustomers_PassengerCu~",
                table: "PassengerPaymentTransactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PassengerCustomerId",
                table: "PassengerPaymentTransactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerPaymentTransactions_PassengerCustomers_PassengerCu~",
                table: "PassengerPaymentTransactions",
                column: "PassengerCustomerId",
                principalTable: "PassengerCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
