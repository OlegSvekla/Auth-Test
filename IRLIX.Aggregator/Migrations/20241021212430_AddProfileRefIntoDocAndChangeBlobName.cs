using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileRefIntoDocAndChangeBlobName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocUploadedFiles");

            migrationBuilder.DropColumn(
                name: "BlobIds",
                table: "Docs");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Docs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DocBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    File = table.Column<byte[]>(type: "bytea", nullable: false),
                    CheckSum = table.Column<int>(type: "integer", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    VerifiedBySupport = table.Column<bool>(type: "boolean", nullable: true),
                    ExpiresIn = table.Column<DateOnly>(type: "date", nullable: true),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DocEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocBlobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocBlobs_Docs_DocEntityId",
                        column: x => x.DocEntityId,
                        principalTable: "Docs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocBlobs_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "c2c2cd44-0f91-4fc9-8f76-800eb32e7188", "1E6A184A-CCD1-4E7B-98B0-519E11EEE51D", "a255d167-fac4-4ac9-9b4e-c053cd56ba76", "1e6a184a-ccd1-4e7b-98b0-519e11eee51d" });

            migrationBuilder.CreateIndex(
                name: "IX_Docs_ProfileId",
                table: "Docs",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DocBlobs_DocEntityId",
                table: "DocBlobs",
                column: "DocEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DocBlobs_ProfileId",
                table: "DocBlobs",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Docs_Profiles_ProfileId",
                table: "Docs",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docs_Profiles_ProfileId",
                table: "Docs");

            migrationBuilder.DropTable(
                name: "DocBlobs");

            migrationBuilder.DropIndex(
                name: "IX_Docs_ProfileId",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Docs");

            migrationBuilder.AddColumn<Guid[]>(
                name: "BlobIds",
                table: "Docs",
                type: "uuid[]",
                nullable: false,
                defaultValue: new Guid[0]);

            migrationBuilder.CreateTable(
                name: "DocUploadedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CheckSum = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ExpiresIn = table.Column<DateOnly>(type: "date", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    File = table.Column<byte[]>(type: "bytea", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    VerifiedBySupport = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocUploadedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocUploadedFiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "210e5bd5-75ca-4425-9121-cc5bf3136651", "F0535436-9946-4B24-8CB1-9024363EF475", "4c2c6167-c633-4468-a762-9a7cd012c6cc", "f0535436-9946-4b24-8cb1-9024363ef475" });

            migrationBuilder.CreateIndex(
                name: "IX_DocUploadedFiles_ProfileId",
                table: "DocUploadedFiles",
                column: "ProfileId");
        }
    }
}
