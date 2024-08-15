using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.BookingQueries;

public record CheckBookingExistsQuery : IRequest<bool>
{
    public Guid Id { get; set; }
};