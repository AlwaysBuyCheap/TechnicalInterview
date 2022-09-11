using Microsoft.AspNetCore.WebUtilities;
using PlaceInTecnicalInterview.Models.Types;
using System.Text.Json;

namespace PlaceInTecnicalInterview.Models
{
    public class WeatherApi
    {
        private readonly string apiKey;
        private readonly HttpClient client;

        public WeatherApi(string apiKeyEnvVariable)
        {
            //var apiKeyEnvVariable = Environment.GetEnvironmentVariable("WEATHER_API_ACCESS_KEY");
            //var apiKeyEnvVariable = "7be4d5c559bf441da063e5eb84d0c5b5";

            if (apiKeyEnvVariable == null)
            {
                throw new Exception("Debe especificar una access key para la api del tiempo en las variables de entorno");
            }

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
