
using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> GetAlunoWithDisciplinas(long id);
    }
}
