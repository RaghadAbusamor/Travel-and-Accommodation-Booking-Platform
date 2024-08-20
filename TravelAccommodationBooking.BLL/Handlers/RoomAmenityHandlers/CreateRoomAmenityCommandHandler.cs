using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.RoomAmenityCommands;
using TravelAccommodationBooking.BLL.DTO.RoomFeature;
using TravelAccommodationBooking.Model.Entities.Rooms;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomAmenityHandlers;

public class CreateRoomAmenityCommandHandler : IRequestHandler<CreateRoomAmenityCommand, RoomAmenityDto?>
{
    private readonly IRoomAmenityRepository _roomAmenityRepository;
    private readonly IMapper _mapper;

    public CreateRoomAmenityCommandHandler(IRoomAmenityRepository roomAmenityRepository, IMapper mapper)
    {
        _roomAmenityRepository = roomAmenityRepository;
        _mapper = mapper;
    }

    public async Task<RoomAmenityDto?> Handle(CreateRoomAmenityCommand request, CancellationToken cancellationToken)
    {
        var amenityToAdd = _mapper.Map<RoomFeature>(request);
        var addedAmenity = await _roomAmenityRepository.InsertAsync(amenityToAdd);
        return addedAmenity is null ? null : _mapper.Map<RoomAmenityDto>(addedAmenity);
    }
}