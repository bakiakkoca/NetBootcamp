using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetBootcamp.Repository.Roles;
using NetBootcamp.Service.Roles.RoleCreateUseCase;

namespace NetBootcamp.Service.Roles.Configuration
{
    public static class RoleServiceExt
    {
        public static void AddRoleService(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddValidatorsFromAssemblyContaining<RoleCreateRequestValidator>();

        }
    }
}
