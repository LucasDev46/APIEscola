
using School.Business.DTO.Nota;
using System.Text.Json.Serialization;

namespace School.Business.DTO.MatriculaDisciplina
{
    public class DadosMatriculaDisciplinaDTO
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public long DisciplinaId { get; set; }
        public string NomeDisciplina { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? NotaFinal { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<DadosNotaDTO> Notas { get; set; } = new List<DadosNotaDTO>();
        public bool Ativo { get; set; }
    }
}
