namespace School.Business.DTO.Nota
{
    public class DadosNotaDTO
    {
        public long Id { get; set; }
        public decimal Valor { get; set; }
        public decimal Peso { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public long MatriculaDisciplinaId { get; set; }
    }
}
