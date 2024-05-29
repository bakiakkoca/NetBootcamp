using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetBootcamp.Service.Users.UserCreateUseCase;

namespace NetBootcamp.Service.Users.Configuration
{
    public static class UserServiceExt
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddValidatorsFromAssemblyContaining<UserCreateRequestValidator>();

        }
    }
}
