using System.Collections.Immutable;
using NetBootcamp.Service.Products.DTOs;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.Service.Products
{
    public interface IProductService
    {
        Task<ResponseModelDto<ImmutableList<ProductDto>>> GetAll();
        Task<ResponseModelDto<ProductDto?>> GetById(int id);

        Task<ResponseModelDto<int>> Create (ProductCreateRequestDto request);

        Task<ResponseModelDto<NoContent>> Delete(int id);
        Task<ResponseModelDto<NoContent>> Update(int id, ProductUpdateRequestDto request);

        Task<ResponseModelDto<NoContent>> UpdateProductName(int id, string name);
    }
}
