using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Rooms;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class GetHotelAvailableRoomsQueryHandler : IRequestHandler<GetHotelAvailableRoomsQuery, List<RoomDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetHotelAvailableRoomsQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<List<RoomDto>> Handle(GetHotelAvailableRoomsQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<RoomDto>>(await _hotelRepository
            .GetHotelAvailableRoomsAsync(
            request.HotelId,
            request.CheckInDate,
            request.CheckOutDate));
    }
}