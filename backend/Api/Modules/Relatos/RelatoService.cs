using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.SubirArchivo;
using Api.Modules.Eventos;
using Api.Modules.Galeria;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Api.Modules.Relatos
{
    public class RelatoService
    {
        private IMongoCollection<BsonDocument> _Relato;

        private UploadFileService _subirFile;


        public RelatoService(IEventosSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Relato = database.GetCollection<BsonDocument>(settings.Collection);
            _subirFile = new UploadFileService();
        }


        public async Task<List<relato>> getAllRelato(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("relatos").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };

            var result = await _Relato.FindAsync(filter, options).Result.FirstAsync();
            return BsonSerializer.Deserialize<Relato>(result.ToJson()).relatos;
        }

        public async Task<relatoDelete> getUrl(string id, string id_relato)
        {
            var realto = await getAllRelato(id);
            relatoDelete relatod = new relatoDelete();

            relatod.usuario_id = realto.Where(i => i.relato_id == id_relato).FirstOrDefault().usuario_id;
            relatod.contenido = realto.Where(i => i.relato_id == id_relato).FirstOrDefault().contenido;

            return relatod;
        }


        public async Task createRelato(string id, relatoDTO relato)
        {
            var id_relato = ObjectId.GenerateNewId().ToString();

            UploadFile FileRelato = await _subirFile.reltaroAdd(id, relato.usuario_id, id_relato, relato.Archivo);
            if (FileRelato.status)
            {
                relato.contenido = FileRelato.urlFile;

                relato json = new relato
                {
                    usuario_id = relato.usuario_id,
                    relato_id = id_relato,
                    titulo = relato.titulo,
                    contenido = relato.contenido,
                    likes = new List<string>(),
                    fecha_subida = relato.fecha_subida,
                    aceptado = true,
                };

                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<BsonDocument>.Update.Push("relatos", json);
                await _Relato.UpdateOneAsync(filter, update);
            }
        }




        public async Task updateRelato(string id, relatoDTO relato)
        {
            var filter = Builders<BsonDocument>.Filter.And(
            Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
            Builders<BsonDocument>.Filter.Eq("relatos.relato_id", ObjectId.Parse(relato.relato_id)));
            var updateRelato = new List<UpdateDefinition<BsonDocument>>();


            if (relato.Archivo!=null)
            {
                var data = await getUrl(id, relato.relato_id);
                if (_subirFile.reltaroDelete(id, data.usuario_id, relato.relato_id, data.contenido))
                {
                    UploadFile FileRelato = await _subirFile.reltaroAdd(id, data.usuario_id, relato.relato_id, relato.Archivo);
                    if (FileRelato.status) { updateRelato.Add(Builders<BsonDocument>.Update.Set("relatos.$.contenido", FileRelato.urlFile)); }
                }
            }

            if (relato.titulo != null && relato.titulo != "")
            {
                updateRelato.Add(Builders<BsonDocument>.Update.Set("relatos.$.titulo", relato.titulo));
            }
            if (relato.fecha_subida != null && relato.fecha_subida != "")
            {
                updateRelato.Add(Builders<BsonDocument>.Update.Set("relatos.$.fecha_subida", relato.fecha_subida));
            }

            var update = Builders<BsonDocument>.Update.Combine(updateRelato);
            await _Relato.UpdateOneAsync(filter, update);
        }

        public async Task deleteRelato(string id, string id_realto)
        {
            var data = await getUrl(id, id_realto);
            if (_subirFile.reltaroDelete(id, data.usuario_id, id_realto, data.contenido))
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<BsonDocument>.Update.PullFilter("relatos", Builders<BsonDocument>.Filter.Eq("relato_id", ObjectId.Parse(id_realto)));
                await _Relato.UpdateOneAsync(filter, update);
            }
        }

        public async Task insertLike(string id_relato, string id_usuario)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("relatos.relato_id", ObjectId.Parse(id_relato));
            var update = Builders<BsonDocument>.Update.Push("relatos.$.likes", new ObjectId(id_usuario));
            await _Relato.UpdateOneAsync(filter, update);
        }
        public async Task deleteLike(string id_relato, string id_usuario)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("relatos.relato_id", ObjectId.Parse(id_relato));
            var update = Builders<BsonDocument>.Update.Pull("relatos.$.likes", ObjectId.Parse(id_usuario));
            await _Relato.UpdateOneAsync(filter, update);
        }


        public async Task aprobarRelato(string id, string id_relato)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<BsonDocument>.Filter.Eq("relatos.relato_id", ObjectId.Parse(id_relato)));
            var update = Builders<BsonDocument>.Update.Set("relatos.$.aceptado", true);
            await _Relato.UpdateOneAsync(filter, update);
        }
    }
}