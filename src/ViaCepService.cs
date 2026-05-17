using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeuProjetoEstoque
{
    public class ViaCepService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Endereco?> BuscarCepAsync(string cep)
        {
            cep = cep.Replace("-", "").Replace(" ", "");
            if (cep.Length != 8) return null;

            try
            {
                var url = $"https://viacep.com.br/ws/{cep}/json/";
                var resposta = await _httpClient.GetAsync(url);
                if (!resposta.IsSuccessStatusCode) return null;

                var json = await resposta.Content.ReadAsStringAsync();
                if (json.Contains("\"erro\": true")) return null;

                var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<Endereco>(json, opcoes);
            }
            catch
            {
                return null;
            }
        }
    }

    public class Endereco
    {
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Localidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
    }
}