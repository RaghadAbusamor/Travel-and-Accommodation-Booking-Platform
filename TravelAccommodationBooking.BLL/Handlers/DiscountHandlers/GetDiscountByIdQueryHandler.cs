using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.DIscount;
using TravelAccommodationBooking.BLL.Queries.DiscountQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.DiscountHandlers;

public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQuery, DiscountDto>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public GetDiscountByIdQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<DiscountDto> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
    {
        var discount = await _discountRepository.GetByIdAsync(request.Id);
        return _mapper.Map<DiscountDto>(discount);
    }
}