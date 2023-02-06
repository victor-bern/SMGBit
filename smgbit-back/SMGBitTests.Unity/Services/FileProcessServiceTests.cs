using FluentAssertions;
using Microsoft.AspNetCore.Http;
using SMGBit.Application.Services;
using SMGBit.Domain.Interfaces;

namespace SMGBitTests.Unit.Services
{
    public class FileProcessServiceTests
    {
        private IFormFile fileTest;
        private IFileService fileService;
        private IFreteService freteService;

        [SetUp]
        public void Setup()
        {
            freteService = new FreteService();
            fileService = new FileService(freteService);
            var file = new MemoryStream(File.ReadAllBytes(Environment.CurrentDirectory + "/PlanilhaTeste.xlsx"));
            fileTest = new FormFile(file, 0, file.Length, "PlanilhaTeste", "PlanilhaTeste.xlsx");

        }


        [Test]
        public async Task ProcessFileAndReturnTravels_ReturnTravels()
        {
            var result = await fileService.ProcessFileAndReturnTravels(fileTest);
            result.Count.Should().Be(77);
        }
    }
}
