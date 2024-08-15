using MediatR;
using TravelAccommodationBooking.BLL.DTO.RoomFeature;

namespace TravelAccommodationBooking.BLL.Queries.RoomAmenityQueries;

public record GetRoomAmenityByIdQuery : IRequest<RoomAmenityDto?>
{
    public Guid Id { get; set; }
}