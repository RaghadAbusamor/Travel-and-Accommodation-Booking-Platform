using FluentValidation;
using TravelAccommodationBooking.BLL.Queries.HotelQueries;
using TravelAccommodationBooking.Web.Validators;

namespace TravelAccommodationBooking.Web.Validators.HomeValidators;

public class HotelSearchQueryValidator : GenericValidator<HotelSearchQuery>
{
    public HotelSearchQueryValidator()
    {
        RuleFor(query => query.CheckInDate)
            .GreaterThan(DateTime.Today)
            .WithMessage("Check-in must be in the future.");

        RuleFor(query => query.CheckOutDate)
            .GreaterThanOrEqualTo(booking => booking.CheckInDate.AddDays(1))
        .WithMessage("Check-out must be at least one day after check-in.");

        RuleFor(query => query.StarRate)
            .InclusiveBetween(0, 5).WithMessage("StarRate must be between 0 and 5.");

        RuleFor(query => query.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");

        RuleFor(query => query.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0.");

        RuleFor(query => query.Adults)
            .GreaterThan(0)
            .WithMessage("Adults must be greater than 0.");

        RuleFor(query => query.Children)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Children number must be greater than or equal 0.");
    }
}