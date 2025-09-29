using System;
using System.Collections.Generic;
using AcoesDeMercado;

public class CriarEvento
{
    public List<Eventos> _eventos { get; set; }
    public List<Empresas> _empresas { get; set; }
    public MinhasAcoes _carteira { get; set; }

    public CriarEvento(List<Eventos> eventos, List<Empresas> empresas, MinhasAcoes carteira)
    {
        this._eventos = eventos;
        this._empresas = empresas;
        _carteira = carteira;
    }
    public void AdicionarEvento()
    {
        bool continuar = true;
        Random random = new Random();
        while (continuar)
        {
            Console.WriteLine("\nDigite 1 para gerar evento ou 0 para sair: ");
            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                if (escolha == 0)
                {
                    continuar = false;
                    break;
                }
                else if (escolha == 1)
                {
                    Console.WriteLine("\n Gerando evento... ");
                    int indice = random.Next(_eventos.Count);
                    Eventos eventoEscolhido = _eventos[indice];

                    Console.WriteLine($"\n Evento: {eventoEscolhido.TituloEvento}");
                    Console.WriteLine($" {eventoEscolhido.DescricaoEvento}");
                    Console.WriteLine($" Empresa afetada: {eventoEscolhido.NomeEmpresa}");
                    Console.WriteLine($" Efeito na ação: {eventoEscolhido.Efeito}");


                        Empresas empresaAfetada = _empresas.Find(e => e.NomeEmpresa == eventoEscolhido.NomeEmpresa);
                    empresaAfetada.ValorAcao += eventoEscolhido.Efeito;

                    foreach (var compra in _carteira.compras)
                    {
                        if (compra.NomeEmpresa == eventoEscolhido.NomeEmpresa)
                        {
                            compra.ValorUnitario += eventoEscolhido.Efeito;

                        }
                    }
                    JsonHelper.SalvarEventos(_eventos);
                    JsonHelper.SalvarCarteira(_carteira);

                    Console.WriteLine($"Novo valor da ação: R$ {empresaAfetada.ValorAcao:F2}");
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }
            }
        }
    }
}


