using MediatR;
using TravelAccommodationBooking.BLL.DTO.City;

namespace TravelAccommodationBooking.BLL.Queries.CityQueries;

public record GetCityByIdQuery : IRequest<CityDto?>
{
    public Guid Id { get; set; }
    public bool IncludeHotels { get; set; }
}