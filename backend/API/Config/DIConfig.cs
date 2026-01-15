using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;
using backend.Domain.Services;
using backend.Infrastructure.Mapping;
using backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.API.Config
{
    public static class DIConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRollService, RollService>();
            services.AddScoped<IRollRepository, RollRepository>();

            services.AddDbContext<RollDBContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            )
        );

            return services;
        }
    }
}