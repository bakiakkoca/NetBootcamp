using Microsoft.AspNetCore.Mvc;
using NetBootcamp.API.Controllers;
using NetBootcamp.Service.Users;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.API.Users
{

    public class UsersController(IUserService userService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() 
            => Ok(await userService.GetAll());

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId) 
            => CreateActionResult(await userService.GetById(userId));

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateRequestDto request)
        {
            var result = await userService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { userId = result.Data});

        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(int userId, UserUpdateRequestDto request) 
            => CreateActionResult(await userService.Update(userId, request));

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId) 
            => CreateActionResult(await userService.Delete(userId));

        [HttpPut("UpdateNameUser")]
        public async Task<IActionResult> UpdateNameUser(UserUpdateNameRequestDto request)
            => CreateActionResult(await userService.UpdateNameUser(request.Id, request.Name));
        

    }
}
