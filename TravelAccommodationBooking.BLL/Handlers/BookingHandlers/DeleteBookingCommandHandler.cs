using MediatR;
using TravelAccommodationBooking.BLL.Commands.BookingCommands;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.BookingHandlers;

public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
{
    private readonly IBookingRepository _bookingRepository;

    public DeleteBookingCommandHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingRepository.DeleteAsync(request.Id);
    }
}