
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SMGBit.Domain.ValueObjects
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoVeiculo
    {
        [Description("TRUCK")]
        TRUCK,
        [Description("TRUCK")]
        VUC,
        [Description("CARRETA")]
        CARRETA,
        [Description("VAN")]
        VAN,
        [Description("KOMBI")]
        KOMBI,
        [Description("CAR")]
        CAR,
    }
}
