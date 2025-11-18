

namespace School.Business.Models
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public string Tipo { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
