using SMGBit.Domain.ValueObjects;

namespace SMGBit.Domain.Entities
{
    public class Travel
    {
        public int Id { get; set; }
        public DateTime DataViagem { get; set; }
        public int NumeroViagem { get; set; }
        public string Motorista { get; set; }
        public string Placa { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int CaixasCarregagas { get; set; }
        public int Entregas { get; set; }
        public int KmRodados { get; set; }
        public TipoViagem TipoViagem { get; set; }
        public string? TabelaFrete { get; set; }
        public int? ValorViagem { get; set; }
    }
}
