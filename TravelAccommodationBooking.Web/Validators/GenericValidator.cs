﻿using FluentValidation;

namespace TravelAccommodationBooking.Web.Validators;

public class GenericValidator<T> : AbstractValidator<T>
{
    public async Task<List<ErrorModel>> CheckForValidationErrorsAsync(T request)
    {
        var results = await ValidateAsync(request);

        return !results.IsValid
            ? await Task.FromResult(results.Errors.Select(failure =>
                new ErrorModel
                {
                    FieldName = failure.PropertyName,
                    Message = failure.ErrorMessage
                }).ToList())
            : new List<ErrorModel>();
    }
}