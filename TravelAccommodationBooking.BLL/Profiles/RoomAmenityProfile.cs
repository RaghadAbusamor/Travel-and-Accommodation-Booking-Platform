﻿using Application.Commands.RoomAmenityCommands;
using AutoMapper;
using Domain.Entities;
using TravelAccommodationBooking.BLL.DTO.RoomFeature;

namespace TravelAccommodationBooking.BLL.Profiles;

public class RoomAmenityProfile : Profile
{
    public RoomAmenityProfile()
    {
        CreateMap<RoomAmenity, RoomAmenityDto>();
        CreateMap<RoomAmenityDto, RoomAmenityForUpdateDto>();

        // Commands and Queries
        CreateMap<RoomAmenityForCreationDto, CreateRoomAmenityCommand>();
        CreateMap<CreateRoomAmenityCommand, RoomAmenity>();
        CreateMap<RoomAmenityForUpdateDto, UpdateRoomAmenityCommand>();
        CreateMap<UpdateRoomAmenityCommand, RoomAmenity>();
    }
}