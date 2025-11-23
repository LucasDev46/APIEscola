

namespace School.Business.DTO.Nota
{
    public class CriarNotaDTO
    {
        public long MatriculaDisciplinaId { get; set; }
        public decimal Valor { get; set; }                
        public decimal Peso { get; set; }                 
        public string Descricao { get; set; }
    }
}
