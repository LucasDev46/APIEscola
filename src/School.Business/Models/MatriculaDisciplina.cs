

namespace School.Business.Models
{
    public class MatriculaDisciplina : Entity
    {
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public Guid DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public decimal? NotaFinal { get; set; }
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}
