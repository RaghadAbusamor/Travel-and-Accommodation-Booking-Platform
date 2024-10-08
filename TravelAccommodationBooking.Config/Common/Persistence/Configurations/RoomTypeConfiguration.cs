﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAccommodationBooking.Model.Entities.Rooms;
using TravelAccommodationBooking.Model.Enums.Hotel;

namespace TravelAccommodationBooking.Config.Common.Persistence.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.HasIndex(roomType => roomType.Category);

        builder.Property(roomType => roomType.Category)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<RoomCategory>());

        builder
            .Property(roomType => roomType.Category)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(roomType => roomType.PricePerNight)
            .IsRequired();

        builder.ToTable(roomType =>
            roomType
            .HasCheckConstraint
            ("CK_RoomType_PriceRange", "[PricePerNight] >= 0"));
    }
}