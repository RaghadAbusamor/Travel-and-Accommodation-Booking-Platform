using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Booking;
using TravelAccommodationBooking.BLL.Queries.UserQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.UserHandlers;

public class GetBookingsForAuthenticatedGuestQueryHandler :
    IRequestHandler<GetBookingsForAuthenticatedGuestQuery, List<BookingDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetBookingsForAuthenticatedGuestQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<BookingDto>> Handle(GetBookingsForAuthenticatedGuestQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<BookingDto>>
        (await _userRepository
        .GetBookingsForAuthenticatedGuestAsync
        (request.Email, request.Count));
    }
}