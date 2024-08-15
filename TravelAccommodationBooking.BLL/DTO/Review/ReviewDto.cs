﻿namespace TravelAccommodationBooking.BLL.DTO.Review;

public record ReviewDto
{
    public Guid Id { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public float Rating { get; set; }
}