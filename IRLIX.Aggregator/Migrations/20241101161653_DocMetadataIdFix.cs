using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class DocMetadataIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docs_DocMetadatas_DocMetadataId",
                table: "Docs");

            migrationBuilder.DropIndex(
                name: "IX_Docs_DocMetadataId",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "DocMetadataId",
                table: "Docs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "9d889af7-15e9-4fa5-8086-514d3baf2b78", "3FE77B37-6CC9-418F-B41F-7FE240A9222F", "6858b821-08d2-4162-af75-b87be4dc88db", "3fe77b37-6cc9-418f-b41f-7fe240a9222f" });

            migrationBuilder.CreateIndex(
                name: "IX_Docs_MetadataId",
                table: "Docs",
                column: "MetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Docs_DocMetadatas_MetadataId",
                table: "Docs",
                column: "MetadataId",
                principalTable: "DocMetadatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docs_DocMetadatas_MetadataId",
                table: "Docs");

            migrationBuilder.DropIndex(
                name: "IX_Docs_MetadataId",
                table: "Docs");

            migrationBuilder.AddColumn<Guid>(
                name: "DocMetadataId",
                table: "Docs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "dd452660-c403-41bf-8109-50c860238b18", "7888D67B-3252-4A1C-B02F-317FCE093D96", "bc68af5b-c71a-4b77-8c16-10e1664db87c", "7888d67b-3252-4a1c-b02f-317fce093d96" });

            migrationBuilder.CreateIndex(
                name: "IX_Docs_DocMetadataId",
                table: "Docs",
                column: "DocMetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Docs_DocMetadatas_DocMetadataId",
                table: "Docs",
                column: "DocMetadataId",
                principalTable: "DocMetadatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
