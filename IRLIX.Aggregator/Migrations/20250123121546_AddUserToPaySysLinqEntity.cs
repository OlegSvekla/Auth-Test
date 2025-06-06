using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToPaySysLinqEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "PaySysSubscriptionTypes",
                newName: "IsAvailable");

            migrationBuilder.AlterColumn<string>(
                name: "AssetType",
                table: "PaySysTypes",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "UserToPaySysLinqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    PaySysTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToPaySysLinqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToPaySysLinqs_PaySysTypes_PaySysTypeId",
                        column: x => x.PaySysTypeId,
                        principalTable: "PaySysTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserToPaySysLinqs_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToPaySysLinqs_PaySysTypeId",
                table: "UserToPaySysLinqs",
                column: "PaySysTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToPaySysLinqs_ZoneId",
                table: "UserToPaySysLinqs",
                column: "ZoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToPaySysLinqs");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "PaySysSubscriptionTypes",
                newName: "IsActive");

            migrationBuilder.AlterColumn<int>(
                name: "AssetType",
                table: "PaySysTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
