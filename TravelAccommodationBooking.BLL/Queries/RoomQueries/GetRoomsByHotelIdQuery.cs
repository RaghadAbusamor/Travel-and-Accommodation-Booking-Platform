using MediatR;
using TravelAccommodationBooking.BLL.DTO.Rooms;
using TravelAccommodationBooking.Model.Entities.Utilities;

namespace TravelAccommodationBooking.BLL.Queries.RoomQueries;

public record GetRoomsByHotelIdQuery : IRequest<PaginatedList<RoomDto>>
{
    public Guid HotelId { get; set; }
    public string? SearchQuery { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}