using Microsoft.EntityFrameworkCore;
using School.Api.Data;

namespace School.Api.Config
{
    public static class IdentityConfig
    {

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString")));


            return services;
        }
    }
}
