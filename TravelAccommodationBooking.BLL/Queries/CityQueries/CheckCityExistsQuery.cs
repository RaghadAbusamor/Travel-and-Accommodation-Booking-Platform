using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.CityQueries;

public class CheckCityExistsQuery : IRequest<bool>
{
    public Guid Id { get; set; }
}