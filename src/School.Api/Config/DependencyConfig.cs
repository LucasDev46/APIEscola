using School.Business.Interface.Repository;
using School.Business.Interface.Services;
using School.Business.Models;
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

            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();

            services.AddScoped<IMatriculaDisciplinaRepository, MatriculaDisciplinaRepository>();
            services.AddScoped<IMatriculaDisciplinaService, MatriculaDisciplinaService>();

            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<INotaService, NotaService>();
            return services;
        }
    }
}
