using MediatR;
using TravelAccommodationBooking.BLL.Queries.RoomQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomHandlers;

public record CheckRoomBelongsToHotelQueryHandler : IRequestHandler<CheckRoomBelongsToHotelQuery, bool>
{
    private readonly IRoomRepository _roomRepository;

    public CheckRoomBelongsToHotelQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<bool> Handle(CheckRoomBelongsToHotelQuery request,
    CancellationToken cancellationToken)
    {
        return await _roomRepository.
        CheckRoomBelongsToHotelAsync(request.HotelId, request.RoomId);
    }
}