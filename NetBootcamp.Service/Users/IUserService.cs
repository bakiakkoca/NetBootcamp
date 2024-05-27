using System.Collections.Immutable;
using NetBootcamp.Service.SharedDTOs;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.Service.Users
{
    public interface IUserService
    {
        ResponseModelDto<ImmutableList<UserDto>> GetAll();

        ResponseModelDto<UserDto?> GetById(int id);

        ResponseModelDto<int> Create(UserCreateRequestDto request);

        ResponseModelDto<NoContent> Update(int userId, UserUpdateRequestDto request);
        ResponseModelDto<NoContent> Delete(int id);
    }
}
