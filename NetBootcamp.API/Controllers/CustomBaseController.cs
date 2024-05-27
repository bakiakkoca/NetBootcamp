using System.Net;
using Microsoft.AspNetCore.Mvc;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResult<T>(ResponseModelDto<T> response, string methodName, object routeValues)
        {
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return CreatedAtAction(methodName, routeValues, response);
            }

            return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
        }

        public IActionResult CreateActionResult<T>(ResponseModelDto<T> response)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = 204 };
            }

            return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
        }

    }
}
