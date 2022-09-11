using MongoDB.Driver;
using MongoDB.Bson;
using PlaceInTecnicalInterview.Models.Types;

namespace PlaceInTecnicalInterview.Models.Databases
{
    public class MongoDbClient
    {
        private readonly IMongoDatabase db;

        public MongoDbClient(string database, string user, string password)
        {
            var client = new MongoClient($"mongodb://{user}:{password}@localhost:27017");
            db = client.GetDatabase(database);
        }

        public async Task guardarPedido(RegistrarPedidoData pedido)
        {
            var collection = db.GetCollection<BsonDocument>("pedidos");


            var documentPedido = new BsonDocument
            {
                {"codigo", pedido.Codigo},
                {"detalle", pedido.Detalle}
            };

            await collection.InsertOneAsync(documentPedido);
        }
    }
}
