using MediatR;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.HotelHandlers;

public class CheckHotelExistsQueryHandler : IRequestHandler<CheckHotelExistsQuery, bool>
{
    private readonly IHotelRepository _hotelRepository;

    public CheckHotelExistsQueryHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<bool> Handle(CheckHotelExistsQuery request, CancellationToken cancellationToken)
    {
        return await _hotelRepository.IsExistsAsync(request.Id);
    }
}