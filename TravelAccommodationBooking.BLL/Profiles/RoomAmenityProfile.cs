using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.RoomAmenityCommands;
using TravelAccommodationBooking.BLL.DTO.RoomFeature;
using TravelAccommodationBooking.Model.Entities.Rooms;

namespace TravelAccommodationBooking.BLL.Profiles;

public class RoomAmenityProfile : Profile
{
    public RoomAmenityProfile()
    {
        CreateMap<RoomFeature, RoomAmenityDto>();
        CreateMap<RoomAmenityDto, RoomAmenityForUpdateDto>();

        // Commands and Queries
        CreateMap<RoomAmenityForCreationDto, CreateRoomAmenityCommand>();
        CreateMap<CreateRoomAmenityCommand, RoomFeature>();
        CreateMap<RoomAmenityForUpdateDto, UpdateRoomAmenityCommand>();
        CreateMap<UpdateRoomAmenityCommand, RoomFeature>();
    }
}