using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.RoomAmenityCommands;

public record UpdateRoomAmenityCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}