﻿using FluentValidation.Results;
using AdvertisementApp.Common.ResponseObjects;

namespace AdvertisementApp.Business.Extensions
{
    // list of validation error returner. this is an extensor for ValidationResult class
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();

            foreach(var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }

            return errors;
        }
    }
}
