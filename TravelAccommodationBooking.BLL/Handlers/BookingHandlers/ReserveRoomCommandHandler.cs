using TravelAccommodationBooking.Model.Entities.Hotel;
using AutoMapper;
using MediatR;
using TravelAccommodationBooking.Model.Interfaces;
using TravelAccommodationBooking.BLL.DTO.Booking;
using TravelAccommodationBooking.BLL.Commands.BookingCommands;

namespace TravelAccommodationBooking.BLL.Handlers.BookingHandlers;

public class ReserveRoomCommandHandler : IRequestHandler<ReserveRoomCommand, BookingDto?>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public ReserveRoomCommandHandler(IBookingRepository bookingRepository, IMapper mapper, IUserRepository userRepository, IRoomRepository roomRepository)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _roomRepository = roomRepository;
    }

    public async Task<BookingDto?> Handle(ReserveRoomCommand request, CancellationToken cancellationToken)
    {
        var bookingToAdd = _mapper.Map<Booking>(request);
        bookingToAdd.UserId = await _userRepository.GetGuestIdByEmailAsync(request.GuestEmail);
        bookingToAdd.Price = await _roomRepository.GetPriceForRoomWithDiscount(request.RoomId);
        var addedBooking = await _bookingRepository.InsertAsync(bookingToAdd);
        return _mapper.Map<BookingDto>(addedBooking);
    }
}