using System.Collections.Immutable;
using System.Net;
using AutoMapper;
using NetBootcamp.Repository;
using NetBootcamp.Repository.Roles;
using NetBootcamp.Service.Roles.DTOs;
using NetBootcamp.Service.SharedDTOs;

namespace NetBootcamp.Service.Roles
{
    public class RoleService(
        IRoleRepository roleRepository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper
        ) : IRoleService
    {
        public async Task<ResponseModelDto<ImmutableList<RoleDto>>> GetAll()
        {
            var rolesAll = await roleRepository.GetAll();
            var roleListAsDto = mapper.Map<List<RoleDto>>(rolesAll);
            return ResponseModelDto<ImmutableList<RoleDto>>.Success(roleListAsDto.ToImmutableList());
        }


        public async Task<ResponseModelDto<RoleDto?>> GetById(int id)
        {
            var hasRole = await roleRepository.GetById(id);

            if (hasRole == null)
            {
                return ResponseModelDto<RoleDto?>.Fail("Role bulunamadı", HttpStatusCode.NotFound);
            }

            var roleAsDto = mapper.Map<RoleDto>(hasRole);

            return ResponseModelDto<RoleDto?>.Success(roleAsDto);
        }

        public async Task<ResponseModelDto<int>> Create(RoleCreateRequestDto request)
        {
            var newRole = new Role
            {
                Name = request.Name
            };

            await roleRepository.Create(newRole);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newRole.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            //var hasRole = await roleRepository.GetById(id);

            //if (hasRole is null)
            //{
            //    return ResponseModelDto<NoContent>.Fail("Silinmeye çalışılan role bulunamadı", HttpStatusCode.NotFound);
            //}

            await roleRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int roleId, RoleUpdateRequestDto request)
        {
            var hasRole = await roleRepository.GetById(roleId);

            //if (hasRole is null)
            //{
            //    return ResponseModelDto<NoContent>.Fail("Güncellemeye çalışılan role bulunamadı", HttpStatusCode.NotFound);
            //}

            //var updateRole = new Role
            //{
            //    Id = roleId,
            //    Name = request.Name,
            //};

            hasRole.Name = request.Name;

            await roleRepository.Update(hasRole);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateRoleName(string roleName, int roleId)
        {
            await roleRepository.UpdateRoleName(roleName, roleId);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}