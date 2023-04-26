using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Api.Modules.Eventos;
using Api.Modules.CategoriaEvento;
using Api.Modules.PortalPage;
using System.Linq;

namespace Api.Modules.AppPage
{
    public class AppPageService 
    {
        private readonly IMongoCollection<BsonDocument> _AppPage;
        private readonly IMongoCollection<CategoriaEvento.CategoriaEvento> _Categorias;
       

        public AppPageService(IEventosSettings settings, ICategoriaEventoSettings settingsCategoria)
        {

            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _AppPage = database.GetCollection<BsonDocument>(settings.Collection);
            
            var clienteCat = new MongoClient(settingsCategoria.Server);
            var databaseCat = clienteCat.GetDatabase(settingsCategoria.Database);
            _Categorias = databaseCat.GetCollection<CategoriaEvento.CategoriaEvento>(settingsCategoria.Collection);
        }


        public async Task<List<MapPins>> getMapGist()
        {
            var projection = Builders<BsonDocument>.Projection
               .Include("escenario_id")
               .Include("categoria")
               .Include("titulo")
               .Include("descripcion")
               .Include("zona")
               .Include("fecha")
               .Include("pos_evento");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(new BsonDocument(), options).Result.ToListAsync();

            var resultDataSerializer = BsonSerializer.Deserialize<List<MapPins>>(result.ToJson());

            foreach (var item in resultDataSerializer)
            {
                var data = await Getbyid(item.categoria);
                item.icon = data.icon;
                item.nombre = data.tipo;

            }
            
            return resultDataSerializer;


        }
        public async Task<CategoriaEvento.CategoriaEvento> Teest()
        {
            string id = "63509b59ef99b15dfed3fc7f";
            var result = await Getbyid(id);
            return result;
            // var json = JsonConvert.SerializeObject(BsonSerializer.Deserialize<List<Comentario>>(result));
            // return JsonConvert.DeserializeObject<List<Comentario>>(json);
        }


        public async Task<CategoriaEvento.CategoriaEvento> Getbyid(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await _Categorias.FindAsync(d => d.Id == id).Result.FirstAsync();
            return result;
        }





        public async Task<List<slidePage>> getMemoriaPage(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<BsonDocument>
                .Projection
                .Include("escenario_id")
                .Include("categoria")
                .Include("titulo")
                .Include("descripcion")
                .Include("zona")
                .Include("fecha")
                .Include("slider")
                .Include("memoria");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();
            return BsonSerializer.Deserialize<List<slidePage>>(result.ToJson());
        }


        public async Task<List<CamaraPage>> getCamaraPage(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<BsonDocument>
                .Projection
                .Include("escenario_id")
                .Include("camera_pose")
                .Include("pos_camara")
                .Include("pos_evento")
                .Include("relatos")
                .Include("audio")
                .Include("visitas");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();
            return BsonSerializer.Deserialize<List<CamaraPage>>(result.ToJson());

        }


        public async Task<List<GaleriaPage>> getGaleriaPage(string id)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<BsonDocument>
                .Projection
                .Include("escenario_id")
                .Include("categoria")
                .Include("titulo")
                .Include("fecha")
                .Include("galeria");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();

            return BsonSerializer.Deserialize<List<GaleriaPage>>(result.ToJson());
        }

        public async Task<List<RelatosPage>> getRelatosPage(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<BsonDocument>
                .Projection
                .Include("escenario_id")
                .Include("categoria")
                .Include("titulo")
                .Include("fecha")
                .Include("relatos");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();

            return BsonSerializer.Deserialize<List<RelatosPage>>(result.ToJson());
        }

        public async Task<List<ValoracionesPage>> ValoracionesPage(string id)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<BsonDocument>
                .Projection
                .Include("escenario_id")
                .Include("categoria")
                .Include("titulo")
                .Include("fecha")
                .Include("valoraciones");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();
            return BsonSerializer.Deserialize<List<ValoracionesPage>>(result.ToJson());

        }

        public async Task<List<ComentariosPage>> ComentariosPage(string id)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<BsonDocument>
                .Projection
                .Include("escenario_id")
                .Include("categoria")
                .Include("titulo")
                .Include("fecha")
                .Include("comentarios");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();
            
            return BsonSerializer.Deserialize<List<ComentariosPage>>(result.ToJson());

        }


        public async Task<List<EventosPage>> GeneralEvento(string id)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<BsonDocument>
                .Projection
                .Include("escenario_id")
                .Include("categoria")
                .Include("titulo")
                .Include("fecha")
                .Include("zona");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();
            return BsonSerializer.Deserialize<List<EventosPage>>(result.ToJson());

        }
        public async Task<top> listop(int t)
        {
            var projection = Builders<BsonDocument>.Projection
                            .Include("valoraciones")
                            .Include("visitas")
                            .Include("categoria")
                            .Include("titulo").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _AppPage.FindAsync(filter, options).Result.ToListAsync();


            var res = BsonSerializer.Deserialize<List<topdata>>(result.ToJson());


            List<topd> topvisitas = new List<topd>();
            List<topd> totalinmersions = new List<topd>();
            List<topd> totalvalinteres = new List<topd>();



            foreach (var item in res)
            {
                double sunmaVal_inmersion = 0;
                double sumaVal_interes = 0;
                double promedioVal_inmersion = 0;
                double promedioVal_interes = 0;
                foreach (var val in item.valoraciones)
                {
                    sunmaVal_inmersion = sunmaVal_inmersion + val.val_inmersion;
                    sumaVal_interes = sumaVal_interes + val.val_interes;
                }


                if (item.valoraciones.Count != 0)
                {
                    promedioVal_inmersion = sunmaVal_inmersion / item.valoraciones.Count;
                    promedioVal_interes = sumaVal_interes / item.valoraciones.Count;
                }
                else
                {
                    promedioVal_inmersion = 0;
                    promedioVal_interes = 0;
                }






                var data = await Getbyid(item.categoria);
                topd topvalinmersion = new topd()
                {
                    nombre = data.tipo,
                    icon= data.icon,
                    nombre_pi = item.titulo,
                    valor = promedioVal_inmersion

                };
                totalinmersions.Add(topvalinmersion);

                topd toptvalinteres = new topd()
                {
                    nombre = data.tipo,
                    icon = data.icon,
                    nombre_pi = item.titulo,
                    valor = promedioVal_interes
                };
                totalvalinteres.Add(toptvalinteres);

                topd visita = new topd()
                {
                    nombre = data.tipo,
                    icon = data.icon,
                    nombre_pi = item.titulo,
                    valor = item.visitas.Count
                };
                topvisitas.Add(visita);
            }

            top top = new top()
            {

                visitas = topvisitas.OrderByDescending(x => x.valor).Take(t).ToList(),
                val_inmersion = totalinmersions.OrderByDescending(x => x.valor).Take(t).ToList(),
                val_interes = totalvalinteres.OrderByDescending(x => x.valor).Take(t).ToList(),

            };
            return top;
        }





    }
}