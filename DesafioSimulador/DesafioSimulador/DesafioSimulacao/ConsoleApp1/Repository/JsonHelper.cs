using System.Text.Json;

namespace AcoesDeMercado;
public static class JsonHelper
{
    private static string caminhoCarteira = "Carteira.json";
    private static string caminhoEventos = "EventosGerados.json";
    private static string caminhoEmpresas = "Empresas.json";

    public static void SalvarCarteira(MinhasAcoes carteira)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(carteira, options);
        File.WriteAllText(caminhoCarteira, json);
    }

    public static MinhasAcoes CarregarCarteira()
    {
        try
        {
            if (!File.Exists(caminhoCarteira))
                return new MinhasAcoes();

            string json = File.ReadAllText(caminhoCarteira);
            return JsonSerializer.Deserialize<MinhasAcoes>(json) ?? new MinhasAcoes();
        }
        catch
        {
            return new MinhasAcoes();
        }
    }
    public static void SalvarEventos(List<Eventos> eventos)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(eventos, options);
        File.WriteAllText(caminhoEventos, json);
    }
    public static List<Eventos> CarregarEventos()
    {
        if (!File.Exists(caminhoEventos))
            return new List<Eventos>();

        string json = File.ReadAllText(caminhoEventos);
        return JsonSerializer.Deserialize<List<Eventos>>(json);
    }

    public static List<Empresas> CarregarEmpresas()
    {
        if (!File.Exists(caminhoEmpresas))
            return new List<Empresas>();

        string json = File.ReadAllText(caminhoEmpresas);
        return JsonSerializer.Deserialize<List<Empresas>>(json);
    }

    public static void SalvarEmpresas(List<Empresas> empresas)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(empresas, options);
        File.WriteAllText(caminhoEmpresas, json);
    }
}