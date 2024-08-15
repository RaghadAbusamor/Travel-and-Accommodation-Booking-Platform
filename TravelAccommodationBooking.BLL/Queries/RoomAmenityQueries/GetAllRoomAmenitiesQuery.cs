using Domain.Common.Models;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.RoomFeature;

namespace TravelAccommodationBooking.BLL.Queries.RoomAmenityQueries;

public record GetAllRoomAmenitiesQuery : IRequest<PaginatedList<RoomAmenityDto>>
{
    public string? SearchQuery { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}