using School.Business.DTO.Professor;

namespace School.Business.Interface.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<DadosProfessorDTO>> GetAllProf();
        Task<DadosProfessorDTO> GetProfById(long id);
        Task<DadosProfessorDTO> CreateProf(CreateProfessorDTO professor);
        Task<DadosProfessorDTO> UpdateProf(UpdateProfessorDTO professor);
        Task<bool> inativarProf(long id);
    }
}
