using AutoMapper;
using NetBootcamp.Repository.Products;
using NetBootcamp.Service.Products.DTOs;

namespace NetBootcamp.Service.Products.Configuration
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
