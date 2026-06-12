using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MeuProjetoEstoque
{
    class Program
    {
        // Alterado para "static async Task" para permitir o uso de internet (async/await) do ViaCEP
        static async Task Main(string[] args)
        {
            List<Produto> estoque = new List<Produto>();
            var viaCepService = new ViaCepService();

            // Dados iniciais de teste (da sua primeira etapa)
            estoque.Add(new Produto("Farinha de Trigo", 15, 5));
            estoque.Add(new Produto("Açúcar Refinado", 3, 10)); // Gera alerta (qtd < minima)
            estoque.Add(new Produto("Fermento Químico", 8, 2));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("📦 --- GERENCIADOR DE ESTOQUE --- 📦\n");
                Console.WriteLine("1 - Listar Produtos em Estoque");
                Console.WriteLine("2 - Adicionar Novo Produto");
                Console.WriteLine("3 - Consultar CEP (Novo Fornecedor)");
                Console.WriteLine("4 - Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine() ?? "";

                if (opcao == "1")
                {
                    Console.Clear();
                    Console.WriteLine("📋 --- PRODUTOS CADASTRADOS --- 📋\n");

                    foreach (var prod in estoque)
                    {
                        Console.Write($"- {prod.Nome} | Qtd: {prod.Quantidade} (Mínimo: {prod.QuantidadeMinima})");

                        // Alerta visual se o estoque estiver baixo
                        if (prod.Quantidade < prod.QuantidadeMinima)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ⚠️ [ALERTA: ESTOQUE BAIXO]");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
                else if (opcao == "2")
                {
                    Console.Clear();
                    Console.WriteLine("➕ --- CADASTRAR NOVO PRODUTO --- ➕\n");

                    Console.Write("Nome do Produto: ");
                    string nome = Console.ReadLine() ?? "";

                    // Validação do nome
                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNome do produto é obrigatório!");
                        Console.ResetColor();

                        Console.ReadKey();
                        continue;
                    }

                    // Verifica se o produto já existe
                    if (estoque.Any(p =>
                        p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nProduto já cadastrado!");
                        Console.ResetColor();

                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Quantidade Atual: ");

                    // Validação da quantidade
                    if (!int.TryParse(Console.ReadLine(), out int qtd) || qtd < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nQuantidade inválida!");
                        Console.ResetColor();

                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Quantidade Mínima de Alerta: ");

                    // Validação da quantidade mínima
                    if (!int.TryParse(Console.ReadLine(), out int qtdMin) || qtdMin < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nQuantidade mínima inválida!");
                        Console.ResetColor();

                        Console.ReadKey();
                        continue;
                    }

                    estoque.Add(new Produto(nome, qtd, qtdMin));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nProduto '{nome}' cadastrado com sucesso!");
                    Console.ResetColor();

                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
                else if (opcao == "3")
                {
                    Console.Clear();
                    Console.WriteLine("🔍 --- CONSULTAR CEP DE FORNECEDOR --- 🔍\n");
                    Console.Write("Digite o CEP (ex: 01001000): ");
                    string cepDigitado = Console.ReadLine() ?? "";

                    Console.WriteLine("\nConsultando a API do ViaCEP... Aguarde...");

                    // Integração com o serviço de CEP criado na etapa intermediária
                    var endereco = await viaCepService.BuscarCepAsync(cepDigitado);

                    if (endereco != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✅ Endereço Encontrado com Sucesso!");
                        Console.ResetColor();

                        Console.WriteLine($"------------------------------------");
                        Console.WriteLine($"📍 Logradouro: {endereco.Logradouro}");
                        Console.WriteLine($"🏘️ Bairro:     {endereco.Bairro}");
                        Console.WriteLine($"🏙️ Cidade:     {endereco.Localidade}");
                        Console.WriteLine($"🇧🇷 Estado:     {endereco.Uf}");
                        Console.WriteLine($"------------------------------------");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n❌ CEP não encontrado ou inválido. Verifique a conexão.");
                        Console.ResetColor();
                    }

                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
                else if (opcao == "4")
                {
                    Console.WriteLine("\nObrigado por usar o sistema. Até logo!");
                    break;
                }
                else
                {
                    Console.WriteLine("\n❌ Opção inválida! Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                }
            }
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }

        public Produto(string nome, int quantidade, int quantidadeMinima)
        {
            Nome = nome;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
        }
    }
}