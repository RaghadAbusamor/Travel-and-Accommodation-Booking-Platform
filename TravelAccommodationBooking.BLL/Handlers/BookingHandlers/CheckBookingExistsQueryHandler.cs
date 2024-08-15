using MediatR;
using TravelAccommodationBooking.BLL.Queries.BookingQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.BookingHandlers;

public class CheckBookingExistsQueryHandler : IRequestHandler<CheckBookingExistsQuery, bool>
{
    private readonly IBookingRepository _bookingRepository;

    public CheckBookingExistsQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<bool> Handle(CheckBookingExistsQuery request, CancellationToken cancellationToken)
    {
        return await _bookingRepository.IsExistsAsync(request.Id);
    }
}