using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Interfaces;
using SMGBit.Domain.ValueObjects;

namespace SMGBit.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFreteService freteService;

        public FileService(IFreteService freteService)
        {
            this.freteService = freteService;
        }

        public async Task<IList<Travel>> ProcessFileAndReturnTravels(IFormFile? file)
        {
            using var stream = file.OpenReadStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(stream);
            List<Travel> travels = new();

            var workbook = package.Workbook;
            if (workbook != null)
            {
                var worksheet = workbook.Worksheets[0];
                if (worksheet != null)
                {
                    for (int row = worksheet.Dimension.Start.Row; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var travel = new Travel();
                        if (row == 1) continue;
                        for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;
                            if (cellValue == null) break;
                            AddPropToTravel(ref travel, col, cellValue.ToString());
                        }
                        if (travel.Motorista != null) travels.Add(travel);

                    }
                }
            }
            var travelListWithFrete = await freteService.ProcessTravelListToAddFreight(travels);
            return travelListWithFrete;

        }

        private static void AddPropToTravel(ref Travel travel, int column, string value)
        {
            switch (column)
            {
                case 1:
                    travel.Origem = value; break;
                case 2:
                    travel.Entregas = int.Parse(value); break;
                case 3:
                    travel.NumeroViagem = int.Parse(value); break;
                case 4:
                    travel.DataViagem = DateTime.Parse(value); break;
                case 5:
                    travel.Destino = value; break;
                case 6:
                    travel.Placa = value; break;
                case 7:
                    travel.Motorista = value; break;
                case 8:
                    travel.TipoVeiculo = Enum.Parse<TipoVeiculo>(value); break;
                case 9:
                    travel.KmRodados = int.Parse(value); break;
                case 10:
                    travel.CaixasCarregagas = int.Parse(value); break;
                case 11:
                    travel.TipoViagem = value == "Fullfilment" ? TipoViagem.Fullfilment : TipoViagem.LastMile; break;
                default:
                    break;
            }
        }

    }



}
