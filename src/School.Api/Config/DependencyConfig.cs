using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Services;
using School.Data.Repository;


namespace School.Api.Config
{
    public static class DependencyConfig
    {

        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {

            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
