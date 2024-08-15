using Domain.Common.Models;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.DIscount;

namespace TravelAccommodationBooking.BLL.Queries.DiscountQueries;

public record GetAllRoomTypeDiscountsQuery : IRequest<PaginatedList<DiscountDto>>
{
    public Guid RoomTypeId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}