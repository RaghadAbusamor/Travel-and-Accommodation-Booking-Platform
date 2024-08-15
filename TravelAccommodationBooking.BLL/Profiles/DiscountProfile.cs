using Application.Commands.DiscountCommands;
using AutoMapper;
using Domain.Entities;
using TravelAccommodationBooking.BLL.DTO.DIscount;
using TravelAccommodationBooking.BLL.Queries.DiscountQueries;

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