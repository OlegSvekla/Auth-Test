using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileFirebaseTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "ProfileFirebaseTokens",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastOnline",
                table: "Contractors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfileFirebaseTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TopicName = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileFirebaseTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileFirebaseTopics_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileFirebaseTokens_SessionId",
                table: "ProfileFirebaseTokens",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileFirebaseTopics_ProfileId",
                table: "ProfileFirebaseTopics",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileFirebaseTokens_Sessions_SessionId",
                table: "ProfileFirebaseTokens",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileFirebaseTokens_Sessions_SessionId",
                table: "ProfileFirebaseTokens");

            migrationBuilder.DropTable(
                name: "ProfileFirebaseTopics");

            migrationBuilder.DropIndex(
                name: "IX_ProfileFirebaseTokens_SessionId",
                table: "ProfileFirebaseTokens");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "ProfileFirebaseTokens");

            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "Contractors");
        }
    }
}
