using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMGBit.Domain.Entities;
using SMGBit.Domain.ValueObjects;
using SMGBit.Infra.Context;

namespace SMGBitTests.Unit
{
    public class WebFactoryProgram : WebApplicationFactory<Program>
    {
        private IServiceCollection _service;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(b =>
            {

                var descriptor = b.SingleOrDefault(
               d => d.ServiceType ==
                   typeof(DbContextOptions<ApplicationContext>));

                if (descriptor != null) b.Remove(descriptor);

                var connectionString = "Server=localhost;Database=Travels.Test;User Id=sa;Password=Veteranos1;TrustServerCertificate=True";

                b.AddDbContext<ApplicationContext>(s => s.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure(5)));

                _service = b;
                var sp = b.BuildServiceProvider();


                using var scope = sp.CreateScope();

                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationContext>();

                db.Database.EnsureCreated();
                db.Travels.Add(new Travel
                {
                    CaixasCarregagas = 10,
                    DataViagem = DateTime.Now,
                    Origem = "CDD Ribeirão Preto",
                    Destino = "Região 2",
                    TipoVeiculo = TipoVeiculo.VUC,
                    TipoViagem = TipoViagem.LastMile,
                    Entregas = 10,
                    KmRodados = 10,
                    Motorista = "João",
                    NumeroViagem = 1200,
                    Placa = "ABC-123"
                });
                db.SaveChanges();

            });
        }

        [OneTimeTearDown]
        public void DisposeDb()
        {
            var sp = _service.BuildServiceProvider();

            using var scope = sp.CreateScope();

            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationContext>();
            db.Database.EnsureDeleted();
        }
    }
}

