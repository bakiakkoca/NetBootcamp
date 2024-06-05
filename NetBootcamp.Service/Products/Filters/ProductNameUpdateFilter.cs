using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetBootcamp.Repository.Products;
using NetBootcamp.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBootcamp.Service.Products.DTOs;

namespace NetBootcamp.Service.Products
{
    public class ProductNameUpdateFilter(IProductRepository productRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;
            
            var productIdFromAction = context.ActionArguments.Values.First()!;

            int productId = 0;

            if (actionName == "UpdateProductName" &&
                productIdFromAction is ProductNameUpdateRequestDto productNameUpdateRequestDto)
            {
                productId = productNameUpdateRequestDto.Id;
            }

            var hasProduct = productRepository.HasExist(productId).Result;

            if (!hasProduct)
            {
                var errorMessage = $"There is no product with id: {productId}";

                var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
