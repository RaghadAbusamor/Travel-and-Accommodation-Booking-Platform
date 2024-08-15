using MediatR;
using TravelAccommodationBooking.BLL.Queries.DiscountQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.DiscountHandlers;

public class CheckDiscountExistsQueryHandler : IRequestHandler<CheckDiscountExistsQuery, bool>
{
    private readonly IDiscountRepository _discountRepository;

    public CheckDiscountExistsQueryHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<bool> Handle(CheckDiscountExistsQuery request, CancellationToken cancellationToken)
    {
        return await _discountRepository.IsExistsAsync(request.Id);
    }
}