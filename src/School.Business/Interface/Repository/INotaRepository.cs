

using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface INotaRepository : IRepository<Nota>
    {
        Task<IEnumerable<Nota>> ObterNotaAluno();
        Task<Nota> ObterNotaMatriculaPeloId(long id);
        
    }
}
