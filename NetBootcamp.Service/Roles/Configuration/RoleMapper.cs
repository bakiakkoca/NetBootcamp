using AutoMapper;
using NetBootcamp.Repository.Roles;
using NetBootcamp.Service.Roles.DTOs;

namespace NetBootcamp.Service.Roles.Configuration
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
        }

    }
}
