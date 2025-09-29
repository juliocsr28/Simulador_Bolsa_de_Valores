using System;
using System.Collections.Generic;
using AcoesDeMercado;

public class ComprarAcao
{
    public List<Empresas> _empresas { get; set; }
    public MinhasAcoes _carteira { get; set; }

    public ComprarAcao(MinhasAcoes carteira)
    {
        _empresas = new List<Empresas>();
        _carteira = carteira;
    }
    public void MostrarAcoes()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nA��es Dispon�veis:");
            for (int i = 0; i < _empresas.Count; i++)
            {
                Empresas empresa = _empresas[i];
                Console.WriteLine($"{i + 1} - Nome:{empresa.NomeEmpresa}, Valor:R$ {empresa.ValorAcao}, Setor:{empresa.Setor}, Descri��o:{empresa.DescricaoEmpresa}");
            }
            int escolha;
            while (true)
            {
                Console.Write("Escolha uma a��o para comprar (ou 0 para sair): ");
                if (int.TryParse(Console.ReadLine(), out escolha))
                {
                    if (escolha == 0)
                    {
                        continuar = false;
                        break;
                    }

                    else if (escolha > 0 && escolha <= _empresas.Count)
                    {
                        Empresas empresaEscolhida = _empresas[escolha - 1];
                        Console.Write($"\nEscolha quantas a��es da {empresaEscolhida.NomeEmpresa} deseja comprar ");
                        int quantidade;
                        if (int.TryParse(Console.ReadLine(), out quantidade) && quantidade > 0)
                        {
                            decimal valorTotal = (decimal)(empresaEscolhida.ValorAcao * quantidade);
                            if ((decimal)_carteira.ValorEmAcao >= valorTotal)
                            {
                                Compra novaCompra = new Compra(empresaEscolhida.NomeEmpresa, empresaEscolhida.ValorAcao, quantidade);
                                _carteira.compras.Add(novaCompra);
                                _carteira.ValorEmAcao -= (double)valorTotal;
                                Console.WriteLine($"Voc� comprou {quantidade} a��es da {empresaEscolhida.NomeEmpresa} por R${valorTotal:F2}.\n");
                                JsonHelper.SalvarCarteira(_carteira);
                            }
                            else
                            {
                                Console.WriteLine($"Saldo insuficiente! Voc� precisa de R${valorTotal:F2}, mas s� tem R${_carteira.ValorEmAcao:F2}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inv�lida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Op��o inv�lida. Tente novamente.");
                    }

                }
                
            }

        }
    }
}