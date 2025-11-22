using System.Text.Json.Serialization;

namespace School.Business.DTO.Professor
{
    public class CreateProfessorDTO
    {
      
        public string Nome { get; set; }
   
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
        [JsonIgnore]
        public string Tipo { get; set; } = "Professor";


        public string RegistroFuncional { get; set; }

    }
}
