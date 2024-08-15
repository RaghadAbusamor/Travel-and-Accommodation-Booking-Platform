using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.CityCommands;

public record DeleteCityCommand : IRequest
{
    public Guid Id { get; set; }
}