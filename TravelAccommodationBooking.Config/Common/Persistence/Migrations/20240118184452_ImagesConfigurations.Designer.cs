﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAccommodationBooking.Config.Common.Persistence;

#nullable disable

namespace Infrastructure.Common.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240118184452_ImagesConfigurations")]
    partial class ImagesConfigurations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"),
                            BookingDate = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckInDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutDate = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = new Guid("c6c45f7c-2dfe-4c1e-9a9b-8b173c71b32c"),
                            RoomId = new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6")
                        },
                        new
                        {
                            Id = new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"),
                            BookingDate = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckInDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutDate = new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = new Guid("aaf21a7d-8fc3-4c9f-8a8e-1eeec8dcd462"),
                            RoomId = new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a")
                        },
                        new
                        {
                            Id = new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"),
                            BookingDate = new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckInDate = new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutDate = new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = new Guid("f44c3eb4-2c8a-4a77-a31b-04c4619aa15a"),
                            RoomId = new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29")
                        });
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostOffice")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f9e85d04-548c-4f98-afe9-2a8831c62a90"),
                            CountryCode = "US",
                            CountryName = "United States",
                            Name = "New York",
                            PostOffice = "NYC"
                        },
                        new
                        {
                            Id = new Guid("8d2aeb7a-7c67-4911-aa2c-d6a3b4dc7e9e"),
                            CountryCode = "UK",
                            CountryName = "United Kingdom",
                            Name = "London",
                            PostOffice = "LDN"
                        },
                        new
                        {
                            Id = new Guid("3c7e66f5-46a9-4b8d-8e90-85b5a9e2c2fd"),
                            CountryCode = "JP",
                            CountryName = "Japan",
                            Name = "Tokyo",
                            PostOffice = "TKY"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6c45f7c-2dfe-4c1e-9a9b-8b173c71b32c"),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            Id = new Guid("aaf21a7d-8fc3-4c9f-8a8e-1eeec8dcd462"),
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "2012345678"
                        },
                        new
                        {
                            Id = new Guid("f44c3eb4-2c8a-4a77-a31b-04c4619aa15a"),
                            Email = "hiroshi.tanaka@example.co.jp",
                            FirstName = "Hiroshi",
                            LastName = "Tanaka",
                            PhoneNumber = "312345678"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FloorsNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hotels", t =>
                        {
                            t.HasCheckConstraint("CK_Hotel_RatingRange", "[Rating] >= 0 AND [Rating] <= 5");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("98c2c9fe-1a1c-4eaa-a7f5-b9d19b246c27"),
                            CityId = new Guid("f9e85d04-548c-4f98-afe9-2a8831c62a90"),
                            Description = "A luxurious hotel with top-notch amenities.",
                            FloorsNumber = 10,
                            Name = "Luxury Inn",
                            OwnerId = new Guid("a1d1aa11-12e7-4e0f-8425-67c1c1e62c2d"),
                            PhoneNumber = "1234567890",
                            Rating = 4.5f,
                            StreetAddress = "123 Main Street"
                        },
                        new
                        {
                            Id = new Guid("bfa4173d-7893-48b9-a497-5f4c7fb2492b"),
                            CityId = new Guid("8d2aeb7a-7c67-4911-aa2c-d6a3b4dc7e9e"),
                            Description = "A cozy lodge nestled in the heart of nature.",
                            FloorsNumber = 3,
                            Name = "Cozy Lodge",
                            OwnerId = new Guid("a1d1aa11-12e7-4e0f-8425-67c1c1e62c2d"),
                            PhoneNumber = "2012345678",
                            Rating = 3.8f,
                            StreetAddress = "456 Oak Avenue"
                        },
                        new
                        {
                            Id = new Guid("9461e08b-92d3-45da-b6b3-efc0cfcc4a3a"),
                            CityId = new Guid("3c7e66f5-46a9-4b8d-8e90-85b5a9e2c2fd"),
                            Description = "A resort with breathtaking sunset views over the ocean.",
                            FloorsNumber = 5,
                            Name = "Sunset Resort",
                            OwnerId = new Guid("77b2c30b-65d0-4ea7-8a5e-71e7c294f117"),
                            PhoneNumber = "312345678",
                            Rating = 4.2f,
                            StreetAddress = "789 Beachfront Road"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1d1aa11-12e7-4e0f-8425-67c1c1e62c2d"),
                            Email = "obadayahya.an@gmail.com",
                            FirstName = "Obada",
                            LastName = "Yahya",
                            PhoneNumber = "0598231234"
                        },
                        new
                        {
                            Id = new Guid("77b2c30b-65d0-4ea7-8a5e-71e7c294f117"),
                            Email = "muathejamil@gmail.com",
                            FirstName = "Muathe",
                            LastName = "Jamil",
                            PhoneNumber = "0598242354"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("Method");

                    b.HasIndex("Status");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7f5cc9f0-796f-498d-9f3f-9e5249a4f6ae"),
                            Amount = 1500.0,
                            BookingId = new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"),
                            Method = "CreditCard",
                            Status = "Completed"
                        },
                        new
                        {
                            Id = new Guid("1c8d70bd-2534-4991-bddf-84c7edee1a79"),
                            Amount = 1200.0,
                            BookingId = new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"),
                            Method = "Cash",
                            Status = "Pending"
                        },
                        new
                        {
                            Id = new Guid("8f974636-4f53-48d9-af99-2f7f1d3e0474"),
                            Amount = 2000.0,
                            BookingId = new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"),
                            Method = "MobileWallet",
                            Status = "Completed"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Reviews", t =>
                        {
                            t.HasCheckConstraint("CK_Review_RatingRange", "[Rating] >= 0 AND [Rating] <= 5");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("63e4bb25-28b1-4fc4-9b93-9254d94dab23"),
                            BookingId = new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"),
                            Comment = "Excellent service and comfortable stay!",
                            Rating = 4.8f,
                            ReviewDate = new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("85a5a0b4-0e04-4c46-b7ac-6cf609e4f2aa"),
                            BookingId = new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"),
                            Comment = "Friendly staff and great location.",
                            Rating = 4.5f,
                            ReviewDate = new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("192045db-c6db-49c9-aa6b-2e3d6c7f3b79"),
                            BookingId = new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"),
                            Comment = "Clean rooms and beautiful views.",
                            Rating = 4.2f,
                            ReviewDate = new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdultsCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ChildrenCapacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid?>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("View")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms", t =>
                        {
                            t.HasCheckConstraint("CK_Review_RatingRange", "[Rating] >= 0 AND [Rating] <= 5")
                                .HasName("CK_Review_RatingRange1");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6"),
                            AdultsCapacity = 2,
                            ChildrenCapacity = 1,
                            Rating = 4.5f,
                            RoomTypeId = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"),
                            View = "City View"
                        },
                        new
                        {
                            Id = new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a"),
                            AdultsCapacity = 3,
                            ChildrenCapacity = 2,
                            Rating = 4.2f,
                            RoomTypeId = new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"),
                            View = "Ocean View"
                        },
                        new
                        {
                            Id = new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29"),
                            AdultsCapacity = 4,
                            ChildrenCapacity = 1,
                            Rating = 4.8f,
                            RoomTypeId = new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"),
                            View = "Mountain View"
                        });
                });

            modelBuilder.Entity("Domain.Entities.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("PricePerNight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Category")
                        .IsUnique();

                    b.ToTable("RoomTypes", t =>
                        {
                            t.HasCheckConstraint("CK_RoomType_PriceRange", "[PricePerNight] >= 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"),
                            Category = 2,
                            HotelId = new Guid("98c2c9fe-1a1c-4eaa-a7f5-b9d19b246c27"),
                            PricePerNight = 100f
                        },
                        new
                        {
                            Id = new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"),
                            Category = 0,
                            HotelId = new Guid("bfa4173d-7893-48b9-a497-5f4c7fb2492b"),
                            PricePerNight = 150f
                        },
                        new
                        {
                            Id = new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"),
                            Category = 1,
                            HotelId = new Guid("9461e08b-92d3-45da-b6b3-efc0cfcc4a3a"),
                            PricePerNight = 200f
                        });
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.HasOne("Domain.Entities.Guest", null)
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.HasOne("Domain.Entities.City", null)
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Owner", null)
                        .WithMany("Hotels")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.HasOne("Domain.Entities.Booking", null)
                        .WithOne("Payment")
                        .HasForeignKey("Domain.Entities.Payment", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.HasOne("Domain.Entities.Booking", null)
                        .WithOne("Review")
                        .HasForeignKey("Domain.Entities.Review", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.HasOne("Domain.Entities.Hotel", null)
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId");

                    b.HasOne("Domain.Entities.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.Navigation("Payment");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Domain.Entities.Guest", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}
