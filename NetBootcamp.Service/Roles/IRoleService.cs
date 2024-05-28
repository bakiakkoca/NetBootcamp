using System.Collections.Immutable;
using NetBootcamp.Service.Roles.DTOs;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.Repository.Roles
{
    public interface IRoleService
    {
        Task<ResponseModelDto<ImmutableList<RoleDto>>> GetAll();

        Task<ResponseModelDto<RoleDto?>> GetById(int id);

        Task<ResponseModelDto<int>> Create(RoleCreateRequestDto request);

        Task<ResponseModelDto<NoContent>> Delete(int roleId);
        Task<ResponseModelDto<NoContent>> Update(int roleId, RoleUpdateRequestDto request);
    }
}
