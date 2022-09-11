using PlaceInTecnicalInterview.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test
{
    public class ControllersTest:IntegrationTest
    {
        [Fact]
        public async Task TestGetTiempo()
        {
            var responseGetTiempo = await testClient.GetAsync("/api/Home/GetTiempo?ciudad=Madrid");

            responseGetTiempo.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestRegistrarPedidoSandboxTrue()
        {
            RegistrarPedidoData pedidoData = new();
            pedidoData.Codigo = "a18";
            pedidoData.Detalle = "sushi";
            pedidoData.RestauranteId = 1;
            pedidoData.Sandbox = true;

            var content = new StringContent(JsonSerializer.Serialize(pedidoData), Encoding.UTF8, "application/json");

            var responseRegistrarPedido = await testClient.PostAsync("/api/Home/RegistrarPedido", content);

            responseRegistrarPedido.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestRegistrarPedidoSandboxFalse()
        {
            RegistrarPedidoData pedidoData = new();
            pedidoData.Codigo = "a18";
            pedidoData.Detalle = "sushi";
            pedidoData.RestauranteId = 1;
            pedidoData.Sandbox = false;

            var content = new StringContent(JsonSerializer.Serialize(pedidoData), Encoding.UTF8, "application/json");

            var responseRegistrarPedido = await testClient.PostAsync("/api/Home/RegistrarPedido", content);

            responseRegistrarPedido.EnsureSuccessStatusCode();
        }
    }
}
