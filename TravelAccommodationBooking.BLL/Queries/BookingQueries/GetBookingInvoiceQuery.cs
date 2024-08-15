using TravelAccommodationBooking.BLL.DTO.Booking;
using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.BookingQueries;

public record GetBookingInvoiceQuery : IRequest<InvoiceDto>
{
    public Guid BookingId { get; set; }
}