using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace AcoesDeMercado
{
    public class Empresas
    {
        [JsonPropertyName("Nome")]
        public string NomeEmpresa { get; set; }
        [JsonPropertyName("ValorAcao")]
        public double ValorAcao { get; set; }
        [JsonPropertyName("Setor")]
        public string Setor { get; set; }
        [JsonPropertyName("Descricao")]
        public string DescricaoEmpresa { get; set; }
        public Empresas(string nomeEmpresa, double valorAcao, string setor, string descricaoEmpresa)
        {
            this.NomeEmpresa = nomeEmpresa;
            this.ValorAcao = valorAcao;
            this.Setor = setor;
            this.DescricaoEmpresa = descricaoEmpresa;
        }
    }
}

  






