using MediatR;
using TravelAccommodationBooking.BLL.Queries.ReviewQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.ReviewHandlers;

public class CheckReviewExistenceForBookingQueryHandler : IRequestHandler<CheckReviewExistenceForBookingQuery, bool>
{
    private readonly IReviewRepository _reviewRepository;

    public CheckReviewExistenceForBookingQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<bool> Handle(CheckReviewExistenceForBookingQuery request, CancellationToken cancellationToken)
    {
        return await _reviewRepository.DoesBookingHaveReviewAsync(request.BookingId);
    }
}