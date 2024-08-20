using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.DIscount;
using TravelAccommodationBooking.BLL.Queries.DiscountQueries;
using TravelAccommodationBooking.Model.Entities.Utilities;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.DiscountHandlers;

public class GetAllRoomTypeDiscountsQueryHandler : IRequestHandler<GetAllRoomTypeDiscountsQuery, PaginatedList<DiscountDto>>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public GetAllRoomTypeDiscountsQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DiscountDto>> Handle(GetAllRoomTypeDiscountsQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await
            _discountRepository
                .GetAllByRoomTypeIdAsync(
                    request.RoomTypeId,
                    request.PageNumber,
                    request.PageSize);

        return new PaginatedList<DiscountDto>(
            _mapper.Map<List<DiscountDto>>(paginatedList.Items),
            paginatedList.PageData);
    }
}