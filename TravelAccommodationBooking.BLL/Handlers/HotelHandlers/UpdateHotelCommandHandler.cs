using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.HotelCommands;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Exceptions;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public UpdateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        if (!await _hotelRepository.IsExistsAsync(request.Id))
        {
            throw new NotFoundException($"Hotel with ID {request.Id} does not exist.");
        }
        var roomAmenityToUpdate = _mapper.Map<Hotel>(request);
        await _hotelRepository.UpdateAsync(roomAmenityToUpdate);
    }
}