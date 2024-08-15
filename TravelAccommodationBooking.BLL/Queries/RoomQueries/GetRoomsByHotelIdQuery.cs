using Domain.Common.Models;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Room;

namespace TravelAccommodationBooking.BLL.Queries.RoomQueries;

public record GetRoomsByHotelIdQuery : IRequest<PaginatedList<RoomDto>>
{
    public Guid HotelId { get; set; }
    public string? SearchQuery { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}