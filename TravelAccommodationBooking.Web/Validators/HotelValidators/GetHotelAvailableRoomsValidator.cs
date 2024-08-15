using Application.DTOs.RoomDtos;
using FluentValidation;
using TravelAccommodationBooking.Web.Validators;

namespace TravelAccommodationBooking.Web.Validators.HotelValidators;

public class GetHotelAvailableRoomsValidator : GenericValidator<GetHotelAvailableRoomsDto>
{
    public GetHotelAvailableRoomsValidator()
    {
        RuleFor(room => room.CheckInDate)
            .GreaterThan(DateTime.Today)
            .WithMessage("Check-in must be in the future.");

        RuleFor(room => room.CheckOutDate)
            .GreaterThanOrEqualTo(room => room.CheckInDate.AddDays(1))
            .WithMessage("Check-out must be at least one day after check-in.");
    }
}