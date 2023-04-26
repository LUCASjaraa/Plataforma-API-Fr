
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.Eventos;

using System.Linq;
using Api.Modules.SubirArchivo;

namespace Api.Modules.DatoInteres
{
    public class DatosInteresService
    {
        private IMongoCollection<BsonDocument> _DatosInteres;
        private UploadFileService _subirFile;


        public DatosInteresService(IEventosSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _DatosInteres = database.GetCollection<BsonDocument>(settings.Collection);
            _subirFile = new UploadFileService();
        }

        public async Task<List<datosInteres>> GetAllDatoInteres()
        // public async Task<string> GetAllDatoInteres()

        {
            var projection = Builders<BsonDocument>.Projection.Include("datos_interes").Exclude("_id");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = await _DatosInteres.FindAsync(filter, options).Result.ToListAsync();
            var data = BsonSerializer.Deserialize<List<DatosInteres>>(result.ToJson());

            var dat = new List<datosInteres>();

            foreach (var item in data)
            {
                foreach (var items in item.datos_interes)
                {
                    dat.Add(items);
                }

                


            }
            return dat;
        }


        public async Task<List<datosInteres>> GetDatoInteres(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("datos_interes").Exclude("_id");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await _DatosInteres.FindAsync(filter, options).Result.FirstAsync();
            return BsonSerializer.Deserialize<DatosInteres>(result.ToJson()).datos_interes;

        }

        public async Task CreateDatoInteres(string id, datosInteres datosInteres)
        {
            datosInteres.interes_id = ObjectId.GenerateNewId().ToString();
            datosInteres datosInteresup = new datosInteres()
            {
                interes_id = datosInteres.interes_id,
                titulo=datosInteres.titulo,
                descripcion = datosInteres.descripcion
               
            };

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.Push("datos_interes", datosInteresup);
            await _DatosInteres.UpdateOneAsync(filter, update);

        }



        public async Task UpdateDatoInteres(string id, datosInteres datosInteres)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<BsonDocument>.Filter.Eq("datos_interes.interes_id", ObjectId.Parse(datosInteres.interes_id)));
            var updatointeres = new List<UpdateDefinition<BsonDocument>>();            
            if (datosInteres.titulo !="" && datosInteres.titulo !=null) updatointeres.Add(Builders<BsonDocument>.Update.Set("datos_interes.$.titulo", datosInteres.titulo));
            if(datosInteres.descripcion !="" && datosInteres.descripcion !=null) updatointeres.Add(Builders<BsonDocument>.Update.Set("datos_interes.$.descripcion", datosInteres.descripcion));
            var update = Builders<BsonDocument>.Update.Combine(updatointeres);
            await _DatosInteres.UpdateOneAsync(filter, update);
        }


        public async Task deleteDatoInteres(string id, string id_dinteres)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.PullFilter("datos_interes", Builders<BsonDocument>.Filter.Eq("interes_id", ObjectId.Parse(id_dinteres)));
            await _DatosInteres.UpdateOneAsync(filter, update);
        }

    }
}
