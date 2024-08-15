using Domain.Common.Models;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;

namespace TravelAccommodationBooking.BLL.Queries.HotelQueries;

public record GetAllHotelsQuery : IRequest<PaginatedList<HotelWithoutRoomsDto>>
{
    public string? SearchQuery { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}