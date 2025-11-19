

using School.Business.Models;

namespace School.Business.Interface.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetAllProf();
        Task<Professor> GetProfById(Guid id);
        Task<bool> CreateProf(Professor professor);
        Task<Professor> UpdateProf(Guid id, Professor professor);
        Task<bool> inativarProf(Guid id);
    }
}
