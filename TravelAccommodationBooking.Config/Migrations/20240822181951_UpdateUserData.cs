using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelAccommodationBooking.Config.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PostOffice = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PricePerNight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                    table.CheckConstraint("CK_RoomType_PriceRange", "[PricePerNight] >= 0");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountPercentage = table.Column<float>(type: "real", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeatureRoomType",
                columns: table => new
                {
                    FeaturesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatureRoomType", x => new { x.FeaturesId, x.RoomTypesId });
                    table.ForeignKey(
                        name: "FK_RoomFeatureRoomType_RoomFeatures_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "RoomFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFeatureRoomType_RoomTypes_RoomTypesId",
                        column: x => x.RoomTypesId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdultsCapacity = table.Column<int>(type: "int", nullable: false),
                    ChildrenCapacity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    View = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.CheckConstraint("CK_Review_RatingRange1", "[Rating] >= 0 AND [Rating] <= 5");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FloorsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.CheckConstraint("CK_Hotel_RatingRange", "[Rating] >= 0 AND [Rating] <= 5");
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.CheckConstraint("CK_Review_RatingRange", "[Rating] >= 0 AND [Rating] <= 5");
                    table.ForeignKey(
                        name: "FK_Reviews_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryCode", "CountryName", "Name", "PostOffice" },
                values: new object[,]
                {
                    { new Guid("3c7e66f5-46a9-4b8d-8e90-85b5a9e2c2fd"), "JP", "Japan", "Tokyo", "TKY" },
                    { new Guid("8d2aeb7a-7c67-4911-aa2c-d6a3b4dc7e9e"), "UK", "United Kingdom", "London", "LDN" },
                    { new Guid("f9e85d04-548c-4f98-afe9-2a8831c62a90"), "US", "United States", "New York", "NYC" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Category", "HotelId", "PricePerNight" },
                values: new object[,]
                {
                    { new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"), "Suite", new Guid("9461e08b-92d3-45da-b6b3-efc0cfcc4a3a"), 2000f },
                    { new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"), "Single", new Guid("98c2c9fe-1a1c-4eaa-a7f5-b9d19b246c27"), 1000f },
                    { new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"), "Double", new Guid("bfa4173d-7893-48b9-a497-5f4c7fb2492b"), 1500f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Role", "Salt" },
                values: new object[,]
                {
                    { new Guid("55b1aa11-12e7-4e0f-8425-67c1c1e62c2d"), "Owner", "raghadmohammad253@gmail.com", "Raghad", "AbuSamor", "55b1aa11precomputed_hash_value", "0595758383", "Admin", "55b1aa11precomputed_salt_value" },
                    { new Guid("77b2c30b-65d0-4ea7-8a5e-71e7c294f117"), "Owner", "ayatalan@gmail.com", "Ayat", "AbuAllam", "77b2c30bprecomputed_hash_value22", "0595758382", "Admin", "77b2c30precomputed_salt_value" },
                    { new Guid("aaf21a7d-8fc3-4c9f-8a8e-1eeec8dcd462"), "User", "janesmith@example.com", "Jane", "Smith", "aaf21a7dprecomputed_hash_value", "0987654321", "Guest", "aaf21a7dprecomputed_salt_value" },
                    { new Guid("c6c45f7c-2dfe-4c1e-9a9b-8b173c71b32c"), "User", "johndoe@example.com", "John", "Doe", "c6c45f7cprecomputed_hash_value", "1234567890", "Guest", "c6c45f7cprecomputed_salt_value" },
                    { new Guid("f44c3eb4-2c8a-4a77-a31b-04c4619aa15a"), "User", "alicejohnson@example.com", "Alice", "Johnson", "f44c3eb4precomputed_hash_value", "1122334455", "Guest", "f44c3eb4precomputed_salt_value" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityId", "Description", "FloorsNumber", "Name", "OwnerId", "PhoneNumber", "Rating", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("9461e08b-92d3-45da-b6b3-efc0cfcc4a3a"), new Guid("3c7e66f5-46a9-4b8d-8e90-85b5a9e2c2fd"), "A resort with breathtaking sunset views over the ocean.", 10, "Sunset Resort", new Guid("77b2c30b-65d0-4ea7-8a5e-71e7c294f117"), "312345678", 4.2f, "789 Beachfront Road" },
                    { new Guid("98c2c9fe-1a1c-4eaa-a7f5-b9d19b246c27"), new Guid("f9e85d04-548c-4f98-afe9-2a8831c62a90"), "A luxurious hotel with top-notch amenities.", 15, "Luxury HT", new Guid("55b1aa11-12e7-4e0f-8425-67c1c1e62c2d"), "0123456789", 4.5f, "123 Main Street" },
                    { new Guid("bfa4173d-7893-48b9-a497-5f4c7fb2492b"), new Guid("8d2aeb7a-7c67-4911-aa2c-d6a3b4dc7e9e"), "A cozy lodge nestled in the heart of nature.", 5, "Cozy Lodge", new Guid("55b1aa11-12e7-4e0f-8425-67c1c1e62c2d"), "2012345678", 3.8f, "456 Oak Avenue" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AdultsCapacity", "ChildrenCapacity", "HotelId", "Rating", "RoomTypeId", "View" },
                values: new object[,]
                {
                    { new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a"), 3, 3, new Guid("00000000-0000-0000-0000-000000000000"), 4.4f, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"), "Ocean View" },
                    { new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6"), 2, 2, new Guid("00000000-0000-0000-0000-000000000000"), 4.2f, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"), "City View" },
                    { new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29"), 4, 4, new Guid("00000000-0000-0000-0000-000000000000"), 4.8f, new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"), "Mountain View" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CheckInDate", "CheckOutDate", "Price", "RoomId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.0, new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29"), new Guid("f44c3eb4-2c8a-4a77-a31b-04c4619aa15a") },
                    { new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0, new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6"), new Guid("c6c45f7c-2dfe-4c1e-9a9b-8b173c71b32c") },
                    { new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.0, new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a"), new Guid("aaf21a7d-8fc3-4c9f-8a8e-1eeec8dcd462") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BookingId", "Method", "Status" },
                values: new object[,]
                {
                    { new Guid("1c8d70bd-2534-4991-bddf-84c7edee1a79"), 1200.0, new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), "Cash", "InProgress" },
                    { new Guid("7f5cc9f0-796f-498d-9f3f-9e5249a4f6ae"), 1500.0, new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), "CreditCard", "Paid" },
                    { new Guid("8f974636-4f53-48d9-af99-2f7f1d3e0474"), 2000.0, new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), "Cash", "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "Comment", "Rating", "ReviewDate" },
                values: new object[,]
                {
                    { new Guid("192045db-c6db-49c9-aa6b-2e3d6c7f3b79"), new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), "Clean rooms and beautiful views.", 4.2f, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63e4bb25-28b1-4fc4-9b93-9254d94dab23"), new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), "Excellent service and comfortable stay!", 4.8f, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85a5a0b4-0e04-4c46-b7ac-6cf609e4f2aa"), new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), "Friendly staff and great location.", 4.5f, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_RoomTypeId",
                table: "Discounts",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_OwnerId",
                table: "Hotels",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Method",
                table: "Payments",
                column: "Method");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Status",
                table: "Payments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureRoomType_RoomTypesId",
                table: "RoomFeatureRoomType",
                column: "RoomTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_Category",
                table: "RoomTypes",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "RoomFeatureRoomType");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "RoomFeatures");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
