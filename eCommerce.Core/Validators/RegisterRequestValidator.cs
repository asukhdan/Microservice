using System;
using eCommerce.Core.DTO;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(temp=>temp.Email).NotEmpty().WithMessage("Email is required")
                                 .EmailAddress().WithMessage("Email address should be in correct format");

        RuleFor(temp=>temp.Password).NotEmpty().WithMessage("Password is required")
                                               .MinimumLength(6).WithMessage("Minimum Length is 6 character")
                                               .MaximumLength(10).WithMessage("Maximum Length is 6 character");
        RuleFor(temp=>temp.PersonName).NotEmpty().WithMessage("PersonName is required");

       //  RuleFor(temp=>temp.Gender).IsInEnum().WithMessage("Gender must be Male or Female");

    }

}
