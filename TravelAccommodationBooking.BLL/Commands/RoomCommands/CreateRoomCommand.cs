using MediatR;
using TravelAccommodationBooking.BLL.DTO.Room;

namespace TravelAccommodationBooking.BLL.Commands.RoomCommands;

public record CreateRoomCommand : IRequest<RoomDto?>
{
    public Guid HotelId { get; set; }
    public Guid RoomTypeId { get; set; }
    public int AdultsCapacity { get; set; }
    public int ChildrenCapacity { get; set; }
    public string View { get; set; }
    public float Rating { get; set; }
}