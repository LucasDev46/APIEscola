

namespace School.Business.Models
{
    public class Professor : Pessoa
    {
        public string RegistroFuncional { get; set; }
        public ICollection<Disciplina> Disciplina { get; set; }
    }
}
