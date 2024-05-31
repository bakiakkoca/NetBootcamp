using System.Collections.Immutable;
using System.Net;
using AutoMapper;
using NetBootcamp.Repository;
using NetBootcamp.Repository.Users;
using NetBootcamp.Service.SharedDTOs;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.Service.Users
{
    public class UserService(
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper) 
        : IUserService
    {
        public async Task<ResponseModelDto<ImmutableList<UserDto>>> GetAll()
        {
            var usersAll = await userRepository.GetAll();

            var userListAsDto = mapper.Map<List<UserDto>>(usersAll);

            return ResponseModelDto<ImmutableList<UserDto>>.Success(userListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<UserDto?>> GetById(int id)
        {
            var hasUser = await userRepository.GetById(id);

            if (hasUser is null)
            {
                return  ResponseModelDto<UserDto?>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserDto>(hasUser);

            return ResponseModelDto<UserDto?>.Success(userAsDto);
        }

        public async Task<ResponseModelDto<int>> Create(UserCreateRequestDto request)
        {
            var newUser = new User
            {
                Name = request.Name.Trim(),
                Surname = request.Surname.Trim(),
                Email = request.Email,
                Created = DateTime.Now
            };

            await userRepository.Create(newUser);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newUser.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int userId, UserUpdateRequestDto request)
        {
            var hasUser = await userRepository.GetById(userId);
            //if (hasUser is null)
            //{
            //    return ResponseModelDto<NoContent>.Fail("Güncellemeye çalışılan kişi bulunamadı", HttpStatusCode.NotFound);
            //}

            //var updateUser = new User()
            //{
            //    Id = userId,
            //    Name = request.Name,
            //    Surname = request.Surname,
            //    Email = request.Email,
            //};

            hasUser.Name = request.Name;
            hasUser.Surname = request.Surname;
            hasUser.Email = request.Email;

            await userRepository.Update(hasUser);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);

        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            //var hasUser = await userRepository.GetById(id);

            //if (hasUser is null)
            //{
            //    return ResponseModelDto<NoContent>.Fail("Silinmeye çalışılan ürün bulunamadı", HttpStatusCode.NotFound);
            //}

            await userRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateNameUser(int id, string name)
        {
            await userRepository.UpdateNameUser(name, id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}
