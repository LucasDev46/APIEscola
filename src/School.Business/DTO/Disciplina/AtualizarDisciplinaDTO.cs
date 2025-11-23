namespace School.Business.DTO.Disciplina
{
    public class AtualizarDisciplinaDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public long ProfessorId { get; set; }
    }
}
