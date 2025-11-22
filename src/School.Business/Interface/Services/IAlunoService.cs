
using School.Business.DTO.Aluno;

namespace School.Business.Interface.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<DadosAlunoDTO>> GetTodosAlunos();
        Task<DadosAlunoDTO> GetAlunoById(long id);
        Task<DadosAlunoDTO> CriarAluno(CriarAlunoDTO professor);
        Task<DadosAlunoDTO> AtualizarAluno(AtualizarAlunoDTO professor);
        Task<bool> inativarAluno(long id);
    }
}
