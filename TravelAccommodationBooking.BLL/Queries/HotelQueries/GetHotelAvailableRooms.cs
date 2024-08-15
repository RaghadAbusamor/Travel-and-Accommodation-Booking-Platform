using MediatR;
using TravelAccommodationBooking.BLL.DTO.Room;

namespace TravelAccommodationBooking.BLL.Queries.HotelQueries;

public record GetHotelAvailableRoomsQuery : IRequest<List<RoomDto>>
{
    public Guid HotelId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}