using FluentValidation;
using TravelAccommodationBooking.BLL.Queries.ReviewQueries;
using TravelAccommodationBooking.Web.Validators;

namespace TravelAccommodationBooking.Web.Validators.ReviewValidators;

public class ReviewsQueryValidator : GenericValidator<GetReviewsQuery>
{
    public ReviewsQueryValidator()
    {
        RuleFor(review => review.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");

        RuleFor(review => review.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0.")
            .LessThan(21)
            .WithMessage("Page Size can't be greater than 20");
    }
}