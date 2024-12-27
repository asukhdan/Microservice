using System;
using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator:AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
       RuleFor(temp=>temp.Email).NotEmpty().WithMessage("Email Is Required")
                                .EmailAddress().WithMessage("Invalid Email Address Format");

       RuleFor(temp=>temp.Password).NotEmpty().WithMessage("Password is Required");
    }

}
