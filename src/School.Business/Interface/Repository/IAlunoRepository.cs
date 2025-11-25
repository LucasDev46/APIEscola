
using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterAlunoDisciplinas(long id);
        Task<IEnumerable<Aluno>> ObterTodosAlunoDisciplina();
    }
}
