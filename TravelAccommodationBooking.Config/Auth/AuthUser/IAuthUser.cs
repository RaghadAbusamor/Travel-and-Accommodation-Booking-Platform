using TravelAccommodationBooking.Config.Auth.Models;

namespace TravelAccommodationBooking.Config.Auth.AuthUser;

public interface IAuthUser
{
    public Task<User?> GetUserAsync(string email);
}