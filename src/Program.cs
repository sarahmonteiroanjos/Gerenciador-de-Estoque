using System;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MeuProjetoEstoque
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config =
                new ConfigurationBuilder()
                .SetBasePath(
                    Directory.GetCurrentDirectory()
                )
                .AddJsonFile(
                    "appsettings.json"
                )
                .Build();

            string connectionString =
                config.GetConnectionString(
                    "DefaultConnection"
                );

            var viaCepService =
                new ViaCepService();

            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "📦 --- GERENCIADOR DE ESTOQUE --- 📦\n"
                );

                Console.WriteLine(
                    "1 - Listar Produtos"
                );

                Console.WriteLine(
                    "2 - Adicionar Produto"
                );

                Console.WriteLine(
                    "3 - Consultar CEP"
                );

                Console.WriteLine(
                    "4 - Sair"
                );

                Console.Write(
                    "\nEscolha: "
                );

                string opcao =
                    Console.ReadLine()
                    ?? "";

                if (opcao == "1")
                {
                    using var conn =
                        new NpgsqlConnection(
                            connectionString
                        );

                    await conn.OpenAsync();

                    var cmd =
                        new NpgsqlCommand(
                            @"SELECT nome,
                              quantidade,
                              quantidade_minima
                              FROM produtos",
                            conn
                        );

                    using var reader =
                        await cmd
                        .ExecuteReaderAsync();

                    Console.Clear();

                    while (
                        await reader
                        .ReadAsync()
                    )
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
                    Console.Write(
                        "Nome: "
                    );

                    string nome =
                        Console.ReadLine()
                        ?? "";

                    Console.Write(
                        "Quantidade: "
                    );

                    int qtd =
                        int.Parse(
                            Console.ReadLine()
                            ?? "0"
                        );

                    Console.Write(
                        "Quantidade mínima: "
                    );

                    int min =
                        int.Parse(
                            Console.ReadLine()
                            ?? "0"
                        );

                    using var conn =
                        new NpgsqlConnection(
                            connectionString
                        );

                    await conn.OpenAsync();

                    var cmd =
                        new NpgsqlCommand(
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

                    cmd.Parameters
                        .AddWithValue(
                            "nome",
                            nome
                        );

                    cmd.Parameters
                        .AddWithValue(
                            "qtd",
                            qtd
                        );

                    cmd.Parameters
                        .AddWithValue(
                            "min",
                            min
                        );

                    await cmd
                        .ExecuteNonQueryAsync();

                    Console.WriteLine(
                        "\n✅ Produto salvo no banco!"
                    );

                    Console.ReadKey();
                }

                else if (opcao == "3")
                {
                    Console.Write(
                        "Digite CEP: "
                    );

                    string cep =
                        Console.ReadLine()
                        ?? "";

                    var endereco =
                        await viaCepService
                        .BuscarCepAsync(
                            cep
                        );

                    if (endereco != null)
                    {
                        Console.WriteLine(
                            endereco.Localidade
                        );
                    }

                    Console.ReadKey();
                }

                else if (
                    opcao == "4"
                )
                {
                    break;
                }
            }
        }
    }
}