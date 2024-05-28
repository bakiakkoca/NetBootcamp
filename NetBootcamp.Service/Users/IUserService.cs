using System.Collections.Immutable;
using NetBootcamp.Service.SharedDTOs;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.Service.Users
{
    public interface IUserService
    {
        Task<ResponseModelDto<ImmutableList<UserDto>>> GetAll();

        Task<ResponseModelDto<UserDto?>> GetById(int id);

        Task<ResponseModelDto<int>> Create(UserCreateRequestDto request);

        Task<ResponseModelDto<NoContent>> Update(int userId, UserUpdateRequestDto request);
        Task<ResponseModelDto<NoContent>> Delete(int id);
    }
}
