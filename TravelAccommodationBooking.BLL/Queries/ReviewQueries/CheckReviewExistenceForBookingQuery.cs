using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.ReviewQueries;

public record CheckReviewExistenceForBookingQuery : IRequest<bool>
{
    public Guid BookingId { get; set; }
}