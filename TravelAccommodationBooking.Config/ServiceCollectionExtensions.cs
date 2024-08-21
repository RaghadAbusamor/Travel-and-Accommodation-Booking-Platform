using Microsoft.Extensions.DependencyInjection;
using TravelAccommodationBooking.Config.Auth.AuthUser;
using TravelAccommodationBooking.Config.Auth.Token;
using TravelAccommodationBooking.Config.Common.Persistence.Repositories;
using TravelAccommodationBooking.Config.Email;
using TravelAccommodationBooking.Config.Email.Models;
using TravelAccommodationBooking.Config.ImageStorage;
using TravelAccommodationBooking.Config.Pdf;
using TravelAccommodationBooking.Model.Interfaces;
using TravelAccommodationBooking.Security;

namespace TravelAccommodationBooking.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(this IServiceCollection services)
    {
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<ITokenGenerator, JwtTokenGenerator>();
        services.AddTransient<IPasswordGenerator, Argon2PasswordGenerator>();
        services.AddScoped<IAuthUser, AuthUser>();
        services.AddScoped<IImageService, FireBaseImageService>();
        services.AddScoped<IRoomAmenityRepository, RoomAmenityRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        services.AddScoped<IPdfService, PdfService>();
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}