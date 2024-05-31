using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetBootcamp.Repository.Users;
using NetBootcamp.Service.Users.DTOs;
using NetBootcamp.Service.Users.UserCreateUseCase;
using NetBootcamp.Service.Users.UserUpdateNameUseCase;

namespace NetBootcamp.Service.Users.Configuration
{
    public static class UserServiceExt
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddValidatorsFromAssemblyContaining<UserCreateRequestValidator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddValidatorsFromAssemblyContaining<UserUpdateNameRequestValidator>();

        }
    }
}
