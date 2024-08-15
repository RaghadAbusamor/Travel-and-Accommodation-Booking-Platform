using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.HotelCommands;

public record DeleteHotelCommand : IRequest
{
    public Guid Id { get; set; }
}