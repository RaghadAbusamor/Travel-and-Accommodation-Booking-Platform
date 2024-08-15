using Application.DTOs.CityDtos;
using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.CityQueries;

public record GetTrendingCitiesQuery : IRequest<List<CityWithoutHotelsDto>>
{
    public int Count { get; set; } = 5;
}