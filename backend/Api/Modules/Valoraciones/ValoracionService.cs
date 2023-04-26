using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.Eventos;

namespace Api.Modules.Valoraciones
{
    public class ValoracionService
    {
        private IMongoCollection<BsonDocument> _Valoracion;

        public ValoracionService(IEventosSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Valoracion = database.GetCollection<BsonDocument>(settings.Collection);

        }

        public async Task<List<valoracion>> GetAllValoracion(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("valoraciones").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _Valoracion.FindAsync(filter, options).Result.FirstAsync();
            return BsonSerializer.Deserialize<Valoracion>(result.ToJson()).valoraciones;
        }

        //the create method require objectId of event and comment body
        public async Task CreateValoracion(string id, valoracion valoraciones)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.Push("valoraciones", valoraciones);
            await _Valoracion.UpdateOneAsync(filter, update);

        }


        //metodo para actualizar los comentarios (se pensara en separar los likes ya que requieren de otra funcion)
        //falta pedir los parametros ;$

        public async Task UpdateValoracion(string id, valoracion valoracion)
        {
            var filter = Builders<BsonDocument>.Filter
                .And(
                Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<BsonDocument>.Filter.Eq("valoraciones.usuario_id", ObjectId.Parse(valoracion.usuario_id)));

            var update = Builders<BsonDocument>.Update.Combine(
                 Builders<BsonDocument>.Update.Set("valoraciones.$.val_interes", valoracion.val_interes),
                 Builders<BsonDocument>.Update.Set("valoraciones.$.val_inmersion", valoracion.val_inmersion),
                 Builders<BsonDocument>.Update.Set("valoraciones.$.fecha_val", valoracion.fecha_val));
            await _Valoracion.UpdateOneAsync(filter, update);

        }
        //idE es el id del evento, idU es el id del comentario del usuario
        public async Task deleteValoracion(string id, string id_valoracion)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.PullFilter("valoraciones", Builders<BsonDocument>.Filter.Eq("usuario_id", ObjectId.Parse(id_valoracion)));
            await _Valoracion.UpdateOneAsync(filter, update);

        }


        public async Task<Promedio> Promedios(string id)
        {
            var res = await GetAllValoracion(id);
            long sumaValorInteres = 0;
            long sumaValorInmersion = 0;
            var count = 0;

            foreach (var item in res)
            {
                sumaValorInteres = sumaValorInteres + item.val_interes;
                sumaValorInmersion = sumaValorInmersion + item.val_inmersion;
                count++;
            }
            sumaValorInteres = sumaValorInteres / count;
            sumaValorInmersion = sumaValorInmersion / count;

            var json = new Promedio
            {
                promedio_interes = sumaValorInteres,
                promedio_inmersion = sumaValorInmersion
            };

            return json;
        }


    }
}