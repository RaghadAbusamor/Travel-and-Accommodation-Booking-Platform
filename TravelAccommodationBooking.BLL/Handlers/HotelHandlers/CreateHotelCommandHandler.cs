using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.HotelCommands;
using TravelAccommodationBooking.BLL.DTO.Hotel;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, HotelWithoutRoomsDto?>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public CreateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<HotelWithoutRoomsDto?> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotelToAdd = _mapper.Map<Hotel>(request);
        var addedHotel = await _hotelRepository.InsertAsync(hotelToAdd);
        return addedHotel is null ? null : _mapper.Map<HotelWithoutRoomsDto>(addedHotel);
    }
}