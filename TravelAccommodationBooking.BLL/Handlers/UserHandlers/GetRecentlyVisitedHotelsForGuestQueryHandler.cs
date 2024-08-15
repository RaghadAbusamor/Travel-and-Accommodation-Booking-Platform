using AutoMapper;
using Domain.Exceptions;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;
using TravelAccommodationBooking.BLL.Queries.UserQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.UserHandlers;

public class GetRecentlyVisitedHotelsForGuestQueryHandler :
    IRequestHandler<GetRecentlyVisitedHotelsForGuestQuery, List<HotelWithoutRoomsDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetRecentlyVisitedHotelsForGuestQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<HotelWithoutRoomsDto>> Handle(GetRecentlyVisitedHotelsForGuestQuery request,
        CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsExistsAsync(request.GuestId))
        {
            throw new NotFoundException($"User With ID {request.GuestId} Doesn't Exists.");
        }

        return _mapper.Map<List<HotelWithoutRoomsDto>>
        (await _userRepository
        .GetRecentlyVisitedHotelsForGuestAsync
        (request.GuestId, request.Count));
    }
}