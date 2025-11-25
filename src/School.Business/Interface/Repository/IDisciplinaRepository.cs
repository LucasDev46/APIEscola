
using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Task<Disciplina> ObterDisciplinaComProfessor(long id);
        Task<IEnumerable<Disciplina>> ObterTodasDisciplinaComProfessor();
    }
}
