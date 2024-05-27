using System.Collections.Immutable;
using NetBootcamp.Service.Roles.DTOs;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.Repository.Roles
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
