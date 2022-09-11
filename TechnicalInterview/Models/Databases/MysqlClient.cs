using MySql.Data.MySqlClient;
using PlaceInTecnicalInterview.Models.Types;

namespace PlaceInTecnicalInterview.Models.Databases
{
    public class MysqlClient
    {
        private readonly string connString;

        public MysqlClient(string database, string user, string password)
        {
            connString = $"Server=127.0.0.1;Database={database};Uid={user};Pwd={password};";
        }

        public async Task guardarPedido(RegistrarPedidoData pedido, Tiempo tiempo)
        {
            try
            {
                using var conn = new MySqlConnection(connString);
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("INSERT INTO pedidos (codigo, descripcion, temperatura, humedad) VALUES (@codigo, @detalle, @temperatura, @humedad)", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@codigo", pedido.Codigo);
                cmd.Parameters.AddWithValue("@detalle", pedido.Detalle);
                cmd.Parameters.AddWithValue("@temperatura", tiempo.Temperatura);
                cmd.Parameters.AddWithValue("@humedad", tiempo.Humedad);

                await cmd.PrepareAsync();
                await cmd.ExecuteNonQueryAsync();
            }

            catch
            {
                throw;
            }
        }

        public async Task<string> getCiudadRestaurante(int id)
        {
            try
            {
                using var conn = new MySqlConnection(connString);
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT nombre_ciudad FROM restaurantes WHERE restaurante_id = @restaurante_id");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@restaurante_id", id);

                await cmd.PrepareAsync();

                return (await cmd.ExecuteScalarAsync())?.ToString();
            }

            catch
            {
                throw;
            }
        }
    }
}
