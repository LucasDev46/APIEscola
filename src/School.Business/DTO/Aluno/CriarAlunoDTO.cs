

using System.Text.Json.Serialization;

namespace School.Business.DTO.Aluno
{
    public class CriarAlunoDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public string Tipo { get; set; } = "Aluno";
        [JsonIgnore]
        public bool Ativo { get; set; } = true;
        public string Matricula { get; set; }
    }
}
