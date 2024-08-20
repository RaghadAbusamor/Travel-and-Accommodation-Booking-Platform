using AutoMapper;
using MediatR;
using TravelAccommodationBooking.BLL.Commands.UserCommands;
using TravelAccommodationBooking.Model.Entities.User;
using TravelAccommodationBooking.Model.Enums.User;
using TravelAccommodationBooking.Model.Interfaces;
using TravelAccommodationBooking.Security;

namespace TravelAccommodationBooking.BLL.Handlers.UserHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordGenerator _passwordGenerator;
    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordGenerator passwordGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordGenerator = passwordGenerator;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var uniqueUserSalt = _passwordGenerator.GenerateSalt();
        var userPasswordHash = _passwordGenerator.GenerateHashedPassword(request.Password, uniqueUserSalt);
        if (userPasswordHash is null) throw new InvalidOperationException("Can't Hash User Password");

        user.Id = Guid.NewGuid();
        user.PasswordHash = userPasswordHash;
        user.Salt = Convert.ToBase64String(uniqueUserSalt);
        user.Role = UserRole.Guest;
        await _userRepository.InsertAsync(user);
    }
}