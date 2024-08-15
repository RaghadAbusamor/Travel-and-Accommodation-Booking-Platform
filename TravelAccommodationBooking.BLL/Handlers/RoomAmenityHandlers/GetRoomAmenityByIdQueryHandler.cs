using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.RoomFeature;
using TravelAccommodationBooking.BLL.Queries.RoomAmenityQueries;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.RoomAmenityHandlers;

public class GetRoomAmenityByIdQueryHandler : IRequestHandler<GetRoomAmenityByIdQuery, RoomAmenityDto>
{
    private readonly IRoomAmenityRepository _roomAmenityRepository;
    private readonly IMapper _mapper;

    public GetRoomAmenityByIdQueryHandler(IRoomAmenityRepository roomAmenityRepository, IMapper mapper)
    {
        _roomAmenityRepository = roomAmenityRepository;
        _mapper = mapper;
    }

    public async Task<RoomAmenityDto> Handle(GetRoomAmenityByIdQuery request, CancellationToken cancellationToken)
    {
        var roomAmenity = await _roomAmenityRepository.GetByIdAsync(request.Id);
        return _mapper.Map<RoomAmenityDto>(roomAmenity);
    }
}