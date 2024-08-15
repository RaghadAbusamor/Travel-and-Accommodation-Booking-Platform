using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelWithoutRoomsDto?>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetHotelByIdQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<HotelWithoutRoomsDto?> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.Id);
        return _mapper.Map<HotelWithoutRoomsDto>(hotel);
    }
}