using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using TechnicalInterview.Models.Types;

namespace TechnicalInterview.Models
{
    public class WeatherApi
    {
        private readonly string apiKey;
        private readonly HttpClient client;

        public WeatherApi(string apiKeyEnvVariable)
        {
            apiKey = apiKeyEnvVariable;
            client = new();
            client.BaseAddress = new Uri("http://api.weatherstack.com/");
        }

        public async Task<Tiempo> GetTiempo(string ciudad)
        {
            Dictionary<string, string?> parameters = new() {
                {"access_key", apiKey },
                {"query", ciudad}
            };
            string query = QueryHelpers.AddQueryString("current", parameters);

            var response = await client.GetAsync(query);
            WeatherCurrentApiResult weatherCurrentApiResult =
                JsonSerializer.Deserialize<WeatherCurrentApiResult>(await response.Content.ReadAsStringAsync());

            Tiempo tiempo = new();
            tiempo.Temperatura = weatherCurrentApiResult.current.temperature;
            tiempo.Humedad = weatherCurrentApiResult.current.humidity;

            return tiempo;
        }
    }
}
