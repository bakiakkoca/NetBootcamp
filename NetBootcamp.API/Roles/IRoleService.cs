using System.Collections.Immutable;
using NetBootcamp.API.Roles.DTOs;
using NetBootcamp.API.SharedDTOs;

namespace NetBootcamp.API.Roles
{
    public interface IRoleService
    {
        ResponseModelDto<ImmutableList<RoleDto>> GetAll();

        ResponseModelDto<RoleDto?> GetById(int id);

        ResponseModelDto<int> Create(RoleCreateRequestDto request);

        ResponseModelDto<NoContent> Delete(int roleId);
        ResponseModelDto<NoContent> Update(int roleId, RoleUpdateRequestDto request);
    }
}
