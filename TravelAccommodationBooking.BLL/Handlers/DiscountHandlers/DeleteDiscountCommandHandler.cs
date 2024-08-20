using MediatR;
using TravelAccommodationBooking.BLL.Commands.DiscountCommands;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.DiscountHandlers;

public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand>
{
    private readonly IDiscountRepository _discountRepository;

    public DeleteDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        await _discountRepository.DeleteAsync(request.Id);
    }
}