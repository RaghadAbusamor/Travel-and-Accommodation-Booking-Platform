﻿using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.RoomCommands;
using TravelAccommodationBooking.BLL.DTO.Rooms;
using TravelAccommodationBooking.Model.Entities.Rooms;
using TravelAccommodationBooking.Model.Exceptions;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomHandlers;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomDto?>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public CreateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper, IRoomTypeRepository roomTypeRepository, IHotelRepository hotelRepository)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _roomTypeRepository = roomTypeRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<RoomDto?> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        if (!await _hotelRepository.IsExistsAsync(request.HotelId))
            throw new NotFoundException("Hotel doesn't exists.");

        if (!await _roomTypeRepository.IsExistsAsync(request.RoomTypeId))
            throw new NotFoundException("RoomCategory doesn't exists.");

        if (!await _roomTypeRepository
            .CheckRoomTypeExistenceForHotel(request.HotelId, request.RoomTypeId))
            throw new NotFoundException("The specified room category does not exist for the given hotel.");

        var roomToAdd = _mapper.Map<Room>(request);
        var addedRoom = await _roomRepository.InsertAsync(roomToAdd);
        return addedRoom is null ? null : _mapper.Map<RoomDto>(addedRoom);
    }
}