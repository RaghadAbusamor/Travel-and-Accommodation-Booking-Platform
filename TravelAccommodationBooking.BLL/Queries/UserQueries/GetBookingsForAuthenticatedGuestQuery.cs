﻿using Application.DTOs.BookingDtos;
using MediatR;

namespace TravelAccommodationBooking.BLL.Queries.UserQueries;

public record GetBookingsForAuthenticatedGuestQuery : IRequest<List<BookingDto>>
{
    public string Email { get; set; }
    public int Count { get; set; }
}