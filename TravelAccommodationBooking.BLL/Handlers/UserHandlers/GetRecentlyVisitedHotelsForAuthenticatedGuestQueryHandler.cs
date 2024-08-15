using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;
using TravelAccommodationBooking.BLL.Queries.UserQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.UserHandlers;

public class GetRecentlyVisitedHotelsForAuthenticatedGuestQueryHandler :
    IRequestHandler<GetRecentlyVisitedHotelsForAuthenticatedGuestQuery, List<HotelWithoutRoomsDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetRecentlyVisitedHotelsForAuthenticatedGuestQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<HotelWithoutRoomsDto>> Handle(GetRecentlyVisitedHotelsForAuthenticatedGuestQuery request,
        CancellationToken cancellationToken)
    {
        return _mapper.Map<List<HotelWithoutRoomsDto>>
        (await _userRepository
        .GetRecentlyVisitedHotelsForAuthenticatedGuestAsync
        (request.Email, request.Count));
    }
}