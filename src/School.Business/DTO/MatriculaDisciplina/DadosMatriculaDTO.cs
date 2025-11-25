

namespace School.Business.DTO.MatriculaDisciplina
{
    public class DadosMatriculaDTO
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public long DisciplinaId { get; set; }
        public string NomeDisciplina { get; set; }
    }
}
