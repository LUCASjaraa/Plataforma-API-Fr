using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.Eventos;

namespace Api.Modules.Visitas
{
    public class VisitaService 
    {

        private IMongoCollection<BsonDocument> _Visita;

        public VisitaService(IEventosSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Visita = database.GetCollection<BsonDocument>(settings.Collection);
        }


        public async Task<List<visita>> GetAllVisita(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("visitas").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _Visita.FindAsync(filter, options).Result.FirstAsync();
            return BsonSerializer.Deserialize<Visita>(result.ToJson()).visitas;
        }

        public async Task CreateVisita(string id, visita visita)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.Push("visitas", visita);
            await _Visita.UpdateOneAsync(filter, update);
        }

        public async Task deleteVisita(string idE, string idU)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(idE));
            var update = Builders<BsonDocument>.Update.PullFilter("visitas", Builders<BsonDocument>.Filter.Eq("usuario_id", ObjectId.Parse(idU)));
            await _Visita.UpdateOneAsync(filter, update);

        }


    }
}