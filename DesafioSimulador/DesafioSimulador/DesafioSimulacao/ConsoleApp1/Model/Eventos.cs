using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace AcoesDeMercado
{
    public class Eventos
    {
        [JsonPropertyName("Titulo")]
        public string TituloEvento { get; set; }
        [JsonPropertyName("Descricao")]
        public string DescricaoEvento { get; set; }
        [JsonPropertyName("Efeito")]
        public double Efeito { get; set; }
        [JsonPropertyName("Empresa")]
        public string NomeEmpresa { get; set; }
        public Eventos(string tituloEvento, string descricaoEvento, double efeito, string nomeEmpresa)
        {
            this.TituloEvento = tituloEvento;
            this.DescricaoEvento = descricaoEvento;
            this.Efeito = efeito;
            this.NomeEmpresa = nomeEmpresa;
        }
    }
}

