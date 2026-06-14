using System;

namespace MeuProjetoEstoque
{
    public class Produto
    {
        public string Nome { get; set; } = "";

        public int Quantidade { get; set; }

        public int QuantidadeMinima { get; set; }

        public Produto()
        {
        }

        public Produto(string nome, int quantidade, int quantidadeMinima)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("O nome do produto é obrigatório.");
            }

            if (quantidade < 0)
            {
                throw new Exception("A quantidade não pode ser menor que 0.");
            }

            if (quantidadeMinima < 0)
            {
                throw new Exception("A quantidade mínima não pode ser menor que 0.");
            }

            Nome = nome;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
        }
    }

}
