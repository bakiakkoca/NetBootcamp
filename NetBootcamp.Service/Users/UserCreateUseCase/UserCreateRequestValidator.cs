using FluentValidation;
using NetBootcamp.Repository;
using NetBootcamp.Repository.Users;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.Service.Users.UserCreateUseCase
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequestDto>
    {
        public UserCreateRequestValidator(IGenericRepository<User> userRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("isim alani gereklidir.")
                .NotNull().WithMessage("isim alani gereklidir.")
                .Length(5, 15).WithMessage("isim uzunlugu 5-15 karakter olmalidir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("soyadi alani gereklidir.")
                .NotNull().WithMessage("soyadi alani gereklidir.")
                .Length(5, 15).WithMessage("soyadi uzunlugu 5-15 karakter olmalidir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("mail alani gereklidir.")
                .NotNull().WithMessage("mail alani gereklidir.")
                .EmailAddress().WithMessage("mail adresini duzgun giriniz");


        }

        
    }
}
