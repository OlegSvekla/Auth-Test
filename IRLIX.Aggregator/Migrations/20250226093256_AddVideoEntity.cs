using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapPointOfInterestTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "VideoManifestBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlobType = table.Column<int>(type: "integer", nullable: false),
                    ManifestType = table.Column<int>(type: "integer", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    ContainerName = table.Column<string>(type: "text", nullable: false),
                    BlobName = table.Column<string>(type: "text", nullable: false),
                    FullBlobUrl = table.Column<string>(type: "text", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    VerificationStatus = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoManifestBlobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoManifestBlobs_Profiles_ProfileId",
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
                    MapPointOfInterestTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    VideoManifestBlobId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoToMapPointLinqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoToMapPointLinqs_MapPointOfInterestTypes_MapPointOfInte~",
                        column: x => x.MapPointOfInterestTypeId,
                        principalTable: "MapPointOfInterestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoToMapPointLinqs_VideoManifestBlobs_VideoManifestBlobId",
                        column: x => x.VideoManifestBlobId,
                        principalTable: "VideoManifestBlobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapPointOfInterestTypes_ZoneId",
                table: "MapPointOfInterestTypes",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoManifestBlobs_ProfileId",
                table: "VideoManifestBlobs",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoToMapPointLinqs_MapPointOfInterestTypeId",
                table: "VideoToMapPointLinqs",
                column: "MapPointOfInterestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoToMapPointLinqs_VideoManifestBlobId",
                table: "VideoToMapPointLinqs",
                column: "VideoManifestBlobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoToMapPointLinqs");

            migrationBuilder.DropTable(
                name: "MapPointOfInterestTypes");

            migrationBuilder.DropTable(
                name: "VideoManifestBlobs");
        }
    }
}
