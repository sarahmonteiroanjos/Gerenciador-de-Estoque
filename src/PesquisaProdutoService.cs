using System;
using System.Collections.Generic;
using System.Linq;
using MeuProjetoEstoque;

namespace MeuProjetoEstoque
{
    /// <summary>
    /// Extensão responsável pela pesquisa de produtos no estoque.
    /// Suporta busca parcial (contém), sem distinção de maiúsculas/minúsculas.
    /// </summary>
    public static class PesquisaProdutoService
    {
        /// <summary>
        /// Exibe o menu interativo de pesquisa de produtos no console.
        /// </summary>
        /// <param name="estoque">Lista de produtos atualmente cadastrados.</param>
        public static void ExibirMenuPesquisa(List<Produto> estoque)
        {
            Console.Clear();
            Console.WriteLine("🔎 --- PESQUISAR PRODUTO --- 🔎\n");

            if (estoque.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️  Nenhum produto cadastrado no estoque ainda.");
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o nome (ou parte do nome) do produto: ");
            string termo = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(termo))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n⚠️  Nenhum termo digitado. Voltando ao menu...");
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            var resultados = Pesquisar(estoque, termo);

            Console.Clear();
            Console.WriteLine($"🔎 --- RESULTADOS DA PESQUISA: \"{termo}\" --- 🔎\n");

            if (resultados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Nenhum produto encontrado com o termo \"{termo}\".");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"✅ {resultados.Count} produto(s) encontrado(s):\n");
                Console.ResetColor();

                Console.WriteLine(new string('─', 60));

                foreach (var prod in resultados)
                {
                    ExibirProduto(prod, termo);
                }

                Console.WriteLine(new string('─', 60));
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Realiza a busca na lista de produtos pelo termo informado.
        /// A comparação ignora maiúsculas/minúsculas e acenta.
        /// </summary>
        /// <param name="estoque">Lista de produtos.</param>
        /// <param name="termo">Texto a ser buscado no nome do produto.</param>
        /// <returns>Lista de produtos que correspondem ao termo.</returns>
        public static List<Produto> Pesquisar(List<Produto> estoque, string termo)
        {
            return estoque
                .Where(p => p.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Nome)
                .ToList();
        }

        // ──────────────────────────────────────────────
        // Métodos privados de apoio à exibição
        // ──────────────────────────────────────────────

        private static void ExibirProduto(Produto prod, string termoBuscado)
        {
            // Nome com destaque do trecho encontrado
            Console.Write("📦 ");
            DestacarTermo(prod.Nome, termoBuscado);

            // Quantidade e mínima
            Console.Write($"   Qtd: {prod.Quantidade}");
            Console.Write($" | Mínimo: {prod.QuantidadeMinima}");

            // Status do estoque
            Console.Write("   Status: ");
            if (prod.Quantidade == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("🚫 SEM ESTOQUE");
            }
            else if (prod.Quantidade < prod.QuantidadeMinima)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️  ESTOQUE BAIXO");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ OK");
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Imprime o texto no console destacando (em amarelo) a parte que bate com o termo buscado.
        /// </summary>
        private static void DestacarTermo(string texto, string termo)
        {
            int indice = texto.IndexOf(termo, StringComparison.OrdinalIgnoreCase);

            if (indice < 0)
            {
                Console.WriteLine(texto);
                return;
            }

            // Parte antes do termo
            Console.Write(texto[..indice]);

            // Parte que bate com o termo (destacada em amarelo)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(texto.Substring(indice, termo.Length));
            Console.ResetColor();

            // Parte após o termo
            Console.WriteLine(texto[(indice + termo.Length)..]);
        }
    }
}
