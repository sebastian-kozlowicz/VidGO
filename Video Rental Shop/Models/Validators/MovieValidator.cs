using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Name).Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("The Movie Title field is required");

            RuleFor(m => m.ReleaseDate).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Release Date field is required")
                .LessThan(m => DateTime.Now).WithMessage($"Release Date must be less than {((DateTime.Now).AddDays(1)).ToString("dd/MM/yyyy")}");

            RuleFor(m => m.NumberInStock).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Number In Stock field is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(m => m.Price).Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("The Price field is required")
               .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}