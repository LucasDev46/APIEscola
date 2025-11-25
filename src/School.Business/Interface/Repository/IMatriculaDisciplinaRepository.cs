

using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface IMatriculaDisciplinaRepository : IRepository<MatriculaDisciplina>
    {
        Task<MatriculaDisciplina> ObterMatriculaCompleta(long id);
        Task<MatriculaDisciplina> ObterMatriculaComDetalhes(long id);
        Task<IEnumerable<MatriculaDisciplina>> ObterTodasMatriculasComDetalhes();
        Task<decimal> ObterPeso(long id);
    }
}
