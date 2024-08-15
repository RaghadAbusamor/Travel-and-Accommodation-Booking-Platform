using MediatR;
using TravelAccommodationBooking.BLL.DTO.DIscount;

namespace TravelAccommodationBooking.BLL.Queries.DiscountQueries;

public record GetDiscountByIdQuery : IRequest<DiscountDto>
{
    public Guid Id { get; set; }
}