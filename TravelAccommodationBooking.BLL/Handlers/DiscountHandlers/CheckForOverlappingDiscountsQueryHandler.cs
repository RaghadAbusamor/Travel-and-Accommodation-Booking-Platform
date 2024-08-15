using MediatR;
using TravelAccommodationBooking.BLL.Queries.DiscountQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.DiscountHandlers;

public class CheckForOverlappingDiscountsQueryHandler :
IRequestHandler<CheckForOverlappingDiscountQuery, bool>
{
    private readonly IDiscountRepository _discountRepository;

    public CheckForOverlappingDiscountsQueryHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public Task<bool> Handle(CheckForOverlappingDiscountQuery request, CancellationToken cancellationToken)
    {
        return _discountRepository.HasOverlappingDiscountAsync(request.RoomTypeId,
                   request.FromDate,
                   request.ToDate);
    }
}