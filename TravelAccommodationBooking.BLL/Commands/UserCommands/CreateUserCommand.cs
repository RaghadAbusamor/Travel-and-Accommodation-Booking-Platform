﻿using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.UserCommands;

public record CreateUserCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}
