using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.BookingCommands;
using TravelAccommodationBooking.BLL.DTO.Booking;
using TravelAccommodationBooking.BLL.Queries.BookingQueries;
using TravelAccommodationBooking.Model.Entities.Billing;
using TravelAccommodationBooking.Model.Entities.Hotel;

namespace TravelAccommodationBooking.BLL.Profiles;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>();
        CreateMap<Invoice, InvoiceDto>();

        // Commands and Queries
        CreateMap<BookingQueryDto, GetBookingsByHotelIdQuery>();
        CreateMap<ReserveRoomDto, ReserveRoomCommand>();
        CreateMap<ReserveRoomCommand, Booking>();
    }
}