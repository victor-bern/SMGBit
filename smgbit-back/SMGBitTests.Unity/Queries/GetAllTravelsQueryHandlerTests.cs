using FluentAssertions;
using Moq;
using SMGBit.Application.Queries.Travel.GetAllTravels;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Repositories;
using SMGBit.Domain.ValueObjects;

namespace SMGBitTests.Unit.Queries
{
    public class GetAllTravelsQueryHandlerTests
    {
        private GetAllTravelsQueryHandler _handler;
        private Mock<ITravelRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ITravelRepository>();
            _handler = new GetAllTravelsQueryHandler(_repository.Object);
        }


        [Test]
        public async Task Handle_ShouldReturnAListOfTravel()
        {
            var testList = new List<Travel>
            {
                new Travel
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
                    Placa = "ABC-123",
                    Id = 2
                },
                new Travel
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
                    Placa = "ABC-123",
                    Id = 3
                }
            };
            _repository.Setup(x => x.GetAllTravelsAsync()).ReturnsAsync(testList);

            var query = new GetAllTravelsQuery();

            var response = await _handler.Handle(query, default);
            response.Should().BeOfType<List<Travel>>();
            response.Count.Should().Be(2);

        }
    }
}
