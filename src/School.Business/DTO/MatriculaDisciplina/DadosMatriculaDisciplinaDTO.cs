
using School.Business.DTO.Nota;

namespace School.Business.DTO.MatriculaDisciplina
{
    public class DadosMatriculaDisciplinaDTO
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public long DisciplinaId { get; set; }
        public string NomeDisciplina { get; set; }
        public decimal? NotaFinal { get; set; }
        public ICollection<DadosNotaDTO> Notas { get; set; } = new List<DadosNotaDTO>();
        public bool Ativo { get; set; }
    }
}
