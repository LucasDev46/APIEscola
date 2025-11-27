using System.Text.Json.Serialization;

namespace School.Business.DTO.Professor
{
    public class AtualizarProfessorDTO : PessoaDTO
    {
        [JsonIgnore]
        public string Tipo { get; set; } = "Professor";
    }
}
