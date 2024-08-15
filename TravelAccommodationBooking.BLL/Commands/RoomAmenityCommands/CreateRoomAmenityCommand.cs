using MediatR;
using TravelAccommodationBooking.BLL.DTO.RoomFeature;

namespace TravelAccommodationBooking.BLL.Commands.RoomAmenityCommands;

public record CreateRoomAmenityCommand : IRequest<RoomAmenityDto?>
{
    public string Name { get; set; }
    public string Description { get; set; }
}