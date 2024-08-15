using AutoMapper;
using Domain.Common.Models;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Room;
using TravelAccommodationBooking.BLL.Queries.RoomQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomHandlers;

public class GetRoomsByHotelIdQueryHandler : IRequestHandler<GetRoomsByHotelIdQuery, PaginatedList<RoomDto>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public GetRoomsByHotelIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RoomDto>> Handle(GetRoomsByHotelIdQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await
            _roomRepository.GetRoomsByHotelIdAsync
            (request.HotelId,
            request.SearchQuery,
            request.PageNumber,
            request.PageSize);

        return new PaginatedList<RoomDto>(
            _mapper.Map<List<RoomDto>>(paginatedList.Items),
            paginatedList.PageData);
    }
}