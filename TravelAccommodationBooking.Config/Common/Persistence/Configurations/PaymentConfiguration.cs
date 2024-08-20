using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Enums.Payment;

namespace TravelAccommodationBooking.Config.Common.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .Property(payment => payment.Status)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<PaymentStatus>());

        builder
            .Property(payment => payment.Method)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<PaymentMethod>());

        builder
            .HasIndex(payment => payment.Status);

        builder
            .HasIndex(payment => payment.Method);
    }
}