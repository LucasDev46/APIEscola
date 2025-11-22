

namespace School.Business.DTO.Aluno
{
    public class AtualizarAlunoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
