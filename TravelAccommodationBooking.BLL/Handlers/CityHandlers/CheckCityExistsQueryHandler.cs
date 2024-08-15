using MediatR;
using TravelAccommodationBooking.BLL.Queries.CityQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.CityHandlers;

public class CheckCityExistsQueryHandler : IRequestHandler<CheckCityExistsQuery, bool>
{
    private readonly ICityRepository _cityRepository;

    public CheckCityExistsQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<bool> Handle(CheckCityExistsQuery request, CancellationToken cancellationToken)
    {
        return await _cityRepository.IsExistsAsync(request.Id);
    }
}