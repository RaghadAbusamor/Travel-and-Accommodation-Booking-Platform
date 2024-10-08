﻿using Microsoft.EntityFrameworkCore;
using TravelAccommodationBooking.Config.Common.Persistence.Extensions;
using TravelAccommodationBooking.Model.Entities.Billing;
using TravelAccommodationBooking.Model.Entities.Rooms;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Entities.Search;
using TravelAccommodationBooking.Model.Entities.User;
using TravelAccommodationBooking.Config.Common.Persistence.Configurations;
using TravelAccommodationBooking.Security;



namespace TravelAccommodationBooking.Config.Common.Persistence;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<RoomFeature> RoomFeatures { get; set; }
    public DbSet<Discount> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new HotelConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        modelBuilder.ApplyConfiguration(new OwnerConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.SeedTables();
        base.OnModelCreating(modelBuilder);
    }

}