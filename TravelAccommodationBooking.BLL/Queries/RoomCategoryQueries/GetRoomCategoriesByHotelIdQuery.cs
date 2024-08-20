using Domain.Common.Models;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.RoomType;
using TravelAccommodationBooking.Model.Entities.Utilities;

namespace TravelAccommodationBooking.BLL.Queries.RoomCategoryQueries;

public record GetRoomCategoriesByHotelIdQuery : IRequest<PaginatedList<RoomTypeDto>>
{
    public Guid HotelId { get; set; }
    public bool IncludeAmenities { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}