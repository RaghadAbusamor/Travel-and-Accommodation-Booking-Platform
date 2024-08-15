using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;

namespace TravelAccommodationBooking.BLL.Queries.UserQueries;

public record GetRecentlyVisitedHotelsForAuthenticatedGuestQuery : IRequest<List<HotelWithoutRoomsDto>>
{
    public string Email { get; set; }
    public int Count { get; set; } = 5;
}