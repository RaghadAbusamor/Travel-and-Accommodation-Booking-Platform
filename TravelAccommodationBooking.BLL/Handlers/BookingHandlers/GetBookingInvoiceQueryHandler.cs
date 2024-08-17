using TravelAccommodationBooking.BLL.DTO.Booking;
using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Queries.BookingQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.BookingHandlers;

public class GetBookingInvoiceQueryHandler : IRequestHandler<GetBookingInvoiceQuery, InvoiceDto>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;

    public GetBookingInvoiceQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public async Task<InvoiceDto> Handle(GetBookingInvoiceQuery request,
    CancellationToken cancellationToken)
    {
        return _mapper.Map<InvoiceDto>(await _bookingRepository
        .GetInvoiceByBookingIdAsync(request.BookingId));
    }
}