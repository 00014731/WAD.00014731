using System.Reflection;
using System;
using WAD._00014731.Interfaces;
using WAD._00014731.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WAD._00014731.Data;

namespace WAD._00014731.DAL
{
    public static class ConfigurationSerivces
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
