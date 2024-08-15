using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.RoomAmenityQueries;

public record CheckRoomAmenityExistsQuery : IRequest<bool>
{
    public Guid Id { get; set; }
}