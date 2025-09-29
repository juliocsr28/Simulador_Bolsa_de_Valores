public class Compra
{
    public string NomeEmpresa { get; set; }
    public double ValorUnitario { get; set; }
    public int Quantidade { get; set; }
    public double ValorTotal
    {
        get { return Quantidade * ValorUnitario; }
    }


    public Compra(string nomeEmpresa, double valorUnitario, int quantidade)
    {
        NomeEmpresa = nomeEmpresa;
        ValorUnitario = valorUnitario;
        Quantidade = quantidade;
    }
}