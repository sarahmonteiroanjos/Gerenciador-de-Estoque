using System;
using System.Threading.Tasks;

namespace MeuProjetoEstoque
{
    class Program
    {
        // Alteramos para "static async Task" para permitir comandos que usam a internet (async/await)
        static async Task Main(string[] args)
        {
            var viaCepService = new ViaCepService();

            Console.Clear();
            Console.WriteLine("📦 --- GERENCIADOR DE ESTOQUE --- 📦\n");
            
            // 1. Menu simples de teste
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Testar Consulta de CEP (Novo Fornecedor)");
            Console.WriteLine("2 - Sair");
            Console.Write("\nOpção: ");
            
            string opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
            {
                Console.Write("\nDigite o CEP para buscar o endereço (ex: 01001000): ");
                string cepDigitado = Console.ReadLine() ?? "";

                Console.WriteLine("\nConsultando a API do ViaCEP... Aguarde...");
                
                // Chama o serviço que você criou
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
            }

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}