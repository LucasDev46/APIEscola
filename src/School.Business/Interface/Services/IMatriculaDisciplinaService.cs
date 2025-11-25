
using School.Business.DTO.Aluno;
using School.Business.DTO.MatriculaDisciplina;

namespace School.Business.Interface.Services
{
    public interface IMatriculaDisciplinaService
    {
        Task<IEnumerable<DadosMatriculaDTO>> ObterTodos();
        Task<DadosMatriculaDisciplinaDTO> ObterById(long id);
        Task<DadosMatriculaDTO> Criar(CriarMatriculaDisciplinaDTO matDisc);
        Task<bool> Inativar(long id);
    }
}
