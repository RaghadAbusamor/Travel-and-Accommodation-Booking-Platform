using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;

namespace TravelAccommodationBooking.BLL.Queries.UserQueries;

public record GetRecentlyVisitedHotelsForGuestQuery : IRequest<List<HotelWithoutRoomsDto>>
{
    public Guid GuestId { get; set; }
    public int Count { get; set; } = 5;
}