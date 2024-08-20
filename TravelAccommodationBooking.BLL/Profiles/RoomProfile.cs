using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.RoomCommands;
using TravelAccommodationBooking.BLL.DTO.Rooms;
using TravelAccommodationBooking.BLL.Queries.RoomQueries;
using TravelAccommodationBooking.Model.Entities.Rooms;

namespace TravelAccommodationBooking.BLL.Profiles;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomDto>();

        // Commands and Queries
        CreateMap<CreateRoomCommand, Room>();
        CreateMap<GetRoomsByHotelIdDto, GetRoomsByHotelIdQuery>();
        CreateMap<RoomForCreationDto, CreateRoomCommand>();
    }
}