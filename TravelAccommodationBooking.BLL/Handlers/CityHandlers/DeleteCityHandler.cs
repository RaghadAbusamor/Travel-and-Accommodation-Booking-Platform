using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.CityCommands;
using TravelAccommodationBooking.Model.Exceptions;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.CityHandlers;

public class DeleteCityHandler : IRequestHandler<DeleteCityCommand>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public DeleteCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        if (!await _cityRepository.IsExistsAsync(request.Id))
        {
            throw new NotFoundException("City Doesn't Exists To Delete");
        }
        await _cityRepository.DeleteAsync(request.Id);
    }
}