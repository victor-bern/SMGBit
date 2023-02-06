using FluentAssertions;
using Moq;
using SMGBit.Application.Commands.Travel.CreateTravel;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Repositories;
using SMGBit.Domain.ValueObjects;

namespace SMGBitTests.Unit.Commands
{
    public class CreateTravelsCommandHandlerTests
    {
        private CreateTravelsCommandHandler _handler;
        private Mock<ITravelRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ITravelRepository>();
            _handler = new CreateTravelsCommandHandler(_repository.Object);
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
            _repository.Setup(x => x.SaveTravels(It.IsAny<List<Travel>>())).ReturnsAsync(testList);

            var command = new CreateTravelsCommand()
            {
                Items = testList
            };

            var response = await _handler.Handle(command, default);
            response.Should().BeOfType<List<Travel>>();
            response.Count.Should().Be(2);

        }
    }
}
