using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class GetFeaturedDealsQueryHandler : IRequestHandler<GetFeaturedDealsQuery, List<FeaturedDealDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetFeaturedDealsQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<List<FeaturedDealDto>> Handle(GetFeaturedDealsQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<FeaturedDealDto>>(await _hotelRepository.GetFeaturedDealsAsync(request.Count));
    }
}