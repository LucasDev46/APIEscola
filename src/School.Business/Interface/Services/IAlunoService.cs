
using School.Business.DTO.Aluno;

namespace School.Business.Interface.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<DadosAlunoDTO>> ObterTodos();
        Task<DadosAlunoDTO> ObterById(long id);
        Task<DadosAlunoDTO> Criar(CriarAlunoDTO professor);
        Task<DadosAlunoDTO> Atualizar(AtualizarAlunoDTO professor);
        Task<bool> Inativar(long id);
    }
}
