using Microsoft.AspNetCore.Mvc;
using NetBootcamp.API.Controllers;
using NetBootcamp.Service.Users;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.API.Users
{
    
    public class UsersController(IUserService userService) : CustomBaseController
    {
        [HttpGet]
        public IActionResult GetAll() => Ok(userService.GetAll());

        [HttpGet("{userId}")]
        public IActionResult GetById(int userId) => CreateActionResult(userService.GetById(userId));

        [HttpPost]
        public IActionResult Create(UserCreateRequestDto request)
        {
            var result = userService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { userId = result.Data});

        }

        [HttpPut("{userId}")]
        public IActionResult Update(int userId, UserUpdateRequestDto request) => CreateActionResult(userService.Update(userId, request));

        [HttpDelete("{userId}")]
        public IActionResult Delete(int userId) => CreateActionResult(userService.Delete(userId));

    }
}
