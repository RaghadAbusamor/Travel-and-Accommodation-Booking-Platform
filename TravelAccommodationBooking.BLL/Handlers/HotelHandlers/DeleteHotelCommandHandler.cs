using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.HotelCommands;
using TravelAccommodationBooking.Model.Exceptions;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public DeleteHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        if (!await _hotelRepository.IsExistsAsync(request.Id))
        {
            throw new NotFoundException("Room Amenity Doesn't Exists To Delete");
        }
        await _hotelRepository.DeleteAsync(request.Id);
    }
}