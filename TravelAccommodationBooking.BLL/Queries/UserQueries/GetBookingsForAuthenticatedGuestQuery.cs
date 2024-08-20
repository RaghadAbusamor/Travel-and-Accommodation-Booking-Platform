using MediatR;
using TravelAccommodationBooking.BLL.DTO.Booking;

namespace TravelAccommodationBooking.BLL.Queries.UserQueries;

public record GetBookingsForAuthenticatedGuestQuery : IRequest<List<BookingDto>>
{
    public string Email { get; set; }
    public int Count { get; set; }
}