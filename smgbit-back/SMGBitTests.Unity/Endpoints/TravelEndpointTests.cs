using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Newtonsoft.Json;
using SMGbit.Api.Endpoints;
using SMGBit.Application.Commands.Travel.CreateTravel;
using SMGBit.Application.Queries.Travel.GetAllTravels;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Interfaces;
using SMGBit.Domain.ValueObjects;
using SMGBitTests.Unit;

namespace SMGBitTests.Unity.Endpoints
{
    public class TravelEndpointTests : WebFactoryProgram
    {
        private Mock<IMediator> mediatorMock;
        private Mock<IFileService> fileServiceMock;
        private Mock<HttpRequest> httpRequestMock;
        private HttpClient _client;
        [SetUp]
        public void Setup()
        {
            mediatorMock = new Mock<IMediator>();
            fileServiceMock = new Mock<IFileService>();
            httpRequestMock = new Mock<HttpRequest>();
            _client = CreateClient();
        }

        [Test]
        public async Task GetAllTravels_ReturnsOkWithListOfTravel()
        {
            mediatorMock.Setup(x => x.Send(It.IsAny<GetAllTravelsQuery>(), default)).ReturnsAsync(new List<Travel>());
            var result = await TravelEndpoint.GetAllTravels(mediatorMock.Object);

            result.Should().BeOfType<Ok<IList<Travel>>>();
        }

        [Test]
        public async Task ProcessTravelFile_ReturnsInternalServerError()
        {
            fileServiceMock.Setup(x => x.ProcessFileAndReturnTravels(It.IsAny<IFormFile>())).ThrowsAsync(new Exception());
            var result = (StatusCodeHttpResult)await TravelEndpoint.ProcessTravelFile(httpRequestMock.Object, fileServiceMock.Object, mediatorMock.Object);

            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }

        [Test]
        public async Task ProcessTravelFile_ReturnsOkWithListOfTravel()
        {
            var expectedResponse = new List<Travel>()
            {
                new Travel
                {
                        CaixasCarregagas= 90,
                        DataViagem= DateTime.UtcNow,
                        Destino= "Regiao 10",
                        Entregas= 100,
                        KmRodados= 10,
                        Motorista= "JOAO VITOR",
                        NumeroViagem= 1000,
                        Origem= "CDD São Paulo",
                        Placa= "GDF-1U10",
                        TipoVeiculo= TipoVeiculo.TRUCK,
                        TipoViagem= TipoViagem.Fullfilment,
                }
            };

            httpRequestMock.SetupGet(x => x.Form.Files).Returns(new FormFileCollection { new FormFile(It.IsAny<Stream>(), 10, 19, "arquivo.xlxs", "arquivo") });
            fileServiceMock.Setup(x => x.ProcessFileAndReturnTravels(It.IsAny<IFormFile>())).ReturnsAsync(expectedResponse);
            mediatorMock.Setup(x => x.Send(It.IsAny<CreateTravelsCommand>(), default)).ReturnsAsync(expectedResponse);
            var result = await TravelEndpoint.ProcessTravelFile(httpRequestMock.Object, fileServiceMock.Object, mediatorMock.Object) as Ok<IList<Travel>>;

            result.Value.Should().BeSameAs(expectedResponse);
        }

        [Test]
        public async Task GetAllTravels_ShouldReturnStatusCodeOk()
        {
            var response = await _client.GetAsync("travels");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task ProcessTravelFile_ShouldReturnStatusCodeOk()
        {
            FileInfo arquivoInfo = new FileInfo(Environment.CurrentDirectory + "/PlanilhaTeste.xlsx");
            MultipartFormDataContent mpform = new MultipartFormDataContent();
            string Name = arquivoInfo.FullName;
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var json = JsonConvert.SerializeObject(jsonSettings);
            using FileStream fs = File.OpenRead(Name);

            using var streamContent = new StreamContent(fs);

            var fileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
            mpform.Add(fileContent, "anexos", Path.GetFileName(Name));
            var response = await _client.PostAsync("travels/process_file", mpform);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
