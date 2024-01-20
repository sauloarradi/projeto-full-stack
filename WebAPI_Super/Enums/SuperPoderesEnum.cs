using System.Text.Json.Serialization;

namespace WebAPI_Super.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SuperPoderesEnum
    {
        Super_Força,
        Super_Resistência,
        Super_Velocidade,
        Elasticidade,
        Imortalidade,
        Invisibilidade,
        Intangibilidade,
        Amorfismo,
        Camuflagem,
        Super_Inteligencia,
        Voo,
        Magia,
        Telepatia
    }
}
