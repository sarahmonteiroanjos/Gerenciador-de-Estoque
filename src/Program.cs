using System;
using System.Collections.Generic;

namespace ControleEstoque
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> nomes = new List<string>();
            List<int> quantidades = new List<int>();
            List<int> minimos = new List<int>();

            bool rodando = true;

            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("--- SISTEMA DE ESTOQUE PARA MICROEMPREENDEDORES ---");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Ver Estoque e Alertas");
                Console.WriteLine("3 - Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.Write("Nome do produto: ");
                    string nome = Console.ReadLine();

                    Console.Write("Quantidade atual: ");
                    int qtd = int.Parse(Console.ReadLine());

                    Console.Write("Avisar quando chegar em quanto? (Mínimo): ");
                    int min = int.Parse(Console.ReadLine());

                    nomes.Add(nome);
                    quantidades.Add(qtd);
                    minimos.Add(min);

                    Console.WriteLine("\nProduto salvo! Aperte qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("\n--- RELATÓRIO DE ESTOQUE ---");
                    for (int i = 0; i < nomes.Count; i++)
                    {
                        Console.Write($"{nomes[i]} - Qtd: {quantidades[i]}");


                        if (quantidades[i] <= minimos[i])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" [ ALERTA: ESTOQUE BAIXO! RECOMPRAR ]");
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\nAperte qualquer tecla para voltar.");
                    Console.ReadKey();
                }
                else if (opcao == "3")
                {
                    rodando = false;
                }
            }

            Console.WriteLine("Programa encerrado. Boas vendas!");
        }
    }
}