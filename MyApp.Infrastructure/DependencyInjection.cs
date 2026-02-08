using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Interfaces.Persistence;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Services;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Repository;
using MyApp.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IResidentServices, ResidentService>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            services.AddScoped<IResidentRegistrationServices, ResidentRegistrationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IOrdinanceServices, OrdinanceServices>();
            services.AddScoped<IOrdinanceRepository, OrdinanceRepository>();

            return services;
        }
    }
}
