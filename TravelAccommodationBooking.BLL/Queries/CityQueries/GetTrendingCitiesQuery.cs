using MediatR;
using TravelAccommodationBooking.BLL.DTO.City;

namespace TravelAccommodationBooking.BLL.Queries.CityQueries;

public record GetTrendingCitiesQuery : IRequest<List<CityWithoutHotelsDto>>
{
    public int Count { get; set; } = 5;
}