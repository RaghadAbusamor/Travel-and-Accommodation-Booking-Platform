using Application.DTOs.BookingDtos;
using AutoMapper;
using Domain.Common.Models;
using MediatR;
using TravelAccommodationBooking.BLL.Queries.BookingQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.BookingHandlers;

public class GetBookingsByHotelIdQueryHandler : IRequestHandler<GetBookingsByHotelIdQuery, PaginatedList<BookingDto>>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;

    public GetBookingsByHotelIdQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BookingDto>> Handle(GetBookingsByHotelIdQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await
            _bookingRepository
            .GetAllByHotelIdAsync(
                request.HotelId,
                request.PageNumber,
                request.PageSize);

        return new PaginatedList<BookingDto>(
            _mapper.Map<List<BookingDto>>(paginatedList.Items),
            paginatedList.PageData);
    }
}