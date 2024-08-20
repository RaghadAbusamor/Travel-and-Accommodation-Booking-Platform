using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Enums.Image;
namespace TravelAccommodationBooking.Config.Common.Persistence.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder
            .Property(image => image.Format)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<ImageFormat>());

        builder
            .Property(image => image.EntityId)
            .IsRequired();

        builder
            .Property(image => image.Url)
            .IsRequired();

        builder
            .Property(image => image.Type)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<ImageCategory>());
    }
}