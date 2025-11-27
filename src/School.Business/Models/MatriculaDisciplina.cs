

using System.ComponentModel.DataAnnotations.Schema;

namespace School.Business.Models
{
    public class MatriculaDisciplina : Entity
    {
        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public long DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public decimal? NotaFinal { get; set; }
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
        public bool Ativo { get; set; } = true;
    }
}
