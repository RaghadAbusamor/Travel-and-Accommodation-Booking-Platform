﻿using Application.Commands.BookingCommands;
using Application.DTOs.BookingDtos;
using AutoMapper;
using Domain.Common.Models;
using Domain.Entities;
using TravelAccommodationBooking.BLL.Queries.BookingQueries;

namespace TravelAccommodationBooking.BLL.Profiles;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>();
        CreateMap<Invoice, InvoiceDto>();

        // Commands and Queries
        CreateMap<BookingQueryDto, GetBookingsByHotelIdQuery>();
        CreateMap<ReserveRoomDto, ReserveRoomCommand>();
        CreateMap<ReserveRoomCommand, Booking>();
    }
}