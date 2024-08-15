using Application.Commands.RoomCommands;
using AutoMapper;
using Domain.Entities;
using TravelAccommodationBooking.BLL.DTO.Room;
using TravelAccommodationBooking.BLL.Queries.RoomQueries;

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