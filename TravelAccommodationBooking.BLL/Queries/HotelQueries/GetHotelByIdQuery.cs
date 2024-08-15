using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;

namespace TravelAccommodationBooking.BLL.Queries.HotelQueries;

public record GetHotelByIdQuery : IRequest<HotelWithoutRoomsDto?>
{
    public Guid Id { get; set; }
}