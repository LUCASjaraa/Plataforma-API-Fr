
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.Eventos;
using Api.Modules.Galeria;
using System.Linq;
using Microsoft.OpenApi.Writers;
using System.Collections;
using Api.Modules.CategoriaTrivia;
namespace Api.Modules.Comentario
{
    public class ComentarioService  
    {
        private IMongoCollection<BsonDocument> _Comentarios;

        public ComentarioService(IEventosSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Comentarios = database.GetCollection<BsonDocument>(settings.Collection);
        }

        public async Task<List<comentario>> GetAllComentario(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("comentarios").Exclude("_id");
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _Comentarios.FindAsync(filter, options).Result.FirstAsync();
        return BsonSerializer.Deserialize<Comentario>(result.ToJson()).comentarios;
        }

        public async Task<List<comentario>> comentarioById(string id, string id_usuario)
        {
            var comentarios = await GetAllComentario(id);
            List<comentario> comentariosU = comentarios.Where(c => c.usuario_id == id_usuario).ToList();
            return comentariosU;
        }


        //the create method require objectId of event and comment body
        public async Task CreateCoemntario(string id, addComentario comentarios)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            comentario comentario = new comentario(comentarios);           
            var update = Builders<BsonDocument>.Update.Push("comentarios", comentario);
            await _Comentarios.UpdateOneAsync(filter, update);
        }


        //metodo para actualizar los comentarios (se pensara en separar los likes ya que requieren de otra funcion)
        //falta pedir los parametros ;$
        public async Task UpdateComentario(string id, updatecomentario comentario)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<BsonDocument>.Filter.Eq("comentarios.comentario_id", ObjectId.Parse(comentario.comentario_id)));

            var upcomentario = new List<UpdateDefinition<BsonDocument>>();
            if (comentario.titulo != "" && comentario.titulo != null) { upcomentario.Add(Builders<BsonDocument>.Update.Set("comentarios.$.titulo", comentario.titulo)); }
            if (comentario.contenido != "" && comentario.contenido != null) upcomentario.Add(Builders<BsonDocument>.Update.Set("comentarios.$.contenido", comentario.contenido));
            if (comentario.fecha_subida != "" && comentario.fecha_subida != null) upcomentario.Add(Builders<BsonDocument>.Update.Set("comentarios.$.fecha_subida", comentario.fecha_subida));
            var update = Builders<BsonDocument>.Update.Combine(upcomentario);
            await _Comentarios.UpdateOneAsync(filter, update);

        }

        //idE es el id del evento, idU es el id del comentario del usuario
        public async Task deleteComentario(string id, string id_comentario)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.PullFilter("comentarios", Builders<BsonDocument>.Filter.Eq("comentario_id", ObjectId.Parse(id_comentario)));
            await _Comentarios.UpdateOneAsync(filter, update);

        }

        //nuevo metood************************
        public async Task InsertLike(string id_comentario, string id_usuario)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("comentarios.comentario_id", ObjectId.Parse(id_comentario));
            var update = Builders<BsonDocument>.Update.Push("comentarios.$.likes", new ObjectId(id_usuario));
            await _Comentarios.UpdateOneAsync(filter, update);
        }

        public async Task deleteLike(string id_comentario, string id_usuario)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("comentarios.comentario_id", ObjectId.Parse(id_comentario));
            var update = Builders<BsonDocument>.Update.Pull("comentarios.$.likes", ObjectId.Parse(id_usuario));
            await _Comentarios.UpdateOneAsync(filter, update);

        }

        public async Task AprobarComentario(string id, string id_comentario)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<BsonDocument>.Filter.Eq("comentarios.comentario_id", ObjectId.Parse(id_comentario)));
            var update = Builders<BsonDocument>.Update.Set("comentarios.$.aceptado", true);
            await _Comentarios.UpdateOneAsync(filter, update);
        }

    }
}