

using School.Business.DTO.Disciplina;
using School.Business.DTO.MatriculaDisciplina;

namespace School.Business.DTO.Aluno
{
    public class DadosAlunoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
        public IEnumerable<DadosMatriculaDisciplinaDTO> Disciplinas { get; set; }
        public bool Ativo { get; set; }

    }
}
