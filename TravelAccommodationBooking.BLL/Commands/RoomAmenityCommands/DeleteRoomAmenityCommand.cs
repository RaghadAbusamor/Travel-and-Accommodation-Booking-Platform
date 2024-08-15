using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.RoomAmenityCommands;

public record DeleteRoomAmenityCommand : IRequest
{
    public Guid Id { get; set; }
}