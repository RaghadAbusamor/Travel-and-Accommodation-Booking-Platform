using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.DiscountQueries;

public record CheckDiscountExistsQuery : IRequest<bool>
{
    public Guid Id { get; set; }
}