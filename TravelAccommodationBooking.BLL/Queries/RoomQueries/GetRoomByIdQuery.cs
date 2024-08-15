using MediatR;
using TravelAccommodationBooking.BLL.DTO.Room;

namespace TravelAccommodationBooking.BLL.Queries.RoomQueries;

public record GetRoomByIdQuery : IRequest<RoomDto?>
{
    public Guid RoomId { get; set; }
}