using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using ShuttleX.Aggregator.Ef.Entities.Pois.PoiPart.PoiAttributes;
using ShuttleX.Meas.Geos;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessAndVoyagerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoiPhotoBlobs_Pois_PoiId",
                table: "PoiPhotoBlobs");

            migrationBuilder.DropTable(
                name: "PoiToVodLinqs");

            migrationBuilder.DropIndex(
                name: "IX_PoiPhotoBlobs_PoiId",
                table: "PoiPhotoBlobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoiCategories",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "BackgroundGradientColor",
                table: "Pois");

            migrationBuilder.DropColumn(
                name: "EmojiFeKey",
                table: "Pois");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pois");

            migrationBuilder.DropColumn(
                name: "PoiId",
                table: "PoiPhotoBlobs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PoiCategories");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "PoiCategories",
                newName: "category_name");

            migrationBuilder.AddColumn<string>(
                name: "category_id",
                table: "PoiCategories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "category_label",
                table: "PoiCategories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "category_level",
                table: "PoiCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "level1_category_id",
                table: "PoiCategories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "level1_category_name",
                table: "PoiCategories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "level2_category_id",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level2_category_name",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level3_category_id",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level3_category_name",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level4_category_id",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level4_category_name",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level5_category_id",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level5_category_name",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level6_category_id",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level6_category_name",
                table: "PoiCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoiCategories",
                table: "PoiCategories",
                column: "category_id");

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxId = table.Column<string>(type: "text", nullable: true),
                    LegalName = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    BusinessModel = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    SocialMediaLinks = table.Column<string[]>(type: "text[]", nullable: false),
                    IsFranchise = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    OperationalStatus = table.Column<string>(type: "text", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiCategoryToPoiLinks",
                columns: table => new
                {
                    PoiFoursquareCategoryId = table.Column<string>(type: "text", nullable: false),
                    PoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiCategoryToPoiLinks", x => new { x.PoiFoursquareCategoryId, x.PoiId });
                    table.ForeignKey(
                        name: "FK_PoiCategoryToPoiLinks_PoiCategories_PoiFoursquareCategoryId",
                        column: x => x.PoiFoursquareCategoryId,
                        principalTable: "PoiCategories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiCategoryToPoiLinks_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiEntertainmentParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TicketUrl = table.Column<string>(type: "text", nullable: true),
                    IsOutdoor = table.Column<bool>(type: "boolean", nullable: false),
                    AgeRestriction = table.Column<int>(type: "integer", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Fax = table.Column<string>(type: "text", nullable: true),
                    Telephone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Timezone = table.Column<string>(type: "text", nullable: true),
                    Popularity = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalPhotos = table.Column<int>(type: "integer", nullable: false),
                    TotalRatings = table.Column<int>(type: "integer", nullable: false),
                    TotalTips = table.Column<int>(type: "integer", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Geocodes = table.Column<PoiGeocodeFeature>(type: "jsonb", nullable: true),
                    WorkingHours = table.Column<PoiWorkingHoursFeature>(type: "jsonb", nullable: true),
                    Location = table.Column<PoiLocationFeature>(type: "jsonb", nullable: true),
                    RelatedPlaces = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    SocialMedia = table.Column<PoiSocialMediaFeature>(type: "jsonb", nullable: true),
                    Tips = table.Column<IList<PoiTipFeature>>(type: "jsonb", nullable: false),
                    FsqId = table.Column<string>(type: "text", nullable: true),
                    FsqStoreId = table.Column<string>(type: "text", nullable: true),
                    FsqPopularity = table.Column<int>(type: "integer", nullable: true),
                    FsqPrice = table.Column<int>(type: "integer", nullable: true),
                    FsqRating = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiEntertainmentParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoiEventParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventType = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SpecificLocation = table.Column<Geo>(type: "jsonb", nullable: true),
                    ExpectedAttendees = table.Column<int>(type: "integer", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Fax = table.Column<string>(type: "text", nullable: true),
                    Telephone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Timezone = table.Column<string>(type: "text", nullable: true),
                    Popularity = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalPhotos = table.Column<int>(type: "integer", nullable: false),
                    TotalRatings = table.Column<int>(type: "integer", nullable: false),
                    TotalTips = table.Column<int>(type: "integer", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Geocodes = table.Column<PoiGeocodeFeature>(type: "jsonb", nullable: true),
                    WorkingHours = table.Column<PoiWorkingHoursFeature>(type: "jsonb", nullable: true),
                    Location = table.Column<PoiLocationFeature>(type: "jsonb", nullable: true),
                    RelatedPlaces = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    SocialMedia = table.Column<PoiSocialMediaFeature>(type: "jsonb", nullable: true),
                    Tips = table.Column<IList<PoiTipFeature>>(type: "jsonb", nullable: false),
                    FsqId = table.Column<string>(type: "text", nullable: true),
                    FsqStoreId = table.Column<string>(type: "text", nullable: true),
                    FsqPopularity = table.Column<int>(type: "integer", nullable: true),
                    FsqPrice = table.Column<int>(type: "integer", nullable: true),
                    FsqRating = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiEventParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoiFoodParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuUrl = table.Column<string>(type: "text", nullable: true),
                    Tastes = table.Column<string[]>(type: "text[]", nullable: false),
                    VenueRealityBucket = table.Column<string>(type: "text", nullable: true),
                    ClosedBucket = table.Column<string>(type: "text", nullable: true),
                    FsqPopularity = table.Column<int>(type: "integer", nullable: true),
                    FsqPrice = table.Column<int>(type: "integer", nullable: true),
                    FsqRating = table.Column<decimal>(type: "numeric", nullable: true),
                    Features = table.Column<FoodPoiFeature>(type: "jsonb", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Fax = table.Column<string>(type: "text", nullable: true),
                    Telephone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Timezone = table.Column<string>(type: "text", nullable: true),
                    Popularity = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalPhotos = table.Column<int>(type: "integer", nullable: false),
                    TotalRatings = table.Column<int>(type: "integer", nullable: false),
                    TotalTips = table.Column<int>(type: "integer", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Geocodes = table.Column<PoiGeocodeFeature>(type: "jsonb", nullable: true),
                    WorkingHours = table.Column<PoiWorkingHoursFeature>(type: "jsonb", nullable: true),
                    Location = table.Column<PoiLocationFeature>(type: "jsonb", nullable: true),
                    RelatedPlaces = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    SocialMedia = table.Column<PoiSocialMediaFeature>(type: "jsonb", nullable: true),
                    Tips = table.Column<IList<PoiTipFeature>>(type: "jsonb", nullable: false),
                    FsqId = table.Column<string>(type: "text", nullable: true),
                    FsqStoreId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiFoodParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoiHealthParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: true),
                    Specialties = table.Column<List<string>>(type: "jsonb", nullable: false),
                    AcceptsInsurance = table.Column<bool>(type: "boolean", nullable: false),
                    AcceptedInsurances = table.Column<List<string>>(type: "jsonb", nullable: false),
                    HasEmergencyServices = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Fax = table.Column<string>(type: "text", nullable: true),
                    Telephone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Timezone = table.Column<string>(type: "text", nullable: true),
                    Popularity = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalPhotos = table.Column<int>(type: "integer", nullable: false),
                    TotalRatings = table.Column<int>(type: "integer", nullable: false),
                    TotalTips = table.Column<int>(type: "integer", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Geocodes = table.Column<PoiGeocodeFeature>(type: "jsonb", nullable: true),
                    WorkingHours = table.Column<PoiWorkingHoursFeature>(type: "jsonb", nullable: true),
                    Location = table.Column<PoiLocationFeature>(type: "jsonb", nullable: true),
                    RelatedPlaces = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    SocialMedia = table.Column<PoiSocialMediaFeature>(type: "jsonb", nullable: true),
                    Tips = table.Column<IList<PoiTipFeature>>(type: "jsonb", nullable: false),
                    FsqId = table.Column<string>(type: "text", nullable: true),
                    FsqStoreId = table.Column<string>(type: "text", nullable: true),
                    FsqPopularity = table.Column<int>(type: "integer", nullable: true),
                    FsqPrice = table.Column<int>(type: "integer", nullable: true),
                    FsqRating = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiHealthParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoiOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EstimatedPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoiOffers_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EstimatedPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    IsPayed = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoiOrders_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiPayPurposeRestaurantBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReservationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ReservationTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PeopleAmount = table.Column<int>(type: "integer", nullable: false),
                    RestaurantOfferStatus = table.Column<int>(type: "integer", nullable: false),
                    RestaurantOrderStatus = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiPayPurposeRestaurantBookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoiPayPurposeTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiPayPurposeTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoiProvisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProvisionType = table.Column<int>(type: "integer", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiProvisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileBusinesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxIdentificationNumber = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: true),
                    RegisteredCountry = table.Column<string>(type: "text", nullable: false),
                    BusinessJobTitle = table.Column<int>(type: "integer", nullable: false),
                    BusinessAccessLevel = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileBusinesses_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voyagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voyagers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessClouserNodes",
                columns: table => new
                {
                    AncestorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescendantId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessClouserNodes", x => new { x.AncestorId, x.DescendantId });
                    table.ForeignKey(
                        name: "FK_BusinessClouserNodes_Businesses_AncestorId",
                        column: x => x.AncestorId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessClouserNodes_Businesses_DescendantId",
                        column: x => x.DescendantId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessToProfileToPoiLinks",
                columns: table => new
                {
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessToProfileToPoiLinks", x => new { x.BusinessId, x.ProfileId, x.PoiId });
                    table.ForeignKey(
                        name: "FK_BusinessToProfileToPoiLinks_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessToProfileToPoiLinks_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessToProfileToPoiLinks_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiToPoiEntertainmentPartLinks",
                columns: table => new
                {
                    PoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiEntertainmentPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiToPoiEntertainmentPartLinks", x => new { x.PoiId, x.PoiEntertainmentPartId });
                    table.ForeignKey(
                        name: "FK_PoiToPoiEntertainmentPartLinks_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiEntertainmentPartLinks_PoiEntertainmentParts_PoiEnt~",
                        column: x => x.PoiEntertainmentPartId,
                        principalTable: "PoiEntertainmentParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiEntertainmentPartLinks_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiToPoiEventPartLinks",
                columns: table => new
                {
                    PoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiEventPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiToPoiEventPartLinks", x => new { x.PoiId, x.PoiEventPartId });
                    table.ForeignKey(
                        name: "FK_PoiToPoiEventPartLinks_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiEventPartLinks_PoiEventParts_PoiEventPartId",
                        column: x => x.PoiEventPartId,
                        principalTable: "PoiEventParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiEventPartLinks_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiToPoiFoodPartLinks",
                columns: table => new
                {
                    PoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiFoodPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiToPoiFoodPartLinks", x => new { x.PoiId, x.PoiFoodPartId });
                    table.ForeignKey(
                        name: "FK_PoiToPoiFoodPartLinks_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiFoodPartLinks_PoiFoodParts_PoiFoodPartId",
                        column: x => x.PoiFoodPartId,
                        principalTable: "PoiFoodParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiFoodPartLinks_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiCategoryToPoiPartLinks",
                columns: table => new
                {
                    PoiFoursquareCategoryId = table.Column<string>(type: "text", nullable: false),
                    PoiPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartType = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PoiEntertainmentPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiEventPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiFoodPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiHealthPartEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiCategoryToPoiPartLinks", x => new { x.PoiFoursquareCategoryId, x.PoiPartId });
                    table.ForeignKey(
                        name: "FK_PoiCategoryToPoiPartLinks_PoiCategories_PoiFoursquareCatego~",
                        column: x => x.PoiFoursquareCategoryId,
                        principalTable: "PoiCategories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiCategoryToPoiPartLinks_PoiEntertainmentParts_PoiEntertai~",
                        column: x => x.PoiEntertainmentPartEntityId,
                        principalTable: "PoiEntertainmentParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiCategoryToPoiPartLinks_PoiEventParts_PoiEventPartEntityId",
                        column: x => x.PoiEventPartEntityId,
                        principalTable: "PoiEventParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiCategoryToPoiPartLinks_PoiFoodParts_PoiFoodPartEntityId",
                        column: x => x.PoiFoodPartEntityId,
                        principalTable: "PoiFoodParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiCategoryToPoiPartLinks_PoiHealthParts_PoiHealthPartEntit~",
                        column: x => x.PoiHealthPartEntityId,
                        principalTable: "PoiHealthParts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoiPartToPhotoLinks",
                columns: table => new
                {
                    PoiPhotoBlobId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartType = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PoiEntertainmentPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiEventPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiFoodPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiHealthPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiPartToPhotoLinks", x => new { x.PoiPartId, x.PoiPhotoBlobId });
                    table.ForeignKey(
                        name: "FK_PoiPartToPhotoLinks_PoiEntertainmentParts_PoiEntertainmentP~",
                        column: x => x.PoiEntertainmentPartEntityId,
                        principalTable: "PoiEntertainmentParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPhotoLinks_PoiEventParts_PoiEventPartEntityId",
                        column: x => x.PoiEventPartEntityId,
                        principalTable: "PoiEventParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPhotoLinks_PoiFoodParts_PoiFoodPartEntityId",
                        column: x => x.PoiFoodPartEntityId,
                        principalTable: "PoiFoodParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPhotoLinks_PoiHealthParts_PoiHealthPartEntityId",
                        column: x => x.PoiHealthPartEntityId,
                        principalTable: "PoiHealthParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPhotoLinks_PoiPhotoBlobs_PoiPhotoBlobId",
                        column: x => x.PoiPhotoBlobId,
                        principalTable: "PoiPhotoBlobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiPartToVodLinks",
                columns: table => new
                {
                    VodId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartType = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PoiEntertainmentPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiEventPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiFoodPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiHealthPartEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiPartToVodLinks", x => new { x.PoiPartId, x.VodId });
                    table.ForeignKey(
                        name: "FK_PoiPartToVodLinks_PoiEntertainmentParts_PoiEntertainmentPar~",
                        column: x => x.PoiEntertainmentPartEntityId,
                        principalTable: "PoiEntertainmentParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToVodLinks_PoiEventParts_PoiEventPartEntityId",
                        column: x => x.PoiEventPartEntityId,
                        principalTable: "PoiEventParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToVodLinks_PoiFoodParts_PoiFoodPartEntityId",
                        column: x => x.PoiFoodPartEntityId,
                        principalTable: "PoiFoodParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToVodLinks_PoiHealthParts_PoiHealthPartEntityId",
                        column: x => x.PoiHealthPartEntityId,
                        principalTable: "PoiHealthParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToVodLinks_Vods_VodId",
                        column: x => x.VodId,
                        principalTable: "Vods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiToPoiHealthPartLinks",
                columns: table => new
                {
                    PoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiHealthPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiToPoiHealthPartLinks", x => new { x.PoiId, x.PoiHealthPartId });
                    table.ForeignKey(
                        name: "FK_PoiToPoiHealthPartLinks_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiHealthPartLinks_PoiHealthParts_PoiHealthPartId",
                        column: x => x.PoiHealthPartId,
                        principalTable: "PoiHealthParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToPoiHealthPartLinks_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiPartToPoiProvisionLinks",
                columns: table => new
                {
                    PoiProvisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartType = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PoiEntertainmentPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiEventPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiFoodPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiHealthPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiPartToPoiProvisionLinks", x => new { x.PoiPartId, x.PoiProvisionId });
                    table.ForeignKey(
                        name: "FK_PoiPartToPoiProvisionLinks_PoiEntertainmentParts_PoiEnterta~",
                        column: x => x.PoiEntertainmentPartEntityId,
                        principalTable: "PoiEntertainmentParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPoiProvisionLinks_PoiEventParts_PoiEventPartEntity~",
                        column: x => x.PoiEventPartEntityId,
                        principalTable: "PoiEventParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPoiProvisionLinks_PoiFoodParts_PoiFoodPartEntityId",
                        column: x => x.PoiFoodPartEntityId,
                        principalTable: "PoiFoodParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPoiProvisionLinks_PoiHealthParts_PoiHealthPartEnti~",
                        column: x => x.PoiHealthPartEntityId,
                        principalTable: "PoiHealthParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiPartToPoiProvisionLinks_PoiProvisions_PoiProvisionId",
                        column: x => x.PoiProvisionId,
                        principalTable: "PoiProvisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiProvisionToPoiPaymentLinks",
                columns: table => new
                {
                    PoiProvisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiOfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProvisionQuantity = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiProvisionToPoiPaymentLinks", x => new { x.PoiProvisionId, x.PoiOfferId });
                    table.ForeignKey(
                        name: "FK_PoiProvisionToPoiPaymentLinks_PoiOffers_PoiOfferId",
                        column: x => x.PoiOfferId,
                        principalTable: "PoiOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiProvisionToPoiPaymentLinks_PoiOrders_PoiOrderId",
                        column: x => x.PoiOrderId,
                        principalTable: "PoiOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiProvisionToPoiPaymentLinks_PoiProvisions_PoiProvisionId",
                        column: x => x.PoiProvisionId,
                        principalTable: "PoiProvisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiToOfferOrderLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VoyagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiOfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    PartType = table.Column<int>(type: "integer", nullable: false),
                    PoiPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPayPurposeType = table.Column<int>(type: "integer", nullable: false),
                    PoiPayPurposeId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoyagerPaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PoiEntertainmentPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiEventPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiFoodPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoiHealthPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiToOfferOrderLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_PoiEntertainmentParts_PoiEntertainment~",
                        column: x => x.PoiEntertainmentPartEntityId,
                        principalTable: "PoiEntertainmentParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_PoiEventParts_PoiEventPartEntityId",
                        column: x => x.PoiEventPartEntityId,
                        principalTable: "PoiEventParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_PoiFoodParts_PoiFoodPartEntityId",
                        column: x => x.PoiFoodPartEntityId,
                        principalTable: "PoiFoodParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_PoiHealthParts_PoiHealthPartEntityId",
                        column: x => x.PoiHealthPartEntityId,
                        principalTable: "PoiHealthParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_PoiOffers_PoiOfferId",
                        column: x => x.PoiOfferId,
                        principalTable: "PoiOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_PoiOrders_PoiOrderId",
                        column: x => x.PoiOrderId,
                        principalTable: "PoiOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoiToOfferOrderLinks_Voyagers_VoyagerId",
                        column: x => x.VoyagerId,
                        principalTable: "Voyagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoyagerToChatLinks",
                columns: table => new
                {
                    VoyagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoyagerToChatLinks", x => new { x.VoyagerId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_VoyagerToChatLinks_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoyagerToChatLinks_Voyagers_VoyagerId",
                        column: x => x.VoyagerId,
                        principalTable: "Voyagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoyagerToPoiLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VoyagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiPartType = table.Column<int>(type: "integer", nullable: false),
                    PoiPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoyagerToPoiLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoyagerToPoiLinks_Voyagers_VoyagerId",
                        column: x => x.VoyagerId,
                        principalTable: "Voyagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessClouserNodes_DescendantId",
                table: "BusinessClouserNodes",
                column: "DescendantId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessToProfileToPoiLinks_PoiId",
                table: "BusinessToProfileToPoiLinks",
                column: "PoiId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessToProfileToPoiLinks_ProfileId",
                table: "BusinessToProfileToPoiLinks",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_ZoneId",
                table: "Businesses",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiCategoryToPoiLinks_PoiId",
                table: "PoiCategoryToPoiLinks",
                column: "PoiId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiCategoryToPoiPartLinks_PoiEntertainmentPartEntityId",
                table: "PoiCategoryToPoiPartLinks",
                column: "PoiEntertainmentPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiCategoryToPoiPartLinks_PoiEventPartEntityId",
                table: "PoiCategoryToPoiPartLinks",
                column: "PoiEventPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiCategoryToPoiPartLinks_PoiFoodPartEntityId",
                table: "PoiCategoryToPoiPartLinks",
                column: "PoiFoodPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiCategoryToPoiPartLinks_PoiHealthPartEntityId",
                table: "PoiCategoryToPoiPartLinks",
                column: "PoiHealthPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiCategoryToPoiPartLinks_PoiPartId",
                table: "PoiCategoryToPoiPartLinks",
                column: "PoiPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiOffers_ChatId",
                table: "PoiOffers",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiOrders_ChatId",
                table: "PoiOrders",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPhotoLinks_PoiEntertainmentPartEntityId",
                table: "PoiPartToPhotoLinks",
                column: "PoiEntertainmentPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPhotoLinks_PoiEventPartEntityId",
                table: "PoiPartToPhotoLinks",
                column: "PoiEventPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPhotoLinks_PoiFoodPartEntityId",
                table: "PoiPartToPhotoLinks",
                column: "PoiFoodPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPhotoLinks_PoiHealthPartEntityId",
                table: "PoiPartToPhotoLinks",
                column: "PoiHealthPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPhotoLinks_PoiPhotoBlobId",
                table: "PoiPartToPhotoLinks",
                column: "PoiPhotoBlobId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPoiProvisionLinks_PoiEntertainmentPartEntityId",
                table: "PoiPartToPoiProvisionLinks",
                column: "PoiEntertainmentPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPoiProvisionLinks_PoiEventPartEntityId",
                table: "PoiPartToPoiProvisionLinks",
                column: "PoiEventPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPoiProvisionLinks_PoiFoodPartEntityId",
                table: "PoiPartToPoiProvisionLinks",
                column: "PoiFoodPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPoiProvisionLinks_PoiHealthPartEntityId",
                table: "PoiPartToPoiProvisionLinks",
                column: "PoiHealthPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToPoiProvisionLinks_PoiProvisionId",
                table: "PoiPartToPoiProvisionLinks",
                column: "PoiProvisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToVodLinks_PoiEntertainmentPartEntityId",
                table: "PoiPartToVodLinks",
                column: "PoiEntertainmentPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToVodLinks_PoiEventPartEntityId",
                table: "PoiPartToVodLinks",
                column: "PoiEventPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToVodLinks_PoiFoodPartEntityId",
                table: "PoiPartToVodLinks",
                column: "PoiFoodPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToVodLinks_PoiHealthPartEntityId",
                table: "PoiPartToVodLinks",
                column: "PoiHealthPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiPartToVodLinks_VodId",
                table: "PoiPartToVodLinks",
                column: "VodId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiProvisionToPoiPaymentLinks_PoiOfferId",
                table: "PoiProvisionToPoiPaymentLinks",
                column: "PoiOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiProvisionToPoiPaymentLinks_PoiOrderId",
                table: "PoiProvisionToPoiPaymentLinks",
                column: "PoiOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_BusinessId",
                table: "PoiToOfferOrderLinks",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_PoiEntertainmentPartEntityId",
                table: "PoiToOfferOrderLinks",
                column: "PoiEntertainmentPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_PoiEventPartEntityId",
                table: "PoiToOfferOrderLinks",
                column: "PoiEventPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_PoiFoodPartEntityId",
                table: "PoiToOfferOrderLinks",
                column: "PoiFoodPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_PoiHealthPartEntityId",
                table: "PoiToOfferOrderLinks",
                column: "PoiHealthPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_PoiOfferId_PoiOrderId",
                table: "PoiToOfferOrderLinks",
                columns: new[] { "PoiOfferId", "PoiOrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_PoiOrderId",
                table: "PoiToOfferOrderLinks",
                column: "PoiOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_VoyagerId_BusinessId",
                table: "PoiToOfferOrderLinks",
                columns: new[] { "VoyagerId", "BusinessId" });

            migrationBuilder.CreateIndex(
                name: "IX_PoiToOfferOrderLinks_VoyagerPaymentTransactionId",
                table: "PoiToOfferOrderLinks",
                column: "VoyagerPaymentTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiEntertainmentPartLinks_BusinessId",
                table: "PoiToPoiEntertainmentPartLinks",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiEntertainmentPartLinks_PoiEntertainmentPartId",
                table: "PoiToPoiEntertainmentPartLinks",
                column: "PoiEntertainmentPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiEventPartLinks_BusinessId",
                table: "PoiToPoiEventPartLinks",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiEventPartLinks_PoiEventPartId",
                table: "PoiToPoiEventPartLinks",
                column: "PoiEventPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiFoodPartLinks_BusinessId",
                table: "PoiToPoiFoodPartLinks",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiFoodPartLinks_PoiFoodPartId",
                table: "PoiToPoiFoodPartLinks",
                column: "PoiFoodPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiHealthPartLinks_BusinessId",
                table: "PoiToPoiHealthPartLinks",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToPoiHealthPartLinks_PoiHealthPartId",
                table: "PoiToPoiHealthPartLinks",
                column: "PoiHealthPartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileBusinesses_ProfileId",
                table: "ProfileBusinesses",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VoyagerToChatLinks_ChatId",
                table: "VoyagerToChatLinks",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_VoyagerToPoiLinks_VoyagerId",
                table: "VoyagerToPoiLinks",
                column: "VoyagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessClouserNodes");

            migrationBuilder.DropTable(
                name: "BusinessToProfileToPoiLinks");

            migrationBuilder.DropTable(
                name: "PoiCategoryToPoiLinks");

            migrationBuilder.DropTable(
                name: "PoiCategoryToPoiPartLinks");

            migrationBuilder.DropTable(
                name: "PoiPartToPhotoLinks");

            migrationBuilder.DropTable(
                name: "PoiPartToPoiProvisionLinks");

            migrationBuilder.DropTable(
                name: "PoiPartToVodLinks");

            migrationBuilder.DropTable(
                name: "PoiPayPurposeRestaurantBookings");

            migrationBuilder.DropTable(
                name: "PoiPayPurposeTickets");

            migrationBuilder.DropTable(
                name: "PoiProvisionToPoiPaymentLinks");

            migrationBuilder.DropTable(
                name: "PoiToOfferOrderLinks");

            migrationBuilder.DropTable(
                name: "PoiToPoiEntertainmentPartLinks");

            migrationBuilder.DropTable(
                name: "PoiToPoiEventPartLinks");

            migrationBuilder.DropTable(
                name: "PoiToPoiFoodPartLinks");

            migrationBuilder.DropTable(
                name: "PoiToPoiHealthPartLinks");

            migrationBuilder.DropTable(
                name: "ProfileBusinesses");

            migrationBuilder.DropTable(
                name: "VoyagerToChatLinks");

            migrationBuilder.DropTable(
                name: "VoyagerToPoiLinks");

            migrationBuilder.DropTable(
                name: "PoiProvisions");

            migrationBuilder.DropTable(
                name: "PoiOffers");

            migrationBuilder.DropTable(
                name: "PoiOrders");

            migrationBuilder.DropTable(
                name: "PoiEntertainmentParts");

            migrationBuilder.DropTable(
                name: "PoiEventParts");

            migrationBuilder.DropTable(
                name: "PoiFoodParts");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "PoiHealthParts");

            migrationBuilder.DropTable(
                name: "Voyagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoiCategories",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "category_label",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "category_level",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level1_category_id",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level1_category_name",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level2_category_id",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level2_category_name",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level3_category_id",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level3_category_name",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level4_category_id",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level4_category_name",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level5_category_id",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level5_category_name",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level6_category_id",
                table: "PoiCategories");

            migrationBuilder.DropColumn(
                name: "level6_category_name",
                table: "PoiCategories");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "PoiCategories",
                newName: "CategoryName");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundGradientColor",
                table: "Pois",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmojiFeKey",
                table: "Pois",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pois",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PoiId",
                table: "PoiPhotoBlobs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PoiCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoiCategories",
                table: "PoiCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PoiToVodLinqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    VodId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiToVodLinqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoiToVodLinqs_PoiCategories_PoiCategoryId",
                        column: x => x.PoiCategoryId,
                        principalTable: "PoiCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToVodLinqs_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoiToVodLinqs_Vods_VodId",
                        column: x => x.VodId,
                        principalTable: "Vods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoiPhotoBlobs_PoiId",
                table: "PoiPhotoBlobs",
                column: "PoiId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToVodLinqs_PoiCategoryId",
                table: "PoiToVodLinqs",
                column: "PoiCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToVodLinqs_PoiId",
                table: "PoiToVodLinqs",
                column: "PoiId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiToVodLinqs_VodId",
                table: "PoiToVodLinqs",
                column: "VodId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoiPhotoBlobs_Pois_PoiId",
                table: "PoiPhotoBlobs",
                column: "PoiId",
                principalTable: "Pois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
