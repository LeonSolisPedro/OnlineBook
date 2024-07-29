using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Copyright = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgencyCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeRateToMXN = table.Column<decimal>(type: "money", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyCurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgencySocials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencySocials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourClassPricings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: true),
                    InfantsCountAsSeats = table.Column<bool>(type: "bit", nullable: true),
                    AllowInfants = table.Column<bool>(type: "bit", nullable: true),
                    AllowMinors = table.Column<bool>(type: "bit", nullable: true),
                    AdultsPricinginMXN = table.Column<decimal>(type: "money", nullable: false),
                    MinorsPricinginMXN = table.Column<decimal>(type: "money", nullable: false),
                    InfantsPricinginMXN = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourClassPricings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarousels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarousels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCarousels_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncludesHotel = table.Column<bool>(type: "bit", nullable: false),
                    IncludesFlights = table.Column<bool>(type: "bit", nullable: false),
                    IncludesTransportation = table.Column<bool>(type: "bit", nullable: false),
                    MoreInfoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeOffers_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContactDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactDateTimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditedDateTimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherContactForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherContactForms_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherGalleries_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherPrivacyNotices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "ntext", nullable: false),
                    LastEditedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherPrivacyNotices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherPrivacyNotices_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherTermsConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "ntext", nullable: false),
                    LastEditedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherTermsConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherTermsConditions_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourCategories_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourDirections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDirections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourDirections_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourSearchQueries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourSearchQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourSearchQueries_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgencyCurrencyCompositions",
                columns: table => new
                {
                    IdAgencyCurrency = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyCurrencyCompositions", x => new { x.IdAgency, x.IdAgencyCurrency });
                    table.ForeignKey(
                        name: "FK_AgencyCurrencyCompositions_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgencyCurrencyCompositions_AgencyCurrencies_IdAgencyCurrency",
                        column: x => x.IdAgencyCurrency,
                        principalTable: "AgencyCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgencySocialCompositions",
                columns: table => new
                {
                    IdAgencySocial = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencySocialCompositions", x => new { x.IdAgencySocial, x.IdAgency });
                    table.ForeignKey(
                        name: "FK_AgencySocialCompositions_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgencySocialCompositions_AgencySocials_IdAgencySocial",
                        column: x => x.IdAgencySocial,
                        principalTable: "AgencySocials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTourClassPricing = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationDateTimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDateTimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDayTimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalOcupiedSeats = table.Column<int>(type: "int", nullable: false),
                    InfantsCountAsSeat = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfMinors = table.Column<int>(type: "int", nullable: false),
                    NumberOfInfants = table.Column<int>(type: "int", nullable: false),
                    SettingsData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdultsData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinorsData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPricePaid = table.Column<decimal>(type: "money", nullable: false),
                    AdultsPricinginMXN = table.Column<decimal>(type: "money", nullable: false),
                    MinorsPricinginMXN = table.Column<decimal>(type: "money", nullable: false),
                    InfantsPricinginMXN = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourReservations_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourReservations_TourClassPricings_IdTourClassPricing",
                        column: x => x.IdTourClassPricing,
                        principalTable: "TourClassPricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourType = table.Column<int>(type: "int", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    LinkVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkPDFItinerary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DurationType = table.Column<int>(type: "int", nullable: false),
                    IsInternational = table.Column<bool>(type: "bit", nullable: false),
                    IdTourDirection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tours_TourDirections_IdTourDirection",
                        column: x => x.IdTourDirection,
                        principalTable: "TourDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeTourPopularCompositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTour = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PopularType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTourPopularCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTourPopularCompositions_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeTourPopularCompositions_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourCategoryCompositions",
                columns: table => new
                {
                    IdTourCategory = table.Column<int>(type: "int", nullable: false),
                    IdTour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourCategoryCompositions", x => new { x.IdTour, x.IdTourCategory });
                    table.ForeignKey(
                        name: "FK_TourCategoryCompositions_TourCategories_IdTourCategory",
                        column: x => x.IdTourCategory,
                        principalTable: "TourCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourCategoryCompositions_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourDatePricings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTour = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RepeatType = table.Column<int>(type: "int", nullable: false),
                    AreSettingsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: true),
                    InfantsCountAsSeats = table.Column<bool>(type: "bit", nullable: true),
                    AllowInfants = table.Column<bool>(type: "bit", nullable: true),
                    AllowMinors = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDatePricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourDatePricings_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourGalleryImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePreview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IdTour = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGalleryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourGalleryImages_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourGalleryImages_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourIncludes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncludeType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourIncludes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourIncludes_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourItineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTour = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourItineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourItineraries_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourItineraries_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourSearchQueryCompositions",
                columns: table => new
                {
                    IdTourSearchQuery = table.Column<int>(type: "int", nullable: false),
                    IdTour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourSearchQueryCompositions", x => new { x.IdTour, x.IdTourSearchQuery });
                    table.ForeignKey(
                        name: "FK_TourSearchQueryCompositions_TourSearchQueries_IdTourSearchQuery",
                        column: x => x.IdTourSearchQuery,
                        principalTable: "TourSearchQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourSearchQueryCompositions_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourSimilars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTour = table.Column<int>(type: "int", nullable: false),
                    IdAgency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourSimilars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourSimilars_Agencies_IdAgency",
                        column: x => x.IdAgency,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourSimilars_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourDatePricingCompositions",
                columns: table => new
                {
                    IdTourDatePricing = table.Column<int>(type: "int", nullable: false),
                    IdTourClassPricing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDatePricingCompositions", x => new { x.IdTourClassPricing, x.IdTourDatePricing });
                    table.ForeignKey(
                        name: "FK_TourDatePricingCompositions_TourClassPricings_IdTourClassPricing",
                        column: x => x.IdTourClassPricing,
                        principalTable: "TourClassPricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourDatePricingCompositions_TourDatePricings_IdTourDatePricing",
                        column: x => x.IdTourDatePricing,
                        principalTable: "TourDatePricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourNotWorkingDays",
                columns: table => new
                {
                    IdTourDatePricing = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourNotWorkingDays", x => new { x.IdTourDatePricing, x.Day });
                    table.ForeignKey(
                        name: "FK_TourNotWorkingDays_TourDatePricings_IdTourDatePricing",
                        column: x => x.IdTourDatePricing,
                        principalTable: "TourDatePricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourRepeatSpecificDates",
                columns: table => new
                {
                    IdTourDatePricing = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourRepeatSpecificDates", x => new { x.IdTourDatePricing, x.Day });
                    table.ForeignKey(
                        name: "FK_TourRepeatSpecificDates_TourDatePricings_IdTourDatePricing",
                        column: x => x.IdTourDatePricing,
                        principalTable: "TourDatePricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgencyCurrencyCompositions_IdAgencyCurrency",
                table: "AgencyCurrencyCompositions",
                column: "IdAgencyCurrency");

            migrationBuilder.CreateIndex(
                name: "IX_AgencySocialCompositions_IdAgency",
                table: "AgencySocialCompositions",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarousels_IdAgency",
                table: "HomeCarousels",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_HomeOffers_IdAgency",
                table: "HomeOffers",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTourPopularCompositions_IdAgency",
                table: "HomeTourPopularCompositions",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTourPopularCompositions_IdTour",
                table: "HomeTourPopularCompositions",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_OtherContactForms_IdAgency",
                table: "OtherContactForms",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_OtherGalleries_IdAgency",
                table: "OtherGalleries",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPrivacyNotices_IdAgency",
                table: "OtherPrivacyNotices",
                column: "IdAgency",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherTermsConditions_IdAgency",
                table: "OtherTermsConditions",
                column: "IdAgency",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourCategories_IdAgency",
                table: "TourCategories",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_TourCategoryCompositions_IdTourCategory",
                table: "TourCategoryCompositions",
                column: "IdTourCategory");

            migrationBuilder.CreateIndex(
                name: "IX_TourDatePricingCompositions_IdTourDatePricing",
                table: "TourDatePricingCompositions",
                column: "IdTourDatePricing");

            migrationBuilder.CreateIndex(
                name: "IX_TourDatePricings_IdTour",
                table: "TourDatePricings",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_TourDirections_IdAgency",
                table: "TourDirections",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_TourGalleryImages_IdAgency",
                table: "TourGalleryImages",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_TourGalleryImages_IdTour",
                table: "TourGalleryImages",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_TourIncludes_IdTour",
                table: "TourIncludes",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_TourItineraries_IdAgency",
                table: "TourItineraries",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_TourItineraries_IdTour",
                table: "TourItineraries",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_TourReservations_IdAgency",
                table: "TourReservations",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_TourReservations_IdTourClassPricing",
                table: "TourReservations",
                column: "IdTourClassPricing");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_IdAgency",
                table: "Tours",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_IdTourDirection",
                table: "Tours",
                column: "IdTourDirection");

            migrationBuilder.CreateIndex(
                name: "IX_TourSearchQueries_IdAgency",
                table: "TourSearchQueries",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_TourSearchQueryCompositions_IdTourSearchQuery",
                table: "TourSearchQueryCompositions",
                column: "IdTourSearchQuery");

            migrationBuilder.CreateIndex(
                name: "IX_TourSimilars_IdAgency",
                table: "TourSimilars",
                column: "IdAgency");

            migrationBuilder.CreateIndex(
                name: "IX_TourSimilars_IdTour",
                table: "TourSimilars",
                column: "IdTour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyCurrencyCompositions");

            migrationBuilder.DropTable(
                name: "AgencySocialCompositions");

            migrationBuilder.DropTable(
                name: "HomeCarousels");

            migrationBuilder.DropTable(
                name: "HomeOffers");

            migrationBuilder.DropTable(
                name: "HomeTourPopularCompositions");

            migrationBuilder.DropTable(
                name: "OtherContactForms");

            migrationBuilder.DropTable(
                name: "OtherGalleries");

            migrationBuilder.DropTable(
                name: "OtherPrivacyNotices");

            migrationBuilder.DropTable(
                name: "OtherTermsConditions");

            migrationBuilder.DropTable(
                name: "TourCategoryCompositions");

            migrationBuilder.DropTable(
                name: "TourDatePricingCompositions");

            migrationBuilder.DropTable(
                name: "TourGalleryImages");

            migrationBuilder.DropTable(
                name: "TourIncludes");

            migrationBuilder.DropTable(
                name: "TourItineraries");

            migrationBuilder.DropTable(
                name: "TourNotWorkingDays");

            migrationBuilder.DropTable(
                name: "TourRepeatSpecificDates");

            migrationBuilder.DropTable(
                name: "TourReservations");

            migrationBuilder.DropTable(
                name: "TourSearchQueryCompositions");

            migrationBuilder.DropTable(
                name: "TourSimilars");

            migrationBuilder.DropTable(
                name: "AgencyCurrencies");

            migrationBuilder.DropTable(
                name: "AgencySocials");

            migrationBuilder.DropTable(
                name: "TourCategories");

            migrationBuilder.DropTable(
                name: "TourDatePricings");

            migrationBuilder.DropTable(
                name: "TourClassPricings");

            migrationBuilder.DropTable(
                name: "TourSearchQueries");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "TourDirections");

            migrationBuilder.DropTable(
                name: "Agencies");
        }
    }
}
