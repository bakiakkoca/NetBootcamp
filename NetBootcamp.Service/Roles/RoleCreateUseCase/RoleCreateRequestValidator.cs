﻿using System;
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
                .NotEmpty().WithMessage("role alani gereklidir.")
                .NotNull().WithMessage("role alani gereklidir.")
                .Length(5, 15).WithMessage("role uzunlugu 5-15 karakter olmalidir.");

        }

    }
}
