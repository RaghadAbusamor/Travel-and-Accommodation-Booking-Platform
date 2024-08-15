using AutoMapper;
using Domain.Entities;
using TravelAccommodationBooking.BLL.DTO.RoomType;
using TravelAccommodationBooking.BLL.Queries.RoomCategoryQueries;

namespace TravelAccommodationBooking.BLL.Profiles;

public class RoomCategoryProfile : Profile
{
    public RoomCategoryProfile()
    {
        CreateMap<RoomType, RoomTypeDto>()
            .ForMember
            (roomDto => roomDto.Amenities,
                opt => opt.MapFrom(room => room.Amenities)
            );
        CreateMap<RoomTypeDto, RoomCategoryWithoutAmenitiesDto>();

        // Commands and Queries
        CreateMap<GetRoomCategoriesByHotelIdDto, GetRoomCategoriesByHotelIdQuery>();
    }
}