using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;

namespace TravelAccommodationBooking.BLL.Queries.HotelQueries;

public record GetFeaturedDealsQuery : IRequest<List<FeaturedDealDto>>
{
    public int Count { get; set; } = 5;
}
