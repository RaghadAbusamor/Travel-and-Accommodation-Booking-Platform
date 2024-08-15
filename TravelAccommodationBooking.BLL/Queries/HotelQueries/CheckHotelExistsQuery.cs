using System.Diagnostics;
using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.HotelQueries;

public record CheckHotelExistsQuery : IRequest<bool>
{
    public Guid Id { get; set; }
}