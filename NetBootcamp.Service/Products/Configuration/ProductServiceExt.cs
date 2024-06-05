using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetBootcamp.Repository.Products;
using NetBootcamp.Service.Products.ProductCreateUseCase;
using NetBootcamp.Service.Products.ProductNameUpdateUseCase;

namespace NetBootcamp.Service.Products.Configuration
{
    public static class ProductServiceExt
    {
        public static void AddProductService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddValidatorsFromAssemblyContaining<ProductCreateRequestValidator>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddValidatorsFromAssemblyContaining<ProductNameUpdateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
            services.AddScoped<ProductNameUpdateFilter>();
        }

    }
}
