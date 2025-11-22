namespace School.Business.DTO.Professor
{
    public class DadosProfessorDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Tipo { get; set; } = "Professor";
        public string RegistroFuncional { get; set; }
        public bool Ativo { get; set; }
    }
}
