using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.DiscountCommands;

public record DeleteDiscountCommand : IRequest
{
    public Guid Id { get; set; }
}