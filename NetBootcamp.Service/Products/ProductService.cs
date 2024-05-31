using System.Collections.Immutable;
using System.Net;
using AutoMapper;
using NetBootcamp.Repository;
using NetBootcamp.Repository.Products;
using NetBootcamp.Service.Products.DTOs;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.Service.Products
{
    public class ProductService(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) 
        : IProductService
    {
        public async Task<ResponseModelDto<ImmutableList<ProductDto>>> GetAll()
        {
            var allProduct = await productRepository.GetAll();
            var userListAsDto = mapper.Map<List<ProductDto>>(allProduct);
            return ResponseModelDto<ImmutableList<ProductDto>>.Success(userListAsDto.ToImmutableList());

        }

        public async Task<ResponseModelDto<ProductDto?>> GetById(int id)
        {
            var hasProduct = await productRepository.GetById(id);
            if (hasProduct is null)
            {
                return ResponseModelDto<ProductDto?>.Fail("Urun bulunamadi", HttpStatusCode.NotFound);
            }

            var productAsDto = mapper.Map<ProductDto>(hasProduct);
            return ResponseModelDto<ProductDto?>.Success(productAsDto);
        }

        public async Task<ResponseModelDto<int>> Create(ProductCreateRequestDto request)
        {
            var newProduct = new Product
            {
                Name = request.Name.Trim(),
                Price = request.Price,
                Stock = request.Stock,
                Barcode = Guid.NewGuid().ToString(),
                Created = DateTime.Now
            };

            await productRepository.Create(newProduct);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<int>.Success(newProduct.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await productRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int id, ProductUpdateRequestDto request)
        {
            var hasProduct = await productRepository.GetById(id);
            hasProduct.Name = request.Name;
            hasProduct.Price = request.Price;
            hasProduct.Stock = request.Stock;

            await productRepository.Update(hasProduct);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateProductName(int id, string name)
        {
            await productRepository.UpdateProductName(name, id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}
