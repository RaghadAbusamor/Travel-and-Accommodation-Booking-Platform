using Application.Commands.CityCommands;
using Application.DTOs.CityDtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.CityHandlers;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CityWithoutHotelsDto?>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityWithoutHotelsDto?> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var cityToAdd = _mapper.Map<City>(request);
        var addedCity = await _cityRepository.InsertAsync(cityToAdd);
        return addedCity is null ? null : _mapper.Map<CityWithoutHotelsDto>(addedCity);
    }
}