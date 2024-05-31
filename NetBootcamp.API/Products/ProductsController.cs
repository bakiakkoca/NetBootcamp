using Microsoft.AspNetCore.Mvc;
using NetBootcamp.API.Controllers;
using NetBootcamp.Service.Products;
using NetBootcamp.Service.Products.DTOs;

namespace NetBootcamp.API.Products
{

    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() 
            => Ok(await productService.GetAll());

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId) 
            => CreateActionResult(await productService.GetById(productId));

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequestDto request)
        {
            var result = await productService.Create(request);
            return CreateActionResult(result, nameof(GetById), new { productId = result.Data });
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(int productId, ProductUpdateRequestDto request) 
            => CreateActionResult(await productService.Update(productId, request));

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId) 
            => CreateActionResult(await productService.Delete(productId));

        [HttpPut("UpdateProductName")]
        public async Task<IActionResult> UpdateProductName(ProductUpdateNameRequestDto request) 
            => CreateActionResult(await productService.UpdateProductName(request.Id, request.Name));
    }

}
