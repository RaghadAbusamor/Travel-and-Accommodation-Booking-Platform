using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TravelAccommodationBooking.BLL.Profiles;

namespace TravelAccommodationBooking.BLL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBLL(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(
     typeof(CityProfile),
     typeof(HotelProfile),
     typeof(RoomAmenityProfile),
     typeof(ReviewProfile),
     typeof(RoomProfile),
     typeof(DiscountProfile));


        return services;
    }
}