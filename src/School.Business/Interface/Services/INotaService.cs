

using School.Business.DTO.Nota;

namespace School.Business.Interface.Services
{
    public interface INotaService
    {
        Task<IEnumerable<DadosNotaDTO>> ObterTodos();
        Task<DadosNotaDTO> ObterById(long id);
        Task<DadosNotaDTO> Criar(CriarNotaDTO nota);
        Task<DadosNotaDTO> Atualizar(AtualizarNotaDTO nota);
    }
}
