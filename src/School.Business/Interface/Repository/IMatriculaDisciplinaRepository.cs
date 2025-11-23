

using School.Business.Models;

namespace School.Business.Interface.Repository
{
    public interface IMatriculaDisciplinaRepository : IRepository<MatriculaDisciplina>
    {
        Task<MatriculaDisciplina> GetMatriculaWithDetails(long id);
        Task<MatriculaDisciplina> GetMatriculaCompleta(long id);
    }
}
