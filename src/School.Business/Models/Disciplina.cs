

namespace School.Business.Models
{
    public class Disciplina : Entity
    {
        public string Nome { get; set; }

        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }

        // Relacionamento N:N com Aluno via MatriculaDisciplina

        public ICollection<MatriculaDisciplina> Matriculas { get; set; } = new List<MatriculaDisciplina>();
    }
}
