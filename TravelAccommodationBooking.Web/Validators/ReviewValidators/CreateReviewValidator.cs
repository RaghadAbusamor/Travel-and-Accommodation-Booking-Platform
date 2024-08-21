using FluentValidation;
using TravelAccommodationBooking.BLL.DTO.Review;
using TravelAccommodationBooking.Web.Validators;

namespace TravelAccommodationBooking.Web.Validators.ReviewValidators;

public class CreateReviewValidator : GenericValidator<ReviewForCreationDto>
{
    public CreateReviewValidator()
    {
        RuleFor(review => review.BookingId)
            .NotEmpty().WithMessage("BookingId field shouldn't be empty");

        RuleFor(review => review.Comment)
            .NotEmpty()
            .WithMessage("Comment field shouldn't be empty");

        RuleFor(review => review.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Rating must be between 0 and 5.");
    }
}