using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NetBootcamp.Service.Products.DTOs;

namespace NetBootcamp.Service.Products.ProductCreateUseCase
{
    public class ProductCreateRequestValidator : AbstractValidator<ProductCreateRequestDto>
    {
        public ProductCreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("urun alani bos gecilemez")
                .NotNull().WithMessage("urun alani bos gecilemez")
                .Length(5, 15).WithMessage("urun isim uzunlugu minumum 5 maxsimum 15 olabilir");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("fiyat alani bos gecilemez")
                .NotNull().WithMessage("fiyat alani bos gecilemez");

            RuleFor(x => x.Stock)
                .NotEmpty().WithMessage("stock alani bos gecilemez")
                .NotNull().WithMessage("stock alani bos gecilemez");

        }
    }
}
