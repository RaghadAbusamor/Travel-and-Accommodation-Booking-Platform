﻿namespace TravelAccommodationBooking.BLL.DTO.Hotel;

public record HotelForCreationDto
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