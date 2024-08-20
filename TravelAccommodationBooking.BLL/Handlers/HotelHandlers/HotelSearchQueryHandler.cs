using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;
using TravelAccommodationBooking.Model.Entities.Search;
using TravelAccommodationBooking.Model.Entities.Utilities;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class HotelSearchQueryHandler : IRequestHandler<HotelSearchQuery, PaginatedList<HotelSearchResult>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public HotelSearchQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<HotelSearchResult>> Handle(HotelSearchQuery request,
    CancellationToken cancellationToken)
    {
        var hotelSearchParameters = _mapper.Map<HotelSearchParameters>(request);
        return await _hotelRepository.HotelSearchAsync(hotelSearchParameters);
    }
}