using AutoMapper;
using NetBootcamp.Repository.Users;
using NetBootcamp.Service.Users.DTOs;

namespace NetBootcamp.Service.Users.Configuration
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
