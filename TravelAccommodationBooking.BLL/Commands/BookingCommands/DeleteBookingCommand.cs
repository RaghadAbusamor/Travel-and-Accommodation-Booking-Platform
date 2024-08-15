using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.BookingCommands;

public record DeleteBookingCommand : IRequest
{
    public Guid Id { get; set; }
}