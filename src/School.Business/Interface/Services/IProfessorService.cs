using School.Business.DTO.Professor;

namespace School.Business.Interface.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<DadosProfessorDTO>> ObterTodos();
        Task<DadosProfessorDTO> ObterById(long id);
        Task<DadosProfessorDTO> Criar(CriarProfessorDTO professor);
        Task<DadosProfessorDTO> Atualizar(AtualizarProfessorDTO professor);
        Task<bool> Inativar(long id);
    }
}
