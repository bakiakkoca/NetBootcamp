using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NetBootcamp.Service.Roles.DTOs;

namespace NetBootcamp.Service.Roles.RoleCreateUseCase
{
    public class RoleCreateRequestValidator : AbstractValidator<RoleCreateRequestDto>
    {
        public RoleCreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("isim alani gereklidir.")
                .NotNull().WithMessage("isim alani gereklidir.")
                .Length(5, 15).WithMessage("isim uzunlugu 5-15 karakter olmalidir.");

        }

    }
}
