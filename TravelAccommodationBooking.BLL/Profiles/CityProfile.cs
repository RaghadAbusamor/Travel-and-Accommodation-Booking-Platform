using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.BookingCommands;
using TravelAccommodationBooking.BLL.Commands.CityCommands;
using TravelAccommodationBooking.BLL.DTO.City;
using TravelAccommodationBooking.Model.Entities.Hotel;

namespace TravelAccommodationBooking.BLL.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDto>()
            .ForMember
            (cityDto => cityDto.Hotels,
                opt => opt.MapFrom(city => city.Hotels));
        CreateMap<CityDto, CityWithoutHotelsDto>();
        CreateMap<City, CityWithoutHotelsDto>();
        CreateMap<CityDto, CityForUpdateDto>();

        // Commands and Queries
        CreateMap<CityForCreationDto, CreateCityCommand>();
        CreateMap<CityForUpdateDto, UpdateCityCommand>();
        CreateMap<UpdateCityCommand, City>();
        CreateMap<CreateCityCommand, City>();
    }
}