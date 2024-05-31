using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.Service.Users.UserUpdateNameUseCase
{
    public class UserUpdateNameRequestValidator : AbstractValidator<UserUpdateNameRequestDto>
    {
        public UserUpdateNameRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("isim alani gereklidir.")
                .NotNull().WithMessage("isim alani gereklidir.")
                .Length(5, 15).WithMessage("isim uzunlugu 5-15 karakter olmalidir.");
        }
    }
}
