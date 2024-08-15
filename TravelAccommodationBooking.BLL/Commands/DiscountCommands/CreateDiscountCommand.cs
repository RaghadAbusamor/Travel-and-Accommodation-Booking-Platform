using MediatR;
using TravelAccommodationBooking.BLL.DTO.DIscount;

namespace TravelAccommodationBooking.BLL.Commands.DiscountCommands;

public record CreateDiscountCommand : IRequest<DiscountDto?>
{
    public Guid RoomTypeId { get; set; }
    public float DiscountPercentage { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}