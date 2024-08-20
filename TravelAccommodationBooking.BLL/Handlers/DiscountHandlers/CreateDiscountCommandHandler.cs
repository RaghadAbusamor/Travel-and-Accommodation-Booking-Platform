using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.DiscountCommands;
using TravelAccommodationBooking.BLL.DTO.DIscount;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.DiscountHandlers;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, DiscountDto?>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<DiscountDto?> Handle(CreateDiscountCommand request,
    CancellationToken cancellationToken)
    {
        var discountToAdd = _mapper.Map<Discount>(request);
        var addedDiscount = await _discountRepository.InsertAsync(discountToAdd);
        return _mapper.Map<DiscountDto>(addedDiscount);
    }
}