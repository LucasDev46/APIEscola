using School.Business.DTO.Professor;
using System.Text.Json.Serialization;

namespace School.Business.DTO.Disciplina
{
    public class CriarDisciplinaDTO
    {
        public string Nome { get; set; }

        public long ProfessorId { get; set; }
        [JsonIgnore]
        public DadosProfessorDTO Professor { get; set; }
    }
}
