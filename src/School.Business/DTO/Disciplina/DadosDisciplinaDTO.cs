using School.Business.DTO.Professor;

namespace School.Business.DTO.Disciplina
{
    public class DadosDisciplinaDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long ProfessorId { get; set; }
        public bool Ativo { get; set; }

        public DadosProfessorDTO Professor { get; set; }
    }
}
