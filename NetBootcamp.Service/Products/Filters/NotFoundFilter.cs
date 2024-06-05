using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetBootcamp.Repository.Products;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.Service.Products
{
    public class NotFoundFilter(IProductRepository productRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            var productIdFromAction = context.ActionArguments.Values.First()!;

            if (!int.TryParse(productIdFromAction.ToString(), out int productId))
            {
                return;
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
