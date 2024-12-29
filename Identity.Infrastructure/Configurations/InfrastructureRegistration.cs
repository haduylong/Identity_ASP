using Identity.Domain.Repositories;
using Identity.Domain.Repositories.UnitOfWork;
using Identity.Infrastructure.Repositories;
using Identity.Infrastructure.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Configurations
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();


            services.AddDbContext<AppDbContext>((options) =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
