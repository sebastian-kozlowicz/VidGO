using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("The Name field is required");

            RuleFor(c => c.Surname).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("The Surname field is required");

            RuleFor(c => c.Email).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("The e-mail field is required")
                .EmailAddress().WithMessage("The e-mail field does not contain a proper address");

            RuleFor(c => c.Birthdate).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("The Birthday field is required")
                .LessThan(c => DateTime.Now).WithMessage($"Birthdate must be less than {((DateTime.Now).AddDays(1)).ToString("dd-MM-yyyy")}");

            RuleFor(c => c.Balance).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("The Balance field is required")
                .GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to 0");

            RuleFor(c => c).Cascade(CascadeMode.StopOnFirstFailure)
                .Custom((c, context) =>
                {
                    if (c.MembershipTypeId != MembershipType.PayAsYouGo)
                    {
                        DateTime Current = DateTime.Today;
                        var age = Current.Year - Convert.ToDateTime(c.Birthdate).Year;

                        if (age < 18)
                            context.AddFailure(new ValidationFailure("Birthdate", "Customer should be at least 18 years old to go on a membership"));
                    }
                });
        }
    }
}