using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.RoomQueries;

public record CheckRoomExistsQuery : IRequest<bool>
{
    public Guid Id { get; set; }
}