using MediatR;
using TravelAccommodationBooking.BLL.Queries.RoomQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomHandlers;

public class CheckRoomExistsQueryHandler : IRequestHandler<CheckRoomExistsQuery, bool>
{
    private readonly IRoomRepository _roomRepository;

    public CheckRoomExistsQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<bool> Handle(CheckRoomExistsQuery request, CancellationToken cancellationToken)
    {
        return await _roomRepository.IsExistsAsync(request.Id);
    }
}