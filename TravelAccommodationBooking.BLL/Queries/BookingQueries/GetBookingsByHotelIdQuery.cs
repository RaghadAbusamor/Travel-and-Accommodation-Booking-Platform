using TravelAccommodationBooking.Model.Entities.Utilities;
using TravelAccommodationBooking.BLL.DTO.Booking;
using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.BookingQueries;

public record GetBookingsByHotelIdQuery : IRequest<PaginatedList<BookingDto>>
{
    public Guid HotelId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}