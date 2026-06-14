using Xunit;
using System.Threading.Tasks;
using MeuProjetoEstoque;

namespace MeusTestes
{
    public class IntegrationTest
    {
        [Fact]
        public async Task Deve_Retornar_Endereco_Correto_Quando_Cep_For_Valido()
        {
            var viaCepService = new ViaCepService();
            string cepValido = "01001000";

            var resultado = await viaCepService.BuscarCepAsync(cepValido);

            Assert.NotNull(resultado);
            Assert.Equal("São Paulo", resultado.Localidade);
            Assert.Equal("SP", resultado.Uf);
        }

        [Fact]
        public async Task Deve_Aceitar_Cep_Com_Hifen()
        {
            var viaCepService = new ViaCepService();

            var resultado =
                await viaCepService.BuscarCepAsync("01001-000");

            Assert.NotNull(resultado);
            Assert.Equal("São Paulo", resultado.Localidade);
        }

        [Fact]
        public async Task Deve_Aceitar_Cep_Com_Espacos()
        {
            var viaCepService = new ViaCepService();

            var resultado =
                await viaCepService.BuscarCepAsync("01001 000");

            Assert.NotNull(resultado);
        }

        [Fact]
        public async Task Deve_Retornar_Null_Quando_Cep_For_Vazio()
        {
            var viaCepService = new ViaCepService();

            var resultado =
                await viaCepService.BuscarCepAsync("");

            Assert.Null(resultado);
        }

        [Fact]
        public async Task Deve_Retornar_Null_Quando_Cep_For_Menor_Que_Oito_Digitos()
        {
            var viaCepService = new ViaCepService();

            var resultado =
                await viaCepService.BuscarCepAsync("123");

            Assert.Null(resultado);
        }

        [Fact]
        public async Task Deve_Retornar_Null_Quando_Cep_For_Maior_Que_Oito_Digitos()
        {
            var viaCepService = new ViaCepService();

            var resultado =
                await viaCepService.BuscarCepAsync("123456789");

            Assert.Null(resultado);
        }

        [Fact]
        public async Task Deve_Retornar_Endereco_Vazio_Quando_Cep_Nao_Existir()
        {
            var viaCepService = new ViaCepService();

            var resultado =
                await viaCepService.BuscarCepAsync("00000000");

            Assert.NotNull(resultado);
            Assert.Equal("", resultado.Cep);
            Assert.Equal("", resultado.Localidade);
            Assert.Equal("", resultado.Uf);
        }

        [Fact]
        public async Task Deve_Retornar_Null_Quando_Cep_Contiver_Letras()
        {
            var viaCepService = new ViaCepService();

            var resultado =
                await viaCepService.BuscarCepAsync("ABCDEFGH");

            Assert.Null(resultado);
        }
    }
}