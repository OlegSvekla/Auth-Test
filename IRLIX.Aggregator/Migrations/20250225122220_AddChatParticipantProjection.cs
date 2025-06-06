using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddChatParticipantProjection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatParticipants_Chats_ChatEntityId",
                table: "ChatParticipants");

            migrationBuilder.DropIndex(
                name: "IX_ChatParticipants_ChatEntityId",
                table: "ChatParticipants");

            migrationBuilder.DropColumn(
                name: "ChatEntityId",
                table: "ChatParticipants");

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_ChatId",
                table: "ChatParticipants",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatParticipants_Chats_ChatId",
                table: "ChatParticipants",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatParticipants_Chats_ChatId",
                table: "ChatParticipants");

            migrationBuilder.DropIndex(
                name: "IX_ChatParticipants_ChatId",
                table: "ChatParticipants");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatEntityId",
                table: "ChatParticipants",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_ChatEntityId",
                table: "ChatParticipants",
                column: "ChatEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatParticipants_Chats_ChatEntityId",
                table: "ChatParticipants",
                column: "ChatEntityId",
                principalTable: "Chats",
                principalColumn: "Id");
        }
    }
}
