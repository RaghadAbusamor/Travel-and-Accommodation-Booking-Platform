using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.BookingCommands;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.CityHandlers;

public class UpdateCityHandler : IRequestHandler<UpdateCityCommand>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        if (!await _cityRepository.IsExistsAsync(request.Id))
        {
            throw new NotFoundException($"City With {request.Id} Doesn't Exists To Update");
        }

        var cityToUpdate = _mapper.Map<City>(request);
        await _cityRepository.UpdateAsync(cityToUpdate);
    }
}