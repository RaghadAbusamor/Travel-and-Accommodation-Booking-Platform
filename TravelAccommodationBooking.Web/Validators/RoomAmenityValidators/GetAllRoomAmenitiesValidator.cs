﻿using FluentValidation;
using TravelAccommodationBooking.BLL.Queries.RoomAmenityQueries;
using TravelAccommodationBooking.Web.Validators;

namespace TravelAccommodationBooking.Web.Validators.RoomAmenityValidators;

public class GetAllRoomAmenitiesValidator : GenericValidator<GetAllRoomAmenitiesQuery>
{
    public GetAllRoomAmenitiesValidator()
    {
        RuleFor(roomAmenity => roomAmenity.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");

        RuleFor(roomAmenity => roomAmenity.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0.")
            .LessThan(21)
            .WithMessage("Page Size can't be greater than 20");
    }
}