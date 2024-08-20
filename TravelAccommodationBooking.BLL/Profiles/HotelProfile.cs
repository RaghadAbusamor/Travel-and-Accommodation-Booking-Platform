using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.HotelCommands;
using TravelAccommodationBooking.BLL.DTO.Hotel;
using TravelAccommodationBooking.BLL.DTO.Rooms;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Entities.Search;

namespace TravelAccommodationBooking.BLL.Profiles;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<Hotel, HotelDto>();
        CreateMap<HotelDto, HotelWithoutRoomsDto>();
        CreateMap<Hotel, HotelWithoutRoomsDto>();

        // Commands and Queries
        CreateMap<HotelForCreationDto, CreateHotelCommand>();
        CreateMap<CreateHotelCommand, Hotel>();
        CreateMap<Hotel, HotelWithoutRoomsDto>();
        CreateMap<HotelForUpdateDto, UpdateHotelCommand>();
        CreateMap<UpdateHotelCommand, Hotel>();
        CreateMap<GetHotelAvailableRoomsDto, GetHotelAvailableRoomsQuery>();
        CreateMap<HotelSearchQuery, HotelSearchParameters>();
        CreateMap<FeaturedDealDto, FeaturedDealDto>();
    }
}