using FluentAssertions;
using SMGBit.Application.Services;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Interfaces;
using SMGBit.Domain.ValueObjects;

namespace SMGBitTests.Unit.Services
{
    public class FreteServiceTests
    {
        private IFreteService freteService;

        [SetUp]
        public void Setup()
        {
            freteService = new FreteService();
        }

        [Test]
        public async Task ProcessTravelListToAddFreight_ReturnsListOfTravelWithFreteInfo()
        {
            var travelsList = new List<Travel> {
                new Travel()
                {
                    CaixasCarregagas = 10,
                    DataViagem = new DateTime(),
                    Origem = "CDD Ribeirão Preto",
                    Destino = "Região 2",
                    TipoVeiculo = TipoVeiculo.VUC,
                    TipoViagem = TipoViagem.LastMile,
                    Entregas = 10,
                    KmRodados = 10,
                    Motorista = "João",
                    NumeroViagem = 1200,
                    Placa = "ABC-123"
                }
            };

            var result = await freteService.ProcessTravelListToAddFreight(travelsList);
            var hasInfo = result.All(x => x.TabelaFrete != null && x.ValorViagem != null);
            hasInfo.Should().BeTrue();
        }
    }
}
