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
            // Arrange
            var viaCepService = new ViaCepService();
            string cepValido = "01001000";

            // Act
            var resultado = await viaCepService.BuscarCepAsync(cepValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("São Paulo", resultado.Localidade);
            Assert.Equal("SP", resultado.Uf);
        }
    }
}