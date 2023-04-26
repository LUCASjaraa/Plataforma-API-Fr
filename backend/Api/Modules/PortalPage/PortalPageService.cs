
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.Eventos;
using System.Linq;
using Api.Modules.CategoriaEvento;
using System.Collections;
using Api.Modules.Escenario;
using System;

namespace Api.Modules.PortalPage
{
    public class PortalPageService
    {


        /*
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
         
         
         */


        private IMongoCollection<BsonDocument> _portalPage;

        private readonly IMongoCollection<Escenario.Escenario> _Escenario;

        private readonly IMongoCollection<CategoriaEvento.CategoriaEvento> _Categorias;



        public PortalPageService(IEventosSettings settings, IEscenarioSettings settingsEscenario, ICategoriaEventoSettings settingsCategoria)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _portalPage = database.GetCollection<BsonDocument>(settings.Collection);

            var clienteEsc = new MongoClient(settingsEscenario.Server);
            var databaseEsc = clienteEsc.GetDatabase(settingsEscenario.Database);
            _Escenario = databaseEsc.GetCollection<Escenario.Escenario>(settingsEscenario.Collection);

            var clienteCat = new MongoClient(settingsCategoria.Server);
            var databaseCat = clienteCat.GetDatabase(settingsCategoria.Database);
            _Categorias = databaseCat.GetCollection<CategoriaEvento.CategoriaEvento>(settingsCategoria.Collection);


        }



