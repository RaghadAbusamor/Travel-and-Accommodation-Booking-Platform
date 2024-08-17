using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.DiscountCommands;
using TravelAccommodationBooking.BLL.DTO.DIscount;
using TravelAccommodationBooking.BLL.Queries.DiscountQueries;
using TravelAccommodationBooking.Model.Entities.Hotel;

namespace TravelAccommodationBooking.BLL.Profiles;

public class DiscountProfile : Profile
{
    public DiscountProfile()
    {
        CreateMap<Discount, DiscountDto>();
        CreateMap<DiscountDto, Discount>();

        // Commands and Queries
        CreateMap<GetAllRoomTypeDiscountsDto, GetAllRoomTypeDiscountsQuery>();
        CreateMap<DiscountForCreationDto, CreateDiscountCommand>();
        CreateMap<CreateDiscountCommand, Discount>();
    }
}