using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Room;
using TravelAccommodationBooking.BLL.Queries.RoomQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomHandlers;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto?>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<RoomDto?> Handle(GetRoomByIdQuery request,
    CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId);
        return _mapper.Map<RoomDto>(room);
    }
}