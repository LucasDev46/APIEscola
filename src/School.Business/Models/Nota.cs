
namespace School.Business.Models
{
    public class Nota : Entity
    {
        public decimal Valor { get; set; }
        public long MatriculaDisciplinaId { get; set; }
        public MatriculaDisciplina MatriculaDisciplina { get; set; }
        public decimal Peso { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; } = DateTime.UtcNow;
    }
}
