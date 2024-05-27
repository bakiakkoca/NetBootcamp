using Microsoft.AspNetCore.Mvc;
using NetBootcamp.API.Controllers;
using NetBootcamp.Repository.Roles;
using NetBootcamp.Service.Roles.DTOs;

namespace NetBootcamp.API.Roles
{

    public class RolesController(IRoleService roleService) : CustomBaseController
    {
        [HttpGet]
        public IActionResult GetAll() => Ok(roleService.GetAll());

        [HttpGet("{roleId}")]
        public IActionResult GetById(int roleId) => Ok(roleService.GetById(roleId));

        [HttpPost]
        public IActionResult Create(RoleCreateRequestDto request)
        {
            var result = roleService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { roleId = result.Data });
        }

        [HttpPut("{roleId}")]
        public IActionResult Update(int roleId, RoleUpdateRequestDto request) => CreateActionResult(roleService.Update(roleId, request));

        [HttpDelete("{roleId}")]
        public IActionResult Delete(int roleId) => CreateActionResult(roleService.Delete(roleId));

    }
}
