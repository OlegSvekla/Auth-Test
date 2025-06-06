using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddBlobNameInAvatarAndDocBlobEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProfileAvatars");

            migrationBuilder.DropColumn(
                name: "CheckSum",
                table: "DocBlobs");

            migrationBuilder.DropColumn(
                name: "File",
                table: "DocBlobs");

            migrationBuilder.AddColumn<string>(
                name: "BlobName",
                table: "ProfileAvatars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EstimatedArriveToDropOffDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlobName",
                table: "DocBlobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "4a69aaf1-e04a-4ca0-bfee-73b4970cd52d", "B20BCECF-15AD-42DF-8EC2-ED70AF7893FD", "2e5f0f2f-bddb-4719-9904-61836cd84179", "b20bcecf-15ad-42df-8ec2-ed70af7893fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlobName",
                table: "ProfileAvatars");

            migrationBuilder.DropColumn(
                name: "BlobName",
                table: "DocBlobs");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "ProfileAvatars",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EstimatedArriveToDropOffDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "CheckSum",
                table: "DocBlobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "DocBlobs",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c5f6453f-3b51-425a-aee5-2ca272067159", "DD36E3E9-EE90-45E5-8515-B02FFBB8286C", "8e40e132-65da-4bdb-b865-8e77455292c4", "dd36e3e9-ee90-45e5-8515-b02ffbb8286c" });
        }
    }
}
