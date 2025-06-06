using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class Updateuserandadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HardcodedCode",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Simulacrum",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Email", "HardcodedCode", "NormalizedEmail", "Simulacrum" },
                values: new object[] { "god-admin@shuttlex.com", "7788", "GOD-ADMIN@SHUTTLEX.COM", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HardcodedCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Simulacrum",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Email", "NormalizedEmail" },
                values: new object[] { "no-reply@shuttlex.com", "NO-REPLY@SHUTTLEX.COM" });
        }
    }
}
