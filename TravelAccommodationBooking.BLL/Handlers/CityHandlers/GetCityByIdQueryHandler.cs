using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.City;
using TravelAccommodationBooking.BLL.Queries.CityQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.CityHandlers;

public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto?>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCityByIdQueryHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityDto?> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.Id, request.IncludeHotels);
        return _mapper.Map<CityDto>(city);
    }
}