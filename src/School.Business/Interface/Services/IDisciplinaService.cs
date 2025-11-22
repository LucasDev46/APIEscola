using School.Business.DTO.Disciplina;

namespace School.Business.Interface.Services
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<DadosDisciplinaDTO>> GetAllDisc();
        Task<DadosDisciplinaDTO> GetDiscById(long id);
        Task<DadosDisciplinaDTO> CreateDisc(CreateDisciplinaDTO professor);
        Task<DadosDisciplinaDTO> UpdateDisc(UpdateDisciplinaDTO professor);
        Task<bool> inativarDisc(long id);
    }
}
