using FluentValidation;
using NetBootcamp.Service.Products.DTOs;

namespace NetBootcamp.Service.Products.ProductUpdateNameUseCase
{
    public class ProductUpdateNameRequestValidator : AbstractValidator<ProductUpdateNameRequestDto>
    {
        public ProductUpdateNameRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("urun alani bos gecilemez")
                .NotNull().WithMessage("urun alani bos gecilemez")
                .Length(5, 15).WithMessage("urun isim uzunlugu minumum 5 maksimum 15 olabilir");
        }
    }
}
