using AcoesDeMercado;
using System;
class Program
{
    static void Main()
    {
        Acoes interagir = new Acoes();
        MinhasAcoes minhaCarteira = JsonHelper.CarregarCarteira();
        bool respondeu = false;
        do
        {
            Console.WriteLine("\nBem-vindo ao sistema de A��es de Mercado!");
            Console.WriteLine("1 - Comprar A��o");
            Console.WriteLine("2 - Vender A��o");
            Console.WriteLine("3 - Eventos");
            Console.WriteLine("4 - Ver minha Carteira");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma op��o: ");

            string escolha = Console.ReadLine();
            switch (escolha)
            {
                case "1":
                    ComprarAcao comprar = new ComprarAcao(minhaCarteira);
                    comprar._empresas = interagir.empresas;
                    comprar.MostrarAcoes();
                    break;
                case "2":
                    VenderAcao vender = new VenderAcao(minhaCarteira);
                    vender.VenderAcaoSelecionada();
                    break;
                case "3":
                    CriarEvento criarEvento = new CriarEvento(interagir.eventos, interagir.empresas, minhaCarteira);
                    criarEvento.AdicionarEvento();
                    break;

                case "4":
                    Console.WriteLine($"\nSaldo dispon�vel: R$ {minhaCarteira.ValorEmAcao:F2}");

                    if (minhaCarteira.compras.Count == 0)
                    {
                        Console.WriteLine("Nenhuma a��o comprada ainda.\n");
                    }
                    else
                    {
                        foreach (var compra in minhaCarteira.compras)
                        {
                            Console.WriteLine($"Empresa: {compra.NomeEmpresa}, Quantidade: {compra.Quantidade}, Valor Unit�rio: R$ {compra.ValorUnitario:F2}, Total: R$ {compra.ValorTotal:F2}\n");
                        }
                        while (true)
                        {
                            int voltar;
                            Console.WriteLine("Digite 0 para voltar");
                            if (int.TryParse(Console.ReadLine(), out voltar))
                            {
                                if (voltar == 0)
                                {
                                    break;

                                }
                                else
                                {
                                    Console.WriteLine("Op��o inv�lida, tente novamente");

                                }

                            }
                            else
                            {
                                Console.WriteLine("Entrada inv�lida, digite um n�mero.");
                            }

                        }
                    }
                    break;

                case "5":
                    respondeu = true;
                    break;
                default:
                    Console.WriteLine("Op��o inv�lida. Tente novamente.");
                    break;
            }
        } while (!respondeu);
    }
}