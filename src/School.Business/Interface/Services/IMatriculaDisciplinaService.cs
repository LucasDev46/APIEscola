
using School.Business.DTO.Aluno;
using School.Business.DTO.MatriculaDisciplina;

namespace School.Business.Interface.Services
{
    public interface IMatriculaDisciplinaService
    {
        Task<IEnumerable<DadosMatriculaDisciplinaDTO>> ObterTodos();
        Task<DadosMatriculaDisciplinaDTO> ObterById(long id);
        Task<DadosMatriculaDisciplinaDTO> Criar(CriarMatriculaDisciplinaDTO matDisc);
        Task<DadosMatriculaDisciplinaDTO> Atualizar(AtualizarAlunoDTO matDisc);
        Task<bool> Inativar(long id);
    }
}
