using Microsoft.AspNetCore.Mvc;
using TechnicalInterview.Models;
using TechnicalInterview.Models.Databases;
using TechnicalInterview.Models.Types;
using System.Text.Json;

namespace TechnicalInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Endpoints

        [HttpPost("RegistrarPedido")]
        public async Task<IActionResult> RegistrarPedido([FromBody] RegistrarPedidoData data)
        {
            MysqlClient mysqlClient; MongoDbClient mongoClient;

            if (data.Sandbox)
            {
                mysqlClient = new("desarrollo", GetMysqlUser(), GetMysqlPassword());
                mongoClient = new("desarrollo", GetMongoUser(), GetMongoPassword());
            }
            else
            {
                mysqlClient = new("produccion", GetMongoUser(), GetMysqlPassword());
                mongoClient = new("produccion", GetMongoUser(), GetMongoPassword());
            }

            var ciudad = await mysqlClient.getCiudadRestaurante(data.RestauranteId);

            WeatherApi api = new(GetWeatherAccessKey());

            var tiempo = await api.GetTiempo(ciudad);

            await mysqlClient.guardarPedido(data, tiempo);
            await mongoClient.guardarPedido(data);

            return Ok();
        }

        [HttpGet("GetTiempo")]
        public async Task<IActionResult> GetTiempo([FromQuery] string ciudad)
        {
            WeatherApi api = new(GetWeatherAccessKey());

            Tiempo tiempo = await api.GetTiempo(ciudad);

            return Ok(JsonSerializer.Serialize(tiempo));
        }

        #endregion

        #region Getters
        private string GetWeatherAccessKey ()
        {
            return _configuration.GetValue<string>("WEATHER_API_ACCESS_KEY");
        } 

        private string GetMysqlUser()
        {
            return _configuration.GetValue<string>("MYSQL_USER");
        }

        private string GetMysqlPassword()
        {
            return _configuration.GetValue<string>("MYSQL_PASSWORD");
        }

        private string GetMongoUser()
        {
            return _configuration.GetValue<string>("MONGODB_USER");
        }

        private string GetMongoPassword()
        {
            return _configuration.GetValue<string>("MONGODB_PASSWORD");
        }

        #endregion
    }
}
