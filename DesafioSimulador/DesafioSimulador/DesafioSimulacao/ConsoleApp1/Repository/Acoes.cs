using System.Collections.Generic;
using System.Text.Json;

namespace AcoesDeMercado
{
    public class Acoes
    {
        private List<Empresas> _empresas;
        public List<Empresas> empresas { get => _empresas; }
        private List<Eventos> _eventos;
        public List<Eventos> eventos { get => _eventos; }

        public Acoes()
        {
            string jsonEmpresas = File.ReadAllText("Empresas.json");
            _empresas = JsonSerializer.Deserialize<List<Empresas>>(jsonEmpresas) ?? new List<Empresas>();

            string jsonEventos = File.ReadAllText("Eventos.json");
            _eventos = JsonSerializer.Deserialize<List<Eventos>>(jsonEventos) ?? new List<Eventos>();

        }
    }
}