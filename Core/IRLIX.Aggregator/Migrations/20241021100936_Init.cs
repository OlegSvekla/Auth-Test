using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShuttleX.Meas.Geos;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    LockoutReason = table.Column<string>(type: "text", nullable: true),
                    LockoutCreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutCreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MerchantAccount = table.Column<string>(type: "text", nullable: false),
                    OrderReference = table.Column<string>(type: "text", nullable: false),
                    MerchantSignature = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    AuthCode = table.Column<string>(type: "text", nullable: true),
                    ProcessingDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CardPlan = table.Column<string>(type: "text", nullable: false),
                    CardType = table.Column<string>(type: "text", nullable: false),
                    IssuerBankCountry = table.Column<string>(type: "text", nullable: false),
                    IssuerBankName = table.Column<string>(type: "text", nullable: false),
                    RecToken = table.Column<string>(type: "text", nullable: false),
                    TransactionStatus = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    ReasonCode = table.Column<int>(type: "integer", nullable: false),
                    Fee = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentSystem = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoundPlacesML",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullAddress = table.Column<string>(type: "text", nullable: false),
                    Place = table.Column<string>(type: "text", nullable: false),
                    Geo = table.Column<Geo>(type: "jsonb", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    CityOrLocality = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundPlacesML", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    NotificationTypes = table.Column<int[]>(type: "integer[]", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSystemRecognizer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentSystemName = table.Column<string>(type: "text", nullable: true),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSystemRecognizer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MerchantAccount = table.Column<string>(type: "text", nullable: false),
                    OrderReference = table.Column<string>(type: "text", nullable: false),
                    TransactionStatus = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    ReasonCode = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SagaPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SagaStartTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SagaCompletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SagaPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeContractorCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: false),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerStripeId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "jsonb", nullable: true),
                    Metadata = table.Column<string>(type: "jsonb", nullable: true),
                    PreferredLocales = table.Column<string>(type: "jsonb", nullable: true),
                    DefaultPaymentMethodId = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeContractorCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripePassengerCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: false),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CustomerStripeId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "jsonb", nullable: true),
                    Metadata = table.Column<string>(type: "jsonb", nullable: true),
                    PreferredLocales = table.Column<string>(type: "jsonb", nullable: true),
                    DefaultPaymentMethodId = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePassengerCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsoName = table.Column<string>(type: "text", nullable: true),
                    ParentEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationType = table.Column<string>(type: "text", nullable: false),
                    ContractorWorkDuringDayMaxTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Zones_ParentEntityId",
                        column: x => x.ParentEntityId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    TotalLikesCount = table.Column<int>(type: "integer", nullable: false),
                    TotalDislikesCount = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    RequireDocumentsUpdate = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: false),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenExpiresAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedSessionId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SagaStepPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StepStatus = table.Column<string>(type: "text", nullable: false),
                    StepStartTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StepEndTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: true),
                    SagaPaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SagaStepPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SagaStepPayments_SagaPayments_SagaPaymentId",
                        column: x => x.SagaPaymentId,
                        principalTable: "SagaPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StripeContractorPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: false),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentMethodId = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    PaymentStatusDescription = table.Column<string>(type: "text", nullable: true),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    JsonAdditionalData = table.Column<string>(type: "jsonb", nullable: true),
                    StripeContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeContractorPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeContractorPaymentTransactions_StripeContractorCustome~",
                        column: x => x.StripeContractorCustomerId,
                        principalTable: "StripeContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StripePassengerPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: false),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentMethodId = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    PaymentStatusDescription = table.Column<string>(type: "text", nullable: true),
                    InitializeTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedTransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    JsonAdditionalData = table.Column<string>(type: "jsonb", nullable: true),
                    StripePassengerCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePassengerPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripePassengerPaymentTransactions_StripePassengerCustomers~",
                        column: x => x.StripePassengerCustomerId,
                        principalTable: "StripePassengerCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocMetadatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false),
                    FeKey = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    SubType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocMetadatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocMetadatas_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonGeos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonGeos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolygonGeos_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FeKey = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    BaseFare = table.Column<decimal>(type: "numeric", nullable: false),
                    TollFare = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPerKilometer = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPerMinute = table.Column<decimal>(type: "numeric", nullable: false),
                    MaximumFare = table.Column<decimal>(type: "numeric", nullable: false),
                    MinimumFare = table.Column<decimal>(type: "numeric", nullable: false),
                    DelayedTripCancelPenalty = table.Column<decimal>(type: "numeric", nullable: false),
                    ScheduledTripMinimumPenalty = table.Column<decimal>(type: "numeric", nullable: false),
                    FreeWaitingTimeMin = table.Column<int>(type: "integer", nullable: false),
                    PaidWaitingTimeFeePricePerMin = table.Column<decimal>(type: "numeric", nullable: false),
                    ServiceFee = table.Column<decimal>(type: "numeric", nullable: false),
                    BookingFee = table.Column<decimal>(type: "numeric", nullable: false),
                    AirportFees = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    MaxSeatsCount = table.Column<int>(type: "integer", nullable: false),
                    MaxLuggagesCount = table.Column<int>(type: "integer", nullable: false),
                    WaitingOfferForAcceptenceByContractorSec = table.Column<int>(type: "integer", nullable: false),
                    MaxDistanceToAllowArrivalForContractorMeter = table.Column<int>(type: "integer", nullable: false),
                    SearchRadiusMeter = table.Column<int>(type: "integer", nullable: false),
                    SearchRadiusFactors = table.Column<float[]>(type: "real[]", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tariffs_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZoneClosureTableNode",
                columns: table => new
                {
                    AncestorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescendantId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneClosureTableNode", x => new { x.AncestorId, x.DescendantId });
                    table.ForeignKey(
                        name: "FK_ZoneClosureTableNode_Zones_AncestorId",
                        column: x => x.AncestorId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZoneClosureTableNode_Zones_DescendantId",
                        column: x => x.DescendantId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoundPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullAddress = table.Column<string>(type: "text", nullable: false),
                    Place = table.Column<string>(type: "text", nullable: false),
                    Geo = table.Column<Geo>(type: "jsonb", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    CityOrLocality = table.Column<string>(type: "text", nullable: true),
                    RqGeo = table.Column<Geo>(type: "jsonb", nullable: true),
                    RqQuery = table.Column<string>(type: "text", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoundPlaces_Passengers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Passengers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PassengerCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassengerCustomers_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CardType = table.Column<string>(type: "text", nullable: false),
                    Issuer = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PaymentNetworkType = table.Column<string>(type: "text", nullable: true),
                    CardholderName = table.Column<string>(type: "text", nullable: true),
                    EncodedNumber = table.Column<string>(type: "text", nullable: false),
                    MaskedNumber = table.Column<string>(type: "text", nullable: false),
                    EncodedSecretNumber = table.Column<string>(type: "text", nullable: true),
                    ValidThruDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AccountOpeningDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocUploadedFiles",
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
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ProfileAvatars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileAvatars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileAvatars_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileEmails_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileFirstNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileFirstNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileFirstNames_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileGeoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Geo = table.Column<Geo>(type: "jsonb", nullable: false),
                    Angle = table.Column<double>(type: "double precision", nullable: true),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileGeoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileGeoEntity_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileLanguages_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileLastNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileLastNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileLastNames_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePhones_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileZones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileZones_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileZones_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignInAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    CodeHash = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignInAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignInAttempts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SignInAttempts_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeContractorSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "text", nullable: false),
                    IdempotencyKeyExpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    SubscriptionId = table.Column<string>(type: "text", nullable: false),
                    PriceId = table.Column<string>(type: "text", nullable: true),
                    SubscriptionType = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsContinues = table.Column<bool>(type: "boolean", nullable: false),
                    CanceledDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    JsonAdditionalData = table.Column<string>(type: "jsonb", nullable: true),
                    StripeContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StripeContractorPaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeContractorSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeContractorSubscriptions_StripeContractorCustomers_Str~",
                        column: x => x.StripeContractorCustomerId,
                        principalTable: "StripeContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StripeContractorSubscriptions_StripeContractorPaymentTransa~",
                        column: x => x.StripeContractorPaymentTransactionId,
                        principalTable: "StripeContractorPaymentTransactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocType = table.Column<int>(type: "integer", nullable: false),
                    ReviewerResponse = table.Column<string>(type: "text", nullable: true),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocMetadataId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlobIds = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_DocMetadatas_DocMetadataId",
                        column: x => x.DocMetadataId,
                        principalTable: "DocMetadatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    PrimaryTariffId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalWorkShiftTimeSpan = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ZoneEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractors_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractors_Tariffs_PrimaryTariffId",
                        column: x => x.PrimaryTariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractors_Zones_ZoneEntityId",
                        column: x => x.ZoneEntityId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    DelayedTripDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PickUpGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    PickUpZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    PickUpAddress = table.Column<string>(type: "text", nullable: false),
                    DropOffGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    DropOffZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DropOffAddress = table.Column<string>(type: "text", nullable: false),
                    TariffId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    EstimatedPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    EstimatedDropOffDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EstimatedTotalDistanceKm = table.Column<float>(type: "real", nullable: false),
                    SearchRadiusFactor = table.Column<int>(type: "integer", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SagaPaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_SagaPayments_SagaPaymentId",
                        column: x => x.SagaPaymentId,
                        principalTable: "SagaPayments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Zones_DropOffZoneId",
                        column: x => x.DropOffZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Zones_PickUpZoneId",
                        column: x => x.PickUpZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffHierarchies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Left = table.Column<int>(type: "integer", nullable: false),
                    Right = table.Column<int>(type: "integer", nullable: false),
                    TariffId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffHierarchies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffHierarchies_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassengerPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysPaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    SagaPaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassengerPaymentTransactions_PassengerCustomers_PassengerCu~",
                        column: x => x.PassengerCustomerId,
                        principalTable: "PassengerCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerPaymentTransactions_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerPaymentTransactions_SagaPayments_SagaPaymentId",
                        column: x => x.SagaPaymentId,
                        principalTable: "SagaPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorCustomers_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorEntityTariffEntity",
                columns: table => new
                {
                    SelectedTariffContractorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectedTariffsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorEntityTariffEntity", x => new { x.SelectedTariffContractorsId, x.SelectedTariffsId });
                    table.ForeignKey(
                        name: "FK_ContractorEntityTariffEntity_Contractors_SelectedTariffCont~",
                        column: x => x.SelectedTariffContractorsId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorEntityTariffEntity_Tariffs_SelectedTariffsId",
                        column: x => x.SelectedTariffsId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorGeos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Geo = table.Column<Geo>(type: "jsonb", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorGeos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorGeos_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    TotalRidesCount = table.Column<int>(type: "integer", nullable: false),
                    TotalLikesCount = table.Column<int>(type: "integer", nullable: false),
                    TotalDislikesCount = table.Column<int>(type: "integer", nullable: false),
                    NiceAtmosphereCount = table.Column<int>(type: "integer", nullable: false),
                    FriendlyDriverCount = table.Column<int>(type: "integer", nullable: false),
                    GoodDrivingCount = table.Column<int>(type: "integer", nullable: false),
                    CleanCarCount = table.Column<int>(type: "integer", nullable: false),
                    BadAtmosphereCount = table.Column<int>(type: "integer", nullable: false),
                    RudeDriverCount = table.Column<int>(type: "integer", nullable: false),
                    BadDrivingCount = table.Column<int>(type: "integer", nullable: false),
                    DirtyCarCount = table.Column<int>(type: "integer", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorStats_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorVehicles_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferStopPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    StopPointGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    StopPointZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    StopPointAddress = table.Column<string>(type: "text", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferStopPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferStopPoints_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferStopPoints_Zones_StopPointZoneId",
                        column: x => x.StopPointZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    AcceptedOfferGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    AcceptedOfferZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    TariffId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    EstimatedPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalFinalPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    Paid = table.Column<bool>(type: "boolean", nullable: false),
                    PreviousOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    EstimatedPreviousOrderFinishDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartPointGeo = table.Column<Geo>(type: "jsonb", nullable: true),
                    StartPointZoneId = table.Column<Guid>(type: "uuid", nullable: true),
                    StartedProcessingOrderDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PickUpGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    PickUpZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    EstimatedArriveToPickUpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ArrivedToPickUpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PickedUpPassengerDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PickUpPaidWaitingTimeTimeSpan = table.Column<TimeSpan>(type: "interval", nullable: true),
                    TotalPickUpPaidWaitingTimeFeePrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalStopPointsPaidWaitingTimeTimeSpan = table.Column<TimeSpan>(type: "interval", nullable: true),
                    TotalStopPointsPaidWaitingTimeFeePrice = table.Column<decimal>(type: "numeric", nullable: true),
                    DropOffGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    DropOffZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitiallyEstimatedArriveToDropOffDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EstimatedArriveToDropOffDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FinishedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsContractorLikedByPassenger = table.Column<bool>(type: "boolean", nullable: true),
                    IsPassengerLikedByContractor = table.Column<bool>(type: "boolean", nullable: true),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Orders_PreviousOrderId",
                        column: x => x.PreviousOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Zones_AcceptedOfferZoneId",
                        column: x => x.AcceptedOfferZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Zones_DropOffZoneId",
                        column: x => x.DropOffZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Zones_PickUpZoneId",
                        column: x => x.PickUpZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Zones_StartPointZoneId",
                        column: x => x.StartPointZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReceivedOfferContractors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    TimeStamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EstimatedPreviousOrderArriveToDropOffDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EstimatedArriveToPickUpDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedOfferContractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedOfferContractors_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivedOfferContractors_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SagaOfferPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SagaOfferPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SagaOfferPayments_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SagaOfferPayments_SagaPayments_Id",
                        column: x => x.Id,
                        principalTable: "SagaPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysPaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    SagaPaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorPaymentTransactions_ContractorCustomers_Contracto~",
                        column: x => x.ContractorCustomerId,
                        principalTable: "ContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorPaymentTransactions_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorPaymentTransactions_SagaPayments_SagaPaymentId",
                        column: x => x.SagaPaymentId,
                        principalTable: "SagaPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderStopPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    StopPointGeo = table.Column<Geo>(type: "jsonb", nullable: false),
                    StopPointZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    EstimatedArriveToStopPointDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ArrivedToStopPointDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PickedUpPassengerDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StopPointPaidWaitingTimeTimeSpan = table.Column<TimeSpan>(type: "interval", nullable: true),
                    TotalStopPointPaidWaitingTimeFeePrice = table.Column<decimal>(type: "numeric", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStopPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStopPoints_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStopPoints_Zones_StopPointZoneId",
                        column: x => x.StopPointZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalDurationSec = table.Column<double>(type: "double precision", nullable: false),
                    TotalDistanceMtr = table.Column<double>(type: "double precision", nullable: false),
                    Geometry = table.Column<string>(type: "text", nullable: false),
                    TrafficLoad = table.Column<string>(type: "text", nullable: false),
                    OriginalJsonRs = table.Column<string>(type: "text", nullable: true),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Routes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractorDebtSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDateOfCurrentDebtPeriod = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    AmountOfContractorOwed = table.Column<decimal>(type: "numeric", nullable: false),
                    NumberOfDebtSeries = table.Column<int>(type: "integer", nullable: false),
                    ContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorPaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorDebtSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorDebtSubscriptions_ContractorCustomers_ContractorC~",
                        column: x => x.ContractorCustomerId,
                        principalTable: "ContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorDebtSubscriptions_ContractorPaymentTransactions_C~",
                        column: x => x.ContractorPaymentTransactionId,
                        principalTable: "ContractorPaymentTransactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractorSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysSubscriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaySysType = table.Column<string>(type: "text", nullable: false),
                    SubscriptionType = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsContinues = table.Column<bool>(type: "boolean", nullable: false),
                    CanceledDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorCustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorPaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorSubscriptions_ContractorCustomers_ContractorCusto~",
                        column: x => x.ContractorCustomerId,
                        principalTable: "ContractorCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorSubscriptions_ContractorPaymentTransactions_Contr~",
                        column: x => x.ContractorPaymentTransactionId,
                        principalTable: "ContractorPaymentTransactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractorSubscriptions_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccurateGeometries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PolylineStartIndex = table.Column<int>(type: "integer", nullable: false),
                    PolylineEndIndex = table.Column<int>(type: "integer", nullable: false),
                    TrafficLoad = table.Column<string>(type: "text", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccurateGeometries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccurateGeometries_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waypoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<Geo>(type: "jsonb", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waypoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waypoints_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedByUserId", "CreatedDate", "DeletedDate", "Name", "NormalizedName", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Admin", "ADMIN", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Support", "SUPPORT", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedByUserId", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutCreatedByUserId", "LockoutCreatedDate", "LockoutEnabled", "LockoutEnd", "LockoutReason", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedByUserId", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 0, "210e5bd5-75ca-4425-9121-cc5bf3136651", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "no-reply@shuttlex.com", true, null, null, false, null, null, "NO-REPLY@SHUTTLEX.COM", "F0535436-9946-4B24-8CB1-9024363EF475", null, "", true, "4c2c6167-c633-4468-a762-9a7cd012c6cc", false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "f0535436-9946-4b24-8cb1-9024363ef475" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "DeletedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccurateGeometries_RouteId",
                table: "AccurateGeometries",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ProfileId",
                table: "Cards",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorCustomers_ContractorId",
                table: "ContractorCustomers",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDebtSubscriptions_ContractorCustomerId",
                table: "ContractorDebtSubscriptions",
                column: "ContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDebtSubscriptions_ContractorPaymentTransactionId",
                table: "ContractorDebtSubscriptions",
                column: "ContractorPaymentTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractorEntityTariffEntity_SelectedTariffsId",
                table: "ContractorEntityTariffEntity",
                column: "SelectedTariffsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorGeos_ContractorId",
                table: "ContractorGeos",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorPaymentTransactions_ContractorCustomerId",
                table: "ContractorPaymentTransactions",
                column: "ContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorPaymentTransactions_ContractorId",
                table: "ContractorPaymentTransactions",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorPaymentTransactions_SagaPaymentId",
                table: "ContractorPaymentTransactions",
                column: "SagaPaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractorStats_ContractorId",
                table: "ContractorStats",
                column: "ContractorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSubscriptions_ContractorCustomerId",
                table: "ContractorSubscriptions",
                column: "ContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSubscriptions_ContractorId",
                table: "ContractorSubscriptions",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSubscriptions_ContractorPaymentTransactionId",
                table: "ContractorSubscriptions",
                column: "ContractorPaymentTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractorVehicles_ContractorId",
                table: "ContractorVehicles",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_PrimaryTariffId",
                table: "Contractors",
                column: "PrimaryTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_ZoneEntityId",
                table: "Contractors",
                column: "ZoneEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DocMetadatas_ZoneId",
                table: "DocMetadatas",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_DocUploadedFiles_ProfileId",
                table: "DocUploadedFiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_DocMetadataId",
                table: "Docs",
                column: "DocMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_FoundPlaces_CreatedByUserId",
                table: "FoundPlaces",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferStopPoints_OfferId",
                table: "OfferStopPoints",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferStopPoints_StopPointZoneId",
                table: "OfferStopPoints",
                column: "StopPointZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_DropOffZoneId",
                table: "Offers",
                column: "DropOffZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PassengerId",
                table: "Offers",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PickUpZoneId",
                table: "Offers",
                column: "PickUpZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SagaPaymentId",
                table: "Offers",
                column: "SagaPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TariffId",
                table: "Offers",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStopPoints_OrderId",
                table: "OrderStopPoints",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStopPoints_StopPointZoneId",
                table: "OrderStopPoints",
                column: "StopPointZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AcceptedOfferZoneId",
                table: "Orders",
                column: "AcceptedOfferZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContractorId",
                table: "Orders",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DropOffZoneId",
                table: "Orders",
                column: "DropOffZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OfferId",
                table: "Orders",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PassengerId",
                table: "Orders",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickUpZoneId",
                table: "Orders",
                column: "PickUpZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PreviousOrderId",
                table: "Orders",
                column: "PreviousOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StartPointZoneId",
                table: "Orders",
                column: "StartPointZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TariffId",
                table: "Orders",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerCustomers_PassengerId",
                table: "PassengerCustomers",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerPaymentTransactions_PassengerCustomerId",
                table: "PassengerPaymentTransactions",
                column: "PassengerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerPaymentTransactions_PassengerId",
                table: "PassengerPaymentTransactions",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerPaymentTransactions_SagaPaymentId",
                table: "PassengerPaymentTransactions",
                column: "SagaPaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolygonGeos_ZoneId",
                table: "PolygonGeos",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileAvatars_ProfileId",
                table: "ProfileAvatars",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEmails_ProfileId",
                table: "ProfileEmails",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileFirstNames_ProfileId",
                table: "ProfileFirstNames",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileGeoEntity_ProfileId",
                table: "ProfileGeoEntity",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLanguages_ProfileId",
                table: "ProfileLanguages",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLastNames_ProfileId",
                table: "ProfileLastNames",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhones_ProfileId",
                table: "ProfilePhones",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileZones_ProfileId",
                table: "ProfileZones",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileZones_ZoneId",
                table: "ProfileZones",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedOfferContractors_ContractorId",
                table: "ReceivedOfferContractors",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedOfferContractors_OfferId",
                table: "ReceivedOfferContractors",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_OfferId",
                table: "Routes",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_OrderId",
                table: "Routes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SagaOfferPayments_OfferId",
                table: "SagaOfferPayments",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SagaStepPayments_SagaPaymentId",
                table: "SagaStepPayments",
                column: "SagaPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignInAttempts_SessionId",
                table: "SignInAttempts",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SignInAttempts_UserId",
                table: "SignInAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeContractorPaymentTransactions_StripeContractorCustome~",
                table: "StripeContractorPaymentTransactions",
                column: "StripeContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeContractorSubscriptions_StripeContractorCustomerId",
                table: "StripeContractorSubscriptions",
                column: "StripeContractorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeContractorSubscriptions_StripeContractorPaymentTransa~",
                table: "StripeContractorSubscriptions",
                column: "StripeContractorPaymentTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StripePassengerPaymentTransactions_StripePassengerCustomerId",
                table: "StripePassengerPaymentTransactions",
                column: "StripePassengerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffHierarchies_TariffId",
                table: "TariffHierarchies",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_ZoneId",
                table: "Tariffs",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Waypoints_RouteId",
                table: "Waypoints",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneClosureTableNode_DescendantId",
                table: "ZoneClosureTableNode",
                column: "DescendantId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ParentEntityId",
                table: "Zones",
                column: "ParentEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccurateGeometries");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Charges");

            migrationBuilder.DropTable(
                name: "ContractorDebtSubscriptions");

            migrationBuilder.DropTable(
                name: "ContractorEntityTariffEntity");

            migrationBuilder.DropTable(
                name: "ContractorGeos");

            migrationBuilder.DropTable(
                name: "ContractorStats");

            migrationBuilder.DropTable(
                name: "ContractorSubscriptions");

            migrationBuilder.DropTable(
                name: "ContractorVehicles");

            migrationBuilder.DropTable(
                name: "DocUploadedFiles");

            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "FoundPlaces");

            migrationBuilder.DropTable(
                name: "FoundPlacesML");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OfferStopPoints");

            migrationBuilder.DropTable(
                name: "OrderStopPoints");

            migrationBuilder.DropTable(
                name: "PassengerPaymentTransactions");

            migrationBuilder.DropTable(
                name: "PaymentSystemRecognizer");

            migrationBuilder.DropTable(
                name: "PolygonGeos");

            migrationBuilder.DropTable(
                name: "ProfileAvatars");

            migrationBuilder.DropTable(
                name: "ProfileEmails");

            migrationBuilder.DropTable(
                name: "ProfileFirstNames");

            migrationBuilder.DropTable(
                name: "ProfileGeoEntity");

            migrationBuilder.DropTable(
                name: "ProfileLanguages");

            migrationBuilder.DropTable(
                name: "ProfileLastNames");

            migrationBuilder.DropTable(
                name: "ProfilePhones");

            migrationBuilder.DropTable(
                name: "ProfileZones");

            migrationBuilder.DropTable(
                name: "ReceivedOfferContractors");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "SagaOfferPayments");

            migrationBuilder.DropTable(
                name: "SagaStepPayments");

            migrationBuilder.DropTable(
                name: "SignInAttempts");

            migrationBuilder.DropTable(
                name: "StripeContractorSubscriptions");

            migrationBuilder.DropTable(
                name: "StripePassengerPaymentTransactions");

            migrationBuilder.DropTable(
                name: "TariffHierarchies");

            migrationBuilder.DropTable(
                name: "Waypoints");

            migrationBuilder.DropTable(
                name: "ZoneClosureTableNode");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContractorPaymentTransactions");

            migrationBuilder.DropTable(
                name: "DocMetadatas");

            migrationBuilder.DropTable(
                name: "PassengerCustomers");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "StripeContractorPaymentTransactions");

            migrationBuilder.DropTable(
                name: "StripePassengerCustomers");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "ContractorCustomers");

            migrationBuilder.DropTable(
                name: "StripeContractorCustomers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "SagaPayments");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Zones");
        }
    }
}
