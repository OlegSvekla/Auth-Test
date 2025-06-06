using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ShuttleX.Meas.Geos;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddPointOfInterestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoManifestBlobs_Profiles_ProfileId",
                table: "VideoManifestBlobs");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoToMapPointLinqs_MapPointOfInterestTypes_MapPointOfInte~",
                table: "VideoToMapPointLinqs");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoToMapPointLinqs_VideoManifestBlobs_VideoManifestBlobId",
                table: "VideoToMapPointLinqs");

            migrationBuilder.DropTable(
                name: "MapPointOfInterestTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoManifestBlobs",
                table: "VideoManifestBlobs");

            migrationBuilder.DropColumn(
                name: "ManifestType",
                table: "VideoManifestBlobs");

            migrationBuilder.RenameTable(
                name: "VideoManifestBlobs",
                newName: "TranscodeVideoBlobs");

            migrationBuilder.RenameColumn(
                name: "MapPointOfInterestTypeId",
                table: "VideoToMapPointLinqs",
                newName: "PointOfInterestId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoToMapPointLinqs_MapPointOfInterestTypeId",
                table: "VideoToMapPointLinqs",
                newName: "IX_VideoToMapPointLinqs_PointOfInterestId");

            migrationBuilder.RenameColumn(
                name: "FullBlobUrl",
                table: "TranscodeVideoBlobs",
                newName: "BlobUrl");

            migrationBuilder.RenameIndex(
                name: "IX_VideoManifestBlobs_ProfileId",
                table: "TranscodeVideoBlobs",
                newName: "IX_TranscodeVideoBlobs_ProfileId");

            migrationBuilder.AddColumn<Guid>(
                name: "PointOfInterestCategoryId",
                table: "VideoToMapPointLinqs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "BlobType",
                table: "TranscodeVideoBlobs",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranscodeVideoBlobs",
                table: "TranscodeVideoBlobs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PointOfInterestCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterestCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointOfInterests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PointGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    EmojiFeKey = table.Column<string>(type: "text", nullable: true),
                    BackgroundGradientColor = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointOfInterestPhotoBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: false),
                    PointOfInterestId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterestPhotoBlobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfInterestPhotoBlobs_PointOfInterests_PointOfInterestId",
                        column: x => x.PointOfInterestId,
                        principalTable: "PointOfInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoToMapPointLinqs_PointOfInterestCategoryId",
                table: "VideoToMapPointLinqs",
                column: "PointOfInterestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterestPhotoBlobs_PointOfInterestId",
                table: "PointOfInterestPhotoBlobs",
                column: "PointOfInterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranscodeVideoBlobs_Profiles_ProfileId",
                table: "TranscodeVideoBlobs",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoToMapPointLinqs_PointOfInterestCategories_PointOfInter~",
                table: "VideoToMapPointLinqs",
                column: "PointOfInterestCategoryId",
                principalTable: "PointOfInterestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoToMapPointLinqs_PointOfInterests_PointOfInterestId",
                table: "VideoToMapPointLinqs",
                column: "PointOfInterestId",
                principalTable: "PointOfInterests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoToMapPointLinqs_TranscodeVideoBlobs_VideoManifestBlobId",
                table: "VideoToMapPointLinqs",
                column: "VideoManifestBlobId",
                principalTable: "TranscodeVideoBlobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranscodeVideoBlobs_Profiles_ProfileId",
                table: "TranscodeVideoBlobs");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoToMapPointLinqs_PointOfInterestCategories_PointOfInter~",
                table: "VideoToMapPointLinqs");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoToMapPointLinqs_PointOfInterests_PointOfInterestId",
                table: "VideoToMapPointLinqs");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoToMapPointLinqs_TranscodeVideoBlobs_VideoManifestBlobId",
                table: "VideoToMapPointLinqs");

            migrationBuilder.DropTable(
                name: "PointOfInterestCategories");

            migrationBuilder.DropTable(
                name: "PointOfInterestPhotoBlobs");

            migrationBuilder.DropTable(
                name: "PointOfInterests");

            migrationBuilder.DropIndex(
                name: "IX_VideoToMapPointLinqs_PointOfInterestCategoryId",
                table: "VideoToMapPointLinqs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranscodeVideoBlobs",
                table: "TranscodeVideoBlobs");

            migrationBuilder.DropColumn(
                name: "PointOfInterestCategoryId",
                table: "VideoToMapPointLinqs");

            migrationBuilder.RenameTable(
                name: "TranscodeVideoBlobs",
                newName: "VideoManifestBlobs");

            migrationBuilder.RenameColumn(
                name: "PointOfInterestId",
                table: "VideoToMapPointLinqs",
                newName: "MapPointOfInterestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoToMapPointLinqs_PointOfInterestId",
                table: "VideoToMapPointLinqs",
                newName: "IX_VideoToMapPointLinqs_MapPointOfInterestTypeId");

            migrationBuilder.RenameColumn(
                name: "BlobUrl",
                table: "VideoManifestBlobs",
                newName: "FullBlobUrl");

            migrationBuilder.RenameIndex(
                name: "IX_TranscodeVideoBlobs_ProfileId",
                table: "VideoManifestBlobs",
                newName: "IX_VideoManifestBlobs_ProfileId");

            migrationBuilder.AlterColumn<int>(
                name: "BlobType",
                table: "VideoManifestBlobs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ManifestType",
                table: "VideoManifestBlobs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoManifestBlobs",
                table: "VideoManifestBlobs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MapPointOfInterestTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapPointOfInterestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapPointOfInterestTypes_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapPointOfInterestTypes_ZoneId",
                table: "MapPointOfInterestTypes",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoManifestBlobs_Profiles_ProfileId",
                table: "VideoManifestBlobs",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoToMapPointLinqs_MapPointOfInterestTypes_MapPointOfInte~",
                table: "VideoToMapPointLinqs",
                column: "MapPointOfInterestTypeId",
                principalTable: "MapPointOfInterestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoToMapPointLinqs_VideoManifestBlobs_VideoManifestBlobId",
                table: "VideoToMapPointLinqs",
                column: "VideoManifestBlobId",
                principalTable: "VideoManifestBlobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
