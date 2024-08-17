using AutoMapper;
using TravelAccommodationBooking.BLL.DTO.RoomType;
using TravelAccommodationBooking.BLL.Queries.RoomCategoryQueries;
using TravelAccommodationBooking.Model.Entities.Rooms;

namespace TravelAccommodationBooking.BLL.Profiles;

public class RoomCategoryProfile : Profile
{
    public RoomCategoryProfile()
    {
        CreateMap<RoomType, RoomTypeDto>()
            .ForMember
            (roomDto => roomDto.Amenities,
                opt => opt.MapFrom(room => room.Features)
            );
        CreateMap<RoomTypeDto, RoomCategoryWithoutAmenitiesDto>();

        // Commands and Queries
        CreateMap<GetRoomCategoriesByHotelIdDto, GetRoomCategoriesByHotelIdQuery>();
    }
}