using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SMGBit.Domain.ValueObjects
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoViagem
    {
        [Description("Fullfilment")]
        Fullfilment,
        [Description("LastMile")]
        LastMile,
    }
}