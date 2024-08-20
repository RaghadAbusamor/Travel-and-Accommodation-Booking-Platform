using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.RoomType;
using TravelAccommodationBooking.BLL.Queries.RoomCategoryQueries;
using TravelAccommodationBooking.Model.Entities.Utilities;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomCategoryHandlers;

public class GetRoomCategoriesByHotelIdQueryHandler :
IRequestHandler<GetRoomCategoriesByHotelIdQuery, PaginatedList<RoomTypeDto>>
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IMapper _mapper;

    public GetRoomCategoriesByHotelIdQueryHandler(IRoomTypeRepository roomTypeRepository, IMapper mapper)
    {
        _roomTypeRepository = roomTypeRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RoomTypeDto>> Handle(GetRoomCategoriesByHotelIdQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await
            _roomTypeRepository
                .GetAllAsync(
                request.HotelId,
                request.IncludeAmenities,
                request.PageNumber,
                request.PageSize
                );

        return new PaginatedList<RoomTypeDto>(
            _mapper.Map<List<RoomTypeDto>>(paginatedList.Items),
            paginatedList.PageData);
    }
}