using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleX.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileDocumentEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Angle",
                table: "ProfileGeos");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Profiles",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "ProfileGeos",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "ProfileGeos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RotationDeg",
                table: "ProfileGeos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProfileDriverLicenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DocType = table.Column<string>(type: "text", nullable: false),
                    OriginCountry = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PatronymicName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: true),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    Authority = table.Column<string>(type: "text", nullable: false),
                    DocNumber = table.Column<string>(type: "text", nullable: false),
                    Restrictions = table.Column<string[]>(type: "jsonb", nullable: false),
                    DocId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDriverLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileDriverLicenses_Docs_DocId",
                        column: x => x.DocId,
                        principalTable: "Docs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileDriverLicenses_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileInsurances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    OrigincCountry = table.Column<string>(type: "text", nullable: false),
                    DocType = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: true),
                    DateOfExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    DocNumber = table.Column<string>(type: "text", nullable: false),
                    PlateNumber = table.Column<string>(type: "text", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    ManifactureYear = table.Column<int>(type: "integer", nullable: false),
                    CompanyIssuer = table.Column<string>(type: "text", nullable: false),
                    DocId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileInsurances_Docs_DocId",
                        column: x => x.DocId,
                        principalTable: "Docs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileInsurances_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePassports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    PassportDocType = table.Column<string>(type: "text", nullable: false),
                    OriginCountry = table.Column<string>(type: "text", nullable: false),
                    DocType = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PatronymicName = table.Column<string>(type: "text", nullable: true),
                    SexType = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: true),
                    RecordNumber = table.Column<string>(type: "text", nullable: true),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: true),
                    DateOfExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    Authority = table.Column<string>(type: "text", nullable: true),
                    DocNumber = table.Column<string>(type: "text", nullable: false),
                    DocId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePassports_Docs_DocId",
                        column: x => x.DocId,
                        principalTable: "Docs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilePassports_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocType = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: false),
                    MaxMassKg = table.Column<int>(type: "integer", nullable: false),
                    ServiceMassKg = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    CapacitySm3 = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    SeatsNumber = table.Column<int>(type: "integer", nullable: false),
                    StandingPlacesNumber = table.Column<int>(type: "integer", nullable: false),
                    DocNumber = table.Column<string>(type: "text", nullable: false),
                    RecordNumber = table.Column<string>(type: "text", nullable: true),
                    PlateNumber = table.Column<string>(type: "text", nullable: false),
                    ManifactureYear = table.Column<int>(type: "integer", nullable: false),
                    DocId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileVehicles_Docs_DocId",
                        column: x => x.DocId,
                        principalTable: "Docs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileVehicles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverLicenseCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    Restrictions = table.Column<string[]>(type: "jsonb", nullable: false),
                    DriverLicenseId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLicenseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverLicenseCategories_ProfileDriverLicenses_DriverLicense~",
                        column: x => x.DriverLicenseId,
                        principalTable: "ProfileDriverLicenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "0391c961-ca1a-43b9-ba8a-4624e2a784e7", "92A9E46E-6153-4B7C-9D3F-A84E5B9D52D4", "35ae0d6e-f439-4777-a399-499ec45dcc90", "92a9e46e-6153-4b7c-9d3f-a84e5b9d52d4" });

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenseCategories_DriverLicenseId",
                table: "DriverLicenseCategories",
                column: "DriverLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDriverLicenses_DocId",
                table: "ProfileDriverLicenses",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDriverLicenses_ProfileId",
                table: "ProfileDriverLicenses",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInsurances_DocId",
                table: "ProfileInsurances",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInsurances_ProfileId",
                table: "ProfileInsurances",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePassports_DocId",
                table: "ProfilePassports",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePassports_ProfileId",
                table: "ProfilePassports",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileVehicles_DocId",
                table: "ProfileVehicles",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileVehicles_ProfileId",
                table: "ProfileVehicles",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverLicenseCategories");

            migrationBuilder.DropTable(
                name: "ProfileInsurances");

            migrationBuilder.DropTable(
                name: "ProfilePassports");

            migrationBuilder.DropTable(
                name: "ProfileVehicles");

            migrationBuilder.DropTable(
                name: "ProfileDriverLicenses");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "ProfileGeos");

            migrationBuilder.DropColumn(
                name: "RotationDeg",
                table: "ProfileGeos");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Profiles",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "ProfileGeos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<double>(
                name: "Angle",
                table: "ProfileGeos",
                type: "double precision",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "0b95d38e-57e1-4078-ac74-c175a43dab55", "22A89BDC-B77A-44FD-BD34-576C00426AA7", "c6fd6e40-99b7-4935-b4ff-eabd9f922bfe", "22a89bdc-b77a-44fd-bd34-576c00426aa7" });
        }
    }
}
