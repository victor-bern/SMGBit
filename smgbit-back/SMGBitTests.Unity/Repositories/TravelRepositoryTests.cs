using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SMGBit.Application.Repositories;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Repositories;
using SMGBit.Domain.ValueObjects;
using SMGBit.Infra.Context;

namespace SMGBitTests.Unit.Repositories
{
    public class TravelRepositoryTests
    {
        private ApplicationContext context;
        private ITravelRepository travelRepository;
        private Travel testObject = new Travel()
        {
            CaixasCarregagas = 10,
            DataViagem = new DateTime(),
            Origem = "CDD Ribeirão Preto",
            Destino = "Região 2",
            TipoVeiculo = TipoVeiculo.VUC,
            TipoViagem = TipoViagem.LastMile,
            Entregas = 10,
            KmRodados = 10,
            Id = 1,
            Motorista = "João",
            NumeroViagem = 1200,
            Placa = "ABC-123"
        };
        public TravelRepositoryTests()
        {
            DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder()
                  .UseInMemoryDatabase(
                      Guid.NewGuid().ToString() // Use GUID so every test will use a different db
                  );
            context = new ApplicationContext(dbOptions.Options);
        }

        [TearDown]
        public async Task Dispose()
        {
            await context.Database.EnsureDeletedAsync();
        }

        [SetUp]
        public async Task Setup()
        {
            travelRepository = new TravelRepository(context);

            await context.AddAsync(testObject);
            await context.SaveChangesAsync();
        }

        [Test]
        public async Task Get_TravelRepository_ShouldReturnAListWithTravels()
        {
            var result = await travelRepository.GetAllTravelsAsync();

            result.Count.Should().Be(1);
        }

        [Test]
        public async Task Save_Travels_ShouldAddTravelsAndReturnAList()
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
            var result = await travelRepository.SaveTravels(testList);

            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<List<Travel>>();
            result.Count.Should().Be(2);
        }

    }
}
