using Newtonsoft.Json.Linq;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Interfaces;

namespace SMGBit.Application.Services;

public class FreteService : IFreteService
{
    public async Task<IList<Travel>> ProcessTravelListToAddFreight(List<Travel> travelList)
    {
        var freteJsonFile = await File.ReadAllTextAsync(Environment.CurrentDirectory + "/tabela-frete.json");
        var objectFrete = JObject.Parse(freteJsonFile);

        foreach (Travel travel in travelList)
        {
            foreach (var prop in objectFrete.Properties())
            {
                if (prop.Value["client"].ToString() == travel.Origem && prop.Value["vehicle_type"].ToString() == travel.TipoVeiculo.ToString())
                {

                    if (prop.Value["destination"] != null && prop.Value["destination"].ToString() == travel.Destino)
                    {
                        travel.TabelaFrete = prop.Name.ToString();
                        travel.ValorViagem = int.Parse(prop.Value["value"].ToString());
                    }
                    else if (prop.Value["destination"] == null)
                    {
                        travel.TabelaFrete = prop.Name.ToString();
                        travel.ValorViagem = int.Parse(prop.Value["value"].ToString());
                    }
                }
            }
        }

        return travelList;
    }
}