        public async Task<List<PortalPage>> GetAllPuntoInteres(string id)
        {
            var projection = Builders<BsonDocument>.Projection.
                 Exclude("datos_interes")
                .Exclude("galeria")
                .Exclude("comentarios")
                .Exclude("relatos")
                .Exclude("valoraciones")
                .Exclude("slides")
                .Exclude("visitas");

            var filter = Builders<BsonDocument>.Filter.Eq("escenario_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();

            return BsonSerializer.Deserialize<List<PortalPage>>(result.ToJson());
        }



        public async Task<mapVisitas> GetVisitas(string id)
        {

            var projection = Builders<BsonDocument>.Projection.Include("visitas");
            var filter = Builders<BsonDocument>.Filter.Eq("escenario_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();
            var res = BsonSerializer.Deserialize<List<allvisitas>>(result.ToJson());

            int cVisitas = 0;
            foreach (var item in res)
            {
                cVisitas = cVisitas + item.visitas.Count;
            }

            var json = new mapVisitas
            {
                data = cVisitas
            };
            return json;
        }


        public async Task<sumLikes> getTest(string id)
        {

            var projection = Builders<BsonDocument>.Projection.Include("galeria.likes").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Eq("escenario_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();
            var res = BsonSerializer.Deserialize<List<sumGaleria>>(result.ToJson());

            int cLike = 0;
            foreach (var item in res)
            {
                foreach (var items in item.galeria)
                {
                    cLike = cLike + items.likes.Count;
                }
            }

            var json = new sumLikes
            {
                data = cLike
            };
            return json;


        }
        //metodo por de cantidad de puntos de interes por escenario
        public async Task<sumPinteres> getPinteres(string id)
        {
            int cPinteres = 0;

            var projection = Builders<BsonDocument>.Projection.Include("visitas");
            var filter = Builders<BsonDocument>.Filter.Eq("escenario_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();
            var res = BsonSerializer.Deserialize<List<allvisitas>>(result.ToJson());
            cPinteres = res.Count;
            var json = new sumPinteres { data = cPinteres };
            return json;

        }

        public async Task<sumPinteres> getPinteresCategoria(string id)
        {
            int cPinteres = 0;

            var projection = Builders<BsonDocument>.Projection.Include("visitas");
            var filter = Builders<BsonDocument>.Filter.Eq("categoria", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();
            var res = BsonSerializer.Deserialize<List<allvisitas>>(result.ToJson());
            cPinteres = res.Count;
            var json = new sumPinteres { data = cPinteres };
            return json;

        }


        public async Task<esTPuntoIndasboard> getPuntoIndasboard(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("titulo")
                             .Include("datos_interes").Include("galeria")
                             .Include("comentarios").Include("relatos")
                             .Include("valoraciones").Include("memoria")
                             .Include("visitas");


            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _portalPage.FindAsync(filter, options).Result.FirstAsync();
            var res = BsonSerializer.Deserialize<PuntoIndasboard>(result.ToJson());

            
            var  json = new esTPuntoIndasboard
            {
                titulo = res.titulo,
                cDatosInteres = res.datos_interes.Count,
                cGaleria = res.galeria.Count,
                cComentarios = res.comentarios.Count,
                cRelatos = res.relatos.Count,
                cValoraciones = res.valoraciones.Count,
                cVisitas = res.visitas.Count

            };
           

            return json;
        }



        public async Task<List<dataRandC>> relatoscomentarios(string id, string type)
        {
            var filterId = "";
            FilterDefinition<BsonDocument> filter;
            var projection = Builders<BsonDocument>.Projection
                            .Include("comentarios").Include("relatos")
                            .Include("valoraciones").Include("visitas")
                            .Include("titulo").Exclude("_id");

            if (type == "puntodeinteres") { filterId = "_id"; }
            else if (type == "escenario") { filterId = "escenario_id"; }
            if (type == "all") filter = Builders<BsonDocument>.Filter.Empty;
            else { filter = Builders<BsonDocument>.Filter.Eq(filterId, ObjectId.Parse(id)); }



            var options = new FindOptions<BsonDocument> { Projection = projection };

            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();


            var res = BsonSerializer.Deserialize<List<relatosComentarios>>(result.ToJson());
            List<dataRandC> josn = new List<dataRandC>();
            foreach (var item in res)
            {

                long sunmaVal_inmersion = 0;
                long sumaVal_interes = 0;
                long promedioVal_inmersion = 0;
                long promedioVal_interes = 0;

                foreach (var val in item.valoraciones)
                {
                    sunmaVal_inmersion = sunmaVal_inmersion + val.val_inmersion;
                    sumaVal_interes = sumaVal_interes + val.val_interes;
                }
                if (item.valoraciones.Count == 0 && item.valoraciones.Count == 0)
                {
                     promedioVal_inmersion = 0;
                     promedioVal_interes = 0;
                }
                else
                {
                     promedioVal_inmersion = sunmaVal_inmersion / item.valoraciones.Count;
                     promedioVal_interes = sumaVal_interes / item.valoraciones.Count;
                }




                dataRandC resJson = new dataRandC
                {
                    titulo = item.titulo,
                    visitas = item.visitas.Count,
                    relatos = item.relatos.Count,
                    comentarios = item.comentarios.Count,
                    cant_valoraciones = item.valoraciones.Count,
                    prom_val_interes = promedioVal_interes,
                    prom_val_inmersion = promedioVal_inmersion
                };
                josn.Add(resJson);
            }
            return josn;

        }

        public async Task<top> listop( int t)
        {
            var projection = Builders<BsonDocument>.Projection
                            .Include("valoraciones").Include("visitas")
                            .Include("titulo").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();


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


                topd topvalinmersion = new topd()
                {
                    nombre_pi = item.titulo,
                    valor = promedioVal_inmersion

                };
                totalinmersions.Add(topvalinmersion);

                topd toptvalinteres = new topd()
                {
                    nombre_pi = item.titulo,
                    valor = promedioVal_interes
                };
                totalvalinteres.Add(toptvalinteres);

                topd visita = new topd()
                {
                    nombre_pi = item.titulo,
                    valor = item.visitas.Count
                };
                topvisitas.Add(visita);
            }

            top top = new top()
            {
                visitas       = topvisitas.OrderByDescending(x => x.valor).Take(t).ToList(),
                val_inmersion = totalinmersions.OrderByDescending(x => x.valor).Take(t).ToList(),
                val_interes   = totalvalinteres.OrderByDescending(x => x.valor).Take(t).ToList(),

            };
            return top;
        }

        public async Task<List<datInteres>> datosInteresbyEscenario(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("datos_interes").Include("escenario_id").Exclude("_id");
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var filter = Builders<BsonDocument>.Filter.Eq("escenario_id", ObjectId.Parse(id));
            var result = await _portalPage.FindAsync(filter, options).Result.ToListAsync();
            var data = BsonSerializer.Deserialize<List<datInteres>>(result.ToJson());
            return data;
        }



        public async Task<List<datInteress>> datosInteresAll()
        {
            var Escenarios = await _Escenario.FindAsync(d => true).Result.ToListAsync();

            var all = await datosInteresbyEscenario(Escenarios[0].Id);

            var a = new List<datInteress>();
            foreach (var item in Escenarios)
            {
                var d = new datInteress();

                var data = await datosInteresbyEscenario(item.Id);
                d.titulo = item.titulo;
                var c = new List<DatoInteres.datosInteres>();
                foreach (var items in data)
                {
                    foreach (var dataI in items.datos_interes)
                    {
                        c.Add(dataI);
                    }
                }
                d.datos_interes = c;
                a.Add(d);
            }



            return a;
        }








        /*        
        public List<Visita> GetAllVisita(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("visitas");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = _Visita
                .Find(filter)
                 .Project(projection)
                .ToList()
                .ToJson();
            var json = JsonConvert.SerializeObject(BsonSerializer.Deserialize<List<Visita>>(result));
            return JsonConvert.DeserializeObject<List<Visita>>(json);
        }*/
    }
}
