using FluentValidation;
using System;

namespace Video_Rental_Shop.Models.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(g => g.Name).Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("The Game Title field is required");

            RuleFor(g => g.ReleaseDate).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Release Date field is required")
                .LessThan(c => DateTime.Now).WithMessage($"Release Date must be less than {DateTime.Now.AddDays(1):dd-MM-yyyy}");

            RuleFor(m => m.NumberInStock).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Number In Stock field is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(m => m.Price).Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("The Price field is required")
               .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}