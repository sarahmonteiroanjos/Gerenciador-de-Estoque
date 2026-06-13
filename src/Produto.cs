namespace MeuProjetoEstoque
{
    public class Produto
    {
        public string Nome { get; set; } = "";
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }

        public Produto() { }

        public Produto(string nome, int quantidade, int quantidadeMinima)
        {
            Nome = nome;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
        }
    }
}