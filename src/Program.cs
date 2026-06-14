using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MeuProjetoEstoque
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString =
                config.GetConnectionString("DefaultConnection");

            var viaCepService = new ViaCepService();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("📦 --- GERENCIADOR DE ESTOQUE --- 📦\n");

                Console.WriteLine("1 - Listar Produtos");
                Console.WriteLine("2 - Adicionar Produto");
                Console.WriteLine("3 - Consultar CEP");
                Console.WriteLine("4 - Pesquisar Produto");
                Console.WriteLine("5 - Sair");

                Console.Write("\nEscolha: ");

                string opcao =
                    Console.ReadLine() ?? "";

                if (opcao == "1")
                {
                    using var conn =
                        new NpgsqlConnection(connectionString);

                    await conn.OpenAsync();

                    var cmd = new NpgsqlCommand(
                        @"
                        SELECT
                            nome,
                            quantidade,
                            quantidade_minima
                        FROM produtos",
                        conn
                    );

                    using var reader =
                        await cmd.ExecuteReaderAsync();

                    Console.Clear();

                    while (await reader.ReadAsync())
                    {
                        Console.WriteLine(
                            $"{reader["nome"]} | " +
                            $"Qtd: {reader["quantidade"]} | " +
                            $"Min: {reader["quantidade_minima"]}"
                        );
                    }

                    Console.ReadKey();
                }
                else if (opcao == "2")
                {
                    Console.Write("Nome: ");
                    string nome =
                        Console.ReadLine() ?? "";

                    Console.Write("Quantidade: ");
                    int qtd =
                        int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Quantidade mínima: ");
                    int min =
                        int.Parse(Console.ReadLine() ?? "0");

                    if (qtd < 0)
                    {
                        Console.WriteLine(
                            "\n❌ A quantidade não pode ser menor que 0."
                        );

                        Console.ReadKey();
                        continue;
                    }

                    if (min < 0)
                    {
                        Console.WriteLine(
                            "\n❌ A quantidade mínima não pode ser menor que 0."
                        );

                        Console.ReadKey();
                        continue;
                    }

                    using var conn =
                        new NpgsqlConnection(connectionString);

                    await conn.OpenAsync();

                    var verificaCmd = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM produtos WHERE nome = @nome",
                        conn
                    );

                    verificaCmd.Parameters.AddWithValue(
                        "nome",
                        nome
                    );

                    long existe =
                        (long)(
                            await verificaCmd.ExecuteScalarAsync()
                            ?? 0
                        );

                    if (existe > 0)
                    {
                        Console.WriteLine(
                            "\n❌ Já existe um produto com esse nome."
                        );

                        Console.ReadKey();
                        continue;
                    }

                    var cmd = new NpgsqlCommand(
                        @"
                        INSERT INTO produtos
                        (
                            nome,
                            quantidade,
                            quantidade_minima
                        )
                        VALUES
                        (
                            @nome,
                            @qtd,
                            @min
                        )",
                        conn
                    );

                    cmd.Parameters.AddWithValue(
                        "nome",
                        nome
                    );

                    cmd.Parameters.AddWithValue(
                        "qtd",
                        qtd
                    );

                    cmd.Parameters.AddWithValue(
                        "min",
                        min
                    );

                    await cmd.ExecuteNonQueryAsync();

                    Console.WriteLine(
                        "\n✅ Produto salvo no banco!"
                    );

                    Console.ReadKey();
                }
                else if (opcao == "3")
                {
                    Console.Write("Digite CEP: ");

                    string cep =
                        Console.ReadLine() ?? "";

                    var endereco =
                        await viaCepService
                            .BuscarCepAsync(cep);

                    if (endereco != null)
                    {
                        Console.WriteLine(
                            endereco.Localidade
                        );
                    }

                    Console.ReadKey();
                }
                else if (opcao == "4")
                {
                    Console.Write(
                        "Digite o nome do produto: "
                    );

                    string termo =
                        Console.ReadLine() ?? "";

                    using var conn =
                        new NpgsqlConnection(connectionString);

                    await conn.OpenAsync();

                    var cmd = new NpgsqlCommand(
                        @"
                        SELECT
                            nome,
                            quantidade,
                            quantidade_minima
                        FROM produtos
                        WHERE nome ILIKE @termo",
                        conn
                    );

                    cmd.Parameters.AddWithValue(
                        "termo",
                        $"%{termo}%"
                    );

                    using var reader =
                        await cmd.ExecuteReaderAsync();

                    Console.Clear();

                    Console.WriteLine(
                        "🔎 RESULTADOS DA PESQUISA\n"
                    );

                    bool encontrou = false;

                    while (await reader.ReadAsync())
                    {
                        encontrou = true;

                        Console.WriteLine(
                            $"{reader["nome"]} | " +
                            $"Qtd: {reader["quantidade"]} | " +
                            $"Min: {reader["quantidade_minima"]}"
                        );
                    }

                    if (!encontrou)
                    {
                        Console.WriteLine(
                            "❌ Nenhum produto encontrado."
                        );
                    }

                    Console.ReadKey();
                }
                else if (opcao == "5")
                {
                    break;
                }
            }
        }
    }
}