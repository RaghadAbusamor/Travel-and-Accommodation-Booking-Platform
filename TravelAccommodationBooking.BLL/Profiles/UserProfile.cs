using Application.Commands.UserCommands;
using AutoMapper;
using Domain.Entities;
using TravelAccommodationBooking.BLL.DTO.User;

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