
using School.Business.DTO;
using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Task<Disciplina> GetDisciplinaWithProfessor(long id);
    }
}
