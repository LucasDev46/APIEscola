using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Api.DTO
{
    public class CreateProfessorDTO
    {
        [Required(ErrorMessage = " Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = " Email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = " Data de Nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }
        [JsonIgnore]
        public string Tipo { get; set; } = "Professor";

        [Required(ErrorMessage =" Registro Funcional é obrigatório.")]
        public string RegistroFuncional { get; set; }
    }
}
