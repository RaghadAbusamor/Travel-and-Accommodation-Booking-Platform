using Application.DTOs.RoomAmenityDtos;
using FluentValidation;
using TravelAccommodationBooking.Web.Validators;

namespace TravelAccommodationBooking.Web.Validators.RoomAmenityValidators;

public class CreateRoomAmenityValidator : GenericValidator<RoomAmenityForCreationDto>
{
    public CreateRoomAmenityValidator()
    {
        RuleFor(roomAmenity => roomAmenity.Name)
            .NotEmpty()
            .WithMessage("Name field shouldn't be empty");

        RuleFor(roomAmenity => roomAmenity.Description)
            .NotEmpty()
            .WithMessage("Description field shouldn't be empty");
    }
}