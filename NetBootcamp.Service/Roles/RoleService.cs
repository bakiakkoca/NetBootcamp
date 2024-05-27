using System.Collections.Immutable;
using System.Net;
using NetBootcamp.Service.Roles.DTOs;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.Repository.Roles
{
    public class RoleService(IRoleRepository roleRepository) : IRoleService
    {
        public ResponseModelDto<ImmutableList<RoleDto>> GetAll()
        {
            var roleList = roleRepository.GetAll().Select(role => new RoleDto(
                role.Id,
                role.Name)
            ).ToImmutableList();

            return ResponseModelDto<ImmutableList<RoleDto>>.Success(roleList);
        }


        public ResponseModelDto<RoleDto?> GetById(int id)
        {
            var hasRole = roleRepository.GetById(id);

            if (hasRole == null)
            {
                return ResponseModelDto<RoleDto?>.Fail("Role bulunamadı", HttpStatusCode.NotFound);
            }

            var newDto = new RoleDto(
                hasRole.Id,
                hasRole.Name
            );

            return ResponseModelDto<RoleDto?>.Success(newDto);
        }

        public ResponseModelDto<int> Create(RoleCreateRequestDto request)
        {
            var newRole = new Role()
            {
                Id = roleRepository.GetAll().Count + 1,
                Name = request.Name
            };

            roleRepository.Create(newRole);

            return ResponseModelDto<int>.Success(newRole.Id, HttpStatusCode.Created);
        }

        public ResponseModelDto<NoContent> Delete(int roleId)
        {
            var hasRole = roleRepository.GetById(roleId);
            if (hasRole is null)
            {
                return ResponseModelDto<NoContent>.Fail("Silinmeye çalışılan role bulunamadı", HttpStatusCode.NotFound);
            }

            roleRepository.Delete(roleId);
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.Created);
        }

        public ResponseModelDto<NoContent> Update(int roleId, RoleUpdateRequestDto request)
        {
            var hasRole = roleRepository.GetById(roleId);
            if (hasRole is null)
            {
                return ResponseModelDto<NoContent>.Fail("Güncellemeye çalışılan role bulunamadı", HttpStatusCode.NotFound);
            }

            var updateRole = new Role()
            {
                Id = roleId,
                Name = request.Name,
            };

            roleRepository.Update(updateRole);

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}