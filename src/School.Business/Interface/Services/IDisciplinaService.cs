using School.Business.DTO.Disciplina;

namespace School.Business.Interface.Services
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<DadosDisciplinaDTO>> ObterTodos();
        Task<DadosDisciplinaDTO> ObterById(long id);
        Task<DadosDisciplinaDTO> Criar(CriarDisciplinaDTO professor);
        Task<DadosDisciplinaDTO> Atualizar(AtualizarDisciplinaDTO professor);
        Task<bool> Inativar(long id);
    }
}
