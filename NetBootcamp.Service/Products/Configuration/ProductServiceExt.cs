using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetBootcamp.Service.Products.ProductCreateUseCase;

namespace NetBootcamp.Service.Products.Configuration
{
    public static class ProductServiceExt
    {
        public static void AddProductService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddValidatorsFromAssemblyContaining<ProductCreateRequestValidator>();
        }

    }
}
