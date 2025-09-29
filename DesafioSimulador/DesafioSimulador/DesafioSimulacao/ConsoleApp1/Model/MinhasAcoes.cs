public class MinhasAcoes
{
    public double ValorEmAcao { get; set; }
    public List<Compra> compras { get; set; }
    public MinhasAcoes(double valorEmAcao = 10000.00)
    {
        ValorEmAcao = valorEmAcao;
        compras = new List<Compra>();
    }
}