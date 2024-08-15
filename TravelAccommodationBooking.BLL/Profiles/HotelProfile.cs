using Application.Commands.HotelCommands;
using Application.Queries.CityQueries;
using AutoMapper;
using Domain.Common.Models;
using Domain.Entities;
using TravelAccommodationBooking.BLL.DTO.Hotel;
using TravelAccommodationBooking.BLL.DTO.Room;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;

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
        CreateMap<FeaturedDeal, FeaturedDealDto>();
    }
}