using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddPatronicNamesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePatronicNameEntity_Profiles_ProfileId",
                table: "ProfilePatronicNameEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfilePatronicNameEntity",
                table: "ProfilePatronicNameEntity");

            migrationBuilder.RenameTable(
                name: "ProfilePatronicNameEntity",
                newName: "ProfilePatronicNames");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePatronicNameEntity_ProfileId",
                table: "ProfilePatronicNames",
                newName: "IX_ProfilePatronicNames_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfilePatronicNames",
                table: "ProfilePatronicNames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePatronicNames_Profiles_ProfileId",
                table: "ProfilePatronicNames",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePatronicNames_Profiles_ProfileId",
                table: "ProfilePatronicNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfilePatronicNames",
                table: "ProfilePatronicNames");

            migrationBuilder.RenameTable(
                name: "ProfilePatronicNames",
                newName: "ProfilePatronicNameEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePatronicNames_ProfileId",
                table: "ProfilePatronicNameEntity",
                newName: "IX_ProfilePatronicNameEntity_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfilePatronicNameEntity",
                table: "ProfilePatronicNameEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePatronicNameEntity_Profiles_ProfileId",
                table: "ProfilePatronicNameEntity",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
