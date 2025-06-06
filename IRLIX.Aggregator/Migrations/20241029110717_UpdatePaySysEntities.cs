using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaySysEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerPaymentTransactions_SagaPayments_SagaPaymentId",
                table: "PassengerPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "IdempotencyKey",
                table: "StripeContractorSubscriptions");

            migrationBuilder.DropColumn(
                name: "IdempotencyKeyExpDate",
                table: "StripeContractorSubscriptions");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "SagaPayments",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SagaPaymentId",
                table: "PassengerPaymentTransactions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CompletePaymentDate",
                table: "PassengerPaymentTransactions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "PassengerPaymentTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CompletePaymentDate",
                table: "ContractorPaymentTransactions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "ContractorPaymentTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "1a9ec6fc-0d9e-4448-be1e-f15fe6848419", "5EA585C7-9930-4ECF-AC90-1E99F7AA02AF", "067f826f-f962-412b-b023-c881d2fe448e", "5ea585c7-9930-4ecf-ac90-1e99f7aa02af" });

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerPaymentTransactions_SagaPayments_SagaPaymentId",
                table: "PassengerPaymentTransactions",
                column: "SagaPaymentId",
                principalTable: "SagaPayments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerPaymentTransactions_SagaPayments_SagaPaymentId",
                table: "PassengerPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "SagaPayments");

            migrationBuilder.DropColumn(
                name: "CompletePaymentDate",
                table: "PassengerPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "PassengerPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CompletePaymentDate",
                table: "ContractorPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "ContractorPaymentTransactions");

            migrationBuilder.AddColumn<string>(
                name: "IdempotencyKey",
                table: "StripeContractorSubscriptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "IdempotencyKeyExpDate",
                table: "StripeContractorSubscriptions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "SagaPaymentId",
                table: "PassengerPaymentTransactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "0391c961-ca1a-43b9-ba8a-4624e2a784e7", "92A9E46E-6153-4B7C-9D3F-A84E5B9D52D4", "35ae0d6e-f439-4777-a399-499ec45dcc90", "92a9e46e-6153-4b7c-9d3f-a84e5b9d52d4" });

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerPaymentTransactions_SagaPayments_SagaPaymentId",
                table: "PassengerPaymentTransactions",
                column: "SagaPaymentId",
                principalTable: "SagaPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
