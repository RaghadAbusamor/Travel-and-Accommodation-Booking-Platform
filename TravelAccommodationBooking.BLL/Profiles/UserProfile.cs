using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.UserCommands;
using TravelAccommodationBooking.BLL.DTO.User;
using TravelAccommodationBooking.Model.Entities.User;

namespace TravelAccommodationBooking.BLL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.PasswordHash,
            opt => opt.MapFrom(src => src.Password));
        CreateMap<UserForCreationDto, CreateUserCommand>();
    }
}