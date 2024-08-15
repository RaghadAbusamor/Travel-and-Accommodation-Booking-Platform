using TravelAccommodationBooking.Config.Auth.Models;

namespace TravelAccommodationBooking.Config.Auth.Token;

public interface ITokenGenerator
{
    public Task<string> GenerateToken(
        string email,
        string password,
        string secretKey,
        string issuer,
        string audience);

    public Task<User?> ValidateUserCredentials(string email, string password);
}