using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Api.Modules.Eventos;
using System.Threading.Tasks;
using System.IO;
using Api.Modules.SubirArchivo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;
using System.Linq;
using Api.Modules.PortalPage;
using System.Collections;

namespace Api.Modules.Galeria
{
    public class GaleriaService
    {
        private IMongoCollection<BsonDocument> _Galeria;
        private UploadFileService _subirFile;

        public GaleriaService(IEventosSettings settings, IConfiguration configuration)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Galeria = database.GetCollection<BsonDocument>(settings.Collection);
            _subirFile = new UploadFileService();
        }

        public async Task<List<galeria>> GetAllGaleria()
        {
            //falata validador de ID
            var projection = Builders<BsonDocument>.Projection.Include("galeria").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _Galeria.FindAsync(filter, options).Result.ToListAsync();
            var data =  BsonSerializer.Deserialize<List<Galeria>>(result.ToJson());
            var dat = new List<galeria>();
            foreach (var items in data)
            {
                foreach (var item in items.galeria)
                {
                    dat.Add(item);
                }
            }
            return dat;
        }


        public async Task<List<galeria>> GetGaleriabyId(string id)
        {
            //falata validador de ID
            var projection = Builders<BsonDocument>.Projection.Include("galeria").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _Galeria.FindAsync(filter,options).Result.FirstAsync();
            return BsonSerializer.Deserialize<Galeria>(result.ToJson()).galeria;
        }



        public async Task<IList> top(int t)
        {
            var data = await GetAllGaleria();
            var galeriaOrder = data.OrderByDescending(x => x.likes.Count).Take(t).ToList();
            var top = (from items in galeriaOrder select new { contenido = items.contenido, id_usuario = items.usuario_id}).ToList();

        /*
           var simpleUsers = galeriaOrder.Select(items => 
           new { contenido = items.contenido, id_usuario = items.usuario_id });

            var simpleUsersQ = (from user in listOfUsers
               select new
               {
                   Name = user.Name,
                   Age = user.Age
               }).ToList();
        */
            return top;
        }


















        public async Task<galeriaDelete> getUrl(string id, string id_galeria)
        {
            var galerias= await GetGaleriabyId(id);
            galeriaDelete galeriad = new galeriaDelete();
            galeriad.usuario_id = galerias.Where(i => i.galeria_id == id_galeria).FirstOrDefault().usuario_id;
            galeriad.contenido = galerias.Where(i => i.galeria_id == id_galeria).FirstOrDefault().contenido;
            galeriad.tipo = galerias.Where(i => i.galeria_id == id_galeria).FirstOrDefault().tipo;

            return galeriad;
        }

        public async Task CreateGaleria(string id, string tipo, addGaleria galeria)
        {

            string id_galeria = ObjectId.GenerateNewId().ToString();
            switch (tipo)
            {
                case "imagen":
                    UploadFile FileImg = await _subirFile.galeriaAdd("img", id, galeria.usuario_id,id_galeria,  galeria.Archivo);
                    if (FileImg.status)
                    {
                        galeria.contenido = FileImg.urlFile;
                        galeria.tipo = "img";
                    }
                    break;
                case "video":
                    UploadFile FileVideo = await _subirFile.galeriaAdd("video", id, galeria.usuario_id, id_galeria, galeria.Archivo);
                    if (FileVideo.status)
                    {
                        galeria.contenido = FileVideo.urlFile;
                        galeria.tipo = "video";

                    }
                    break;
                default:
                    break;
            }

            galeria.galeria_id = id_galeria;
            var newGaleria = new galeria(galeria);

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.Push("galeria", newGaleria);
            await _Galeria.UpdateOneAsync(filter, update);

        }




        public async Task UpdateGaleria(string id, updateGaleria galeria)
        {
            var filter = Builders<BsonDocument>.Filter.And(
            Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
            Builders<BsonDocument>.Filter.Eq("galeria.galeria_id", ObjectId.Parse(galeria.galeria_id)));
            var updateGaleria = new List<UpdateDefinition<BsonDocument>>();


            if (galeria.Archivo != null) {
                galeriaDelete data = await getUrl(id, galeria.galeria_id);

                if (_subirFile.GaleriaDelete(data.tipo, id, data.usuario_id, data.contenido))
                {
                    UploadFile FileImg = await _subirFile.galeriaAdd(data.tipo, id, data.usuario_id, galeria.galeria_id, galeria.Archivo);
                    if (FileImg.status)
                    {
                        updateGaleria.Add(Builders<BsonDocument>.Update.Set("galeria.$.contenido", FileImg.urlFile));
                    }
                }
            }    

            if (galeria.descripcion != null && galeria.descripcion != "") updateGaleria.Add(Builders<BsonDocument>.Update.Set("galeria.$.descripcion", galeria.descripcion));
            if (galeria.fecha_subida != null && galeria.fecha_subida != "") updateGaleria.Add(Builders<BsonDocument>.Update.Set("galeria.$.fecha_subida", galeria.fecha_subida));
            
            var update = Builders<BsonDocument>.Update.Combine(updateGaleria);
            await _Galeria.UpdateOneAsync(filter, update);
        }

        public async Task deleteGaleria(string id, string id_galeria)
        {
            galeriaDelete data = await getUrl(id, id_galeria);

            if (_subirFile.GaleriaDelete(data.tipo, id, data.usuario_id, data.contenido)){
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<BsonDocument>.Update.PullFilter("galeria", Builders<BsonDocument>.Filter.Eq("galeria_id", ObjectId.Parse(id_galeria)));
                var result = await _Galeria.UpdateOneAsync(filter, update);
            }

        }

        public async Task InsertLike(string id_galeria, string id_usuario)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("galeria.galeria_id", ObjectId.Parse(id_galeria));
            var update = Builders<BsonDocument>.Update.Push("galeria.$.likes", new ObjectId(id_usuario));
            await _Galeria.UpdateOneAsync(filter, update);
        }

        public async Task deleteLike(string id_galeria, string id_usuario)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("galeria.galeria_id", ObjectId.Parse(id_galeria));
            var update = Builders<BsonDocument>.Update.Pull("galeria.$.likes", ObjectId.Parse(id_usuario));
            await _Galeria.UpdateOneAsync(filter, update);
        }

        public async Task AprobarGaleria(string id, string id_galeria)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<BsonDocument>.Filter.Eq("galeria.galeria_id", ObjectId.Parse(id_galeria)));
            var update = Builders<BsonDocument>.Update.Set("galeria.$.aceptado", true);
            await _Galeria.UpdateOneAsync(filter, update);
        }

    }
}