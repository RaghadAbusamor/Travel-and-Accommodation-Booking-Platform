using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.RoomCategoryQueries;

public record CheckRoomTypeExistsQuery : IRequest<bool>
{
    public Guid Id { get; set; }
}