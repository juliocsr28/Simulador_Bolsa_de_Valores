using System;
using System.Collections.Generic;
using AcoesDeMercado;

public class VenderAcao
{
    public List<Empresas> _empresas { get; set; }
    public MinhasAcoes _carteira { get; set; }

    public VenderAcao(MinhasAcoes carteira)
    {
        _empresas = new List<Empresas>(); ;
        _carteira = carteira;
    }

    public void VenderAcaoSelecionada()
    {
        bool continuar = true;
        while (continuar)
        {
            if (_carteira.compras.Count <= 0)
            {
                Console.WriteLine("\nVocê não possui ações");
                continuar = false;
            }
            else
            {
                Console.WriteLine("\nEscolha uma de suas ações para vender");
                for (int i = 0; i < _carteira.compras.Count; i++)
                {
                    Compra acao = _carteira.compras[i];
                    Console.WriteLine($"{i + 1} - Nome:{acao.NomeEmpresa}, Valor: R$ {acao.ValorUnitario}, Quantidade: {acao.Quantidade}, Total: R$ {acao.ValorTotal}");
                }
            }
            Console.WriteLine("Digite o número da ação que deseja vender (ou 0 para sair)");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= _carteira.compras.Count)
            {
                Compra venda = _carteira.compras[escolha - 1];
                Console.WriteLine($"Quantas ações da {venda.NomeEmpresa} deseja vender?");
                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0 || quantidade > venda.Quantidade)
                {
                    Console.WriteLine("Quantidade inválida. Operação cancelada.");
                    continuar = false;
                    continue;
                }

                double ValorVenda = venda.ValorUnitario * quantidade;
                _carteira.ValorEmAcao += ValorVenda;
                venda.Quantidade -= quantidade;

                Console.WriteLine($"Você vendeu {quantidade} ações da {venda.NomeEmpresa} e recebeu: R${ValorVenda:F2}");

                if (venda.Quantidade == 0)
                {
                    _carteira.compras.RemoveAt(escolha - 1);
                }
                JsonHelper.SalvarCarteira(_carteira);
            }
            else if (escolha == 0)
            {
                continuar = false;
            }
            else
            {
                Console.WriteLine("Operação inválida.");
            }
        }
    }
}