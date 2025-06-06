using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePointOfInterestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoToMapPointLinqs");

            migrationBuilder.DropTable(
                name: "TranscodeVideoBlobs");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "PointOfInterestPhotoBlobs",
                newName: "ContentType");

            migrationBuilder.AddColumn<string>(
                name: "BlobName",
                table: "PointOfInterestPhotoBlobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlobType",
                table: "PointOfInterestPhotoBlobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlobUrl",
                table: "PointOfInterestPhotoBlobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContainerName",
                table: "PointOfInterestPhotoBlobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VideoOnDemandBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlobType = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    ContainerName = table.Column<string>(type: "text", nullable: false),
                    BlobName = table.Column<string>(type: "text", nullable: false),
                    BlobUrl = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoOnDemandBlobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoOnDemands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    VerificationStatus = table.Column<string>(type: "text", nullable: false),
                    VideoOnDemandBlobId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoOnDemands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoOnDemands_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoOnDemands_VideoOnDemandBlobs_VideoOnDemandBlobId",
                        column: x => x.VideoOnDemandBlobId,
                        principalTable: "VideoOnDemandBlobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PointOfInterestToVodVideoLinqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PointOfInterestCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    VideoOnDemandId = table.Column<Guid>(type: "uuid", nullable: false),
                    PointOfInterestId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterestToVodVideoLinqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfInterestToVodVideoLinqs_PointOfInterestCategories_Po~",
                        column: x => x.PointOfInterestCategoryId,
                        principalTable: "PointOfInterestCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointOfInterestToVodVideoLinqs_PointOfInterests_PointOfInte~",
                        column: x => x.PointOfInterestId,
                        principalTable: "PointOfInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointOfInterestToVodVideoLinqs_VideoOnDemands_VideoOnDemand~",
                        column: x => x.VideoOnDemandId,
                        principalTable: "VideoOnDemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterestToVodVideoLinqs_PointOfInterestCategoryId",
                table: "PointOfInterestToVodVideoLinqs",
                column: "PointOfInterestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterestToVodVideoLinqs_PointOfInterestId",
                table: "PointOfInterestToVodVideoLinqs",
                column: "PointOfInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterestToVodVideoLinqs_VideoOnDemandId",
                table: "PointOfInterestToVodVideoLinqs",
                column: "VideoOnDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoOnDemands_ProfileId",
                table: "VideoOnDemands",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoOnDemands_VideoOnDemandBlobId",
                table: "VideoOnDemands",
                column: "VideoOnDemandBlobId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointOfInterestToVodVideoLinqs");

            migrationBuilder.DropTable(
                name: "VideoOnDemands");

            migrationBuilder.DropTable(
                name: "VideoOnDemandBlobs");

            migrationBuilder.DropColumn(
                name: "BlobName",
                table: "PointOfInterestPhotoBlobs");

            migrationBuilder.DropColumn(
                name: "BlobType",
                table: "PointOfInterestPhotoBlobs");

            migrationBuilder.DropColumn(
                name: "BlobUrl",
                table: "PointOfInterestPhotoBlobs");

            migrationBuilder.DropColumn(
                name: "ContainerName",
                table: "PointOfInterestPhotoBlobs");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "PointOfInterestPhotoBlobs",
                newName: "PhotoUrl");

            migrationBuilder.CreateTable(
                name: "TranscodeVideoBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlobName = table.Column<string>(type: "text", nullable: false),
                    BlobType = table.Column<string>(type: "text", nullable: false),
                    BlobUrl = table.Column<string>(type: "text", nullable: false),
                    ContainerName = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    VerificationStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranscodeVideoBlobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranscodeVideoBlobs_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoToMapPointLinqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PointOfInterestCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    PointOfInterestId = table.Column<Guid>(type: "uuid", nullable: false),
                    VideoManifestBlobId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoToMapPointLinqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoToMapPointLinqs_PointOfInterestCategories_PointOfInter~",
                        column: x => x.PointOfInterestCategoryId,
                        principalTable: "PointOfInterestCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoToMapPointLinqs_PointOfInterests_PointOfInterestId",
                        column: x => x.PointOfInterestId,
                        principalTable: "PointOfInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoToMapPointLinqs_TranscodeVideoBlobs_VideoManifestBlobId",
                        column: x => x.VideoManifestBlobId,
                        principalTable: "TranscodeVideoBlobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranscodeVideoBlobs_ProfileId",
                table: "TranscodeVideoBlobs",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoToMapPointLinqs_PointOfInterestCategoryId",
                table: "VideoToMapPointLinqs",
                column: "PointOfInterestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoToMapPointLinqs_PointOfInterestId",
                table: "VideoToMapPointLinqs",
                column: "PointOfInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoToMapPointLinqs_VideoManifestBlobId",
                table: "VideoToMapPointLinqs",
                column: "VideoManifestBlobId");
        }
    }
}
