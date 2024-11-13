using AppClima.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppClima.Services
{
    public class WeatherService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Cidade>> ObterCidadesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://brasilapi.com.br/api/cptec/v1/cidade");

            if (string.IsNullOrEmpty(response))
            {
                return new List<Cidade>();
            }

            try
            {
                return JsonSerializer.Deserialize<List<Cidade>>(response);
            }
            catch (JsonException)
            {
                return new List<Cidade>();
            }
        }
    }
}
