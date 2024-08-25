using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAccommodationBooking.Model.Entities.User;
using TravelAccommodationBooking.Model.Enums.User;

namespace TravelAccommodationBooking.Config.Common.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(user => user.FirstName)
            .IsRequired()
            .HasMaxLength(25);

        builder
            .Property(user => user.LastName)
            .IsRequired()
            .HasMaxLength(25);

        builder
            .Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasIndex(user => user.Email)
            .IsUnique();

        builder
            .Property(user => user.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder
            .Property(user => user.PasswordHash)
            .IsRequired();

        builder
            .Property(user => user.Role)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<UserRole>());
    }
}