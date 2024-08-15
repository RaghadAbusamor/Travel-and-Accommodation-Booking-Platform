﻿using MediatR;
using TravelAccommodationBooking.BLL.DTO.Hotel;

namespace TravelAccommodationBooking.BLL.Commands.HotelCommands;

public class CreateHotelCommand : IRequest<HotelWithoutRoomsDto?>
{
    public Guid CityId { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; }
    public float Rating { get; set; }
    public string StreetAddress { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public int FloorsNumber { get; set; }
}