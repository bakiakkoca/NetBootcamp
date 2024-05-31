using Microsoft.AspNetCore.Mvc;
using NetBootcamp.API.Controllers;
using NetBootcamp.Repository;
using NetBootcamp.Repository.Roles;
using NetBootcamp.Service.Roles;
using NetBootcamp.Service.Roles.DTOs;

namespace NetBootcamp.API.Roles
{

    public class RolesController(IRoleService roleService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() 
            => Ok(await  roleService.GetAll());

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetById(int roleId) 
            => CreateActionResult(await roleService.GetById(roleId));

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateRequestDto request)
        {
            var result = await roleService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { roleId = result.Data });
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> Update(int roleId, RoleUpdateRequestDto request) 
            => CreateActionResult(await roleService.Update(roleId, request));

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> Delete(int roleId) 
            => CreateActionResult(await roleService.Delete(roleId));

        [HttpPut("UpdateRoleName")]
        public async Task<IActionResult> UpdateRoleName(RoleUpdateNameRequestDto request)
            => CreateActionResult(await roleService.UpdateRoleName(request.Name, request.Id));
        

    }
}
