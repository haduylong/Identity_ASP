using Identity.Application.Interfaces;
using Identity.Application.Mappers;
using Identity.Application.Services;
using Identity.Domain.Repositories.UnitOfWork;
using Identity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Configurations
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PermissionMapper), typeof(UserMapper), typeof(RoleMapper));

            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
