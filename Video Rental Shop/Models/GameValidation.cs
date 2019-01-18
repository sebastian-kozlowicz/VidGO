using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models
{
    public class GameValidation : AbstractValidator<Game>
    {
        public GameValidation()
        {
            RuleFor(g=> g.Name).Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("The Game Title field is required");

            RuleFor(g => g.ReleaseDate).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Release Date field is required")
                .LessThan(c => DateTime.Now).WithMessage($"Release Date must be less than {((DateTime.Now).AddDays(1)).ToString("dd-MM-yyyy")}");

            RuleFor(m => m.NumberInStock).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Number In Stock field is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}