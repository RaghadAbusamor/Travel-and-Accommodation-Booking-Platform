﻿namespace TravelAccommodationBooking.BLL.DTO.City;

public record CityForCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string PostOffice { get; set; } = string.Empty;
}