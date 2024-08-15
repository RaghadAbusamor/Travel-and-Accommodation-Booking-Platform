using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.RoomQueries;

public record CheckRoomBelongsToHotelQuery : IRequest<bool>
{
    public Guid HotelId { get; set; }
    public Guid RoomId { get; set; }
}