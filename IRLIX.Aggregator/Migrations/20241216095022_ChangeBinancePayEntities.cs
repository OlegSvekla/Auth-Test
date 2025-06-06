using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBinancePayEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "5c78db36-0249-4d3c-a69e-b6cb6477ae69", "8F8E2B55-9052-4018-AFB1-AD4BB5A22C3C", "2326f0e5-0c2c-48ee-bd88-f22678e75c2a", "8f8e2b55-9052-4018-afb1-ad4bb5a22c3c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "4a69aaf1-e04a-4ca0-bfee-73b4970cd52d", "B20BCECF-15AD-42DF-8EC2-ED70AF7893FD", "2e5f0f2f-bddb-4719-9904-61836cd84179", "b20bcecf-15ad-42df-8ec2-ed70af7893fd" });
        }
    }
}
