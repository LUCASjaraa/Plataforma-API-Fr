using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.SubirArchivo;
using MongoDB.Bson;
using Api.Modules.Galeria;

namespace Api.Modules.Escenario
{
    public class EscenarioService
    {
        private IMongoCollection<Escenario> _Escenario;
        private UploadFileService _subirFile;


        public EscenarioService(IEscenarioSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Escenario = database.GetCollection<Escenario>(settings.Collection);
            _subirFile = new UploadFileService();

        }
        public async Task<List<Escenario>> Get()
        {
            return await _Escenario.FindAsync(d => true).Result.ToListAsync();
        }
        public async Task <Escenario> GetbyId(string id)
        {
            return await _Escenario.FindAsync(d => d.Id == id).Result.FirstAsync();
        }

        public async Task Create( addEscenario escenario)
        {
            escenario.id = ObjectId.GenerateNewId().ToString();
            _subirFile.CreatedirectorysEs(escenario.id);
            var newEscenario = new Escenario(escenario);
            await _Escenario.InsertOneAsync(newEscenario);
        }


        public async Task Createslides(string id, addSlides slides)
        {
            var file = await _subirFile.addslidesEscenario(id, slides.file);
            if (file.status) {
                var newSlide = new Slides
                {
                    slide_id = ObjectId.GenerateNewId().ToString(),
                    fecha = slides.fecha,
                    titulo = slides.titulo,
                    img_url = file.urlFile
                };
                var filter = Builders<Escenario>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Escenario>.Update.Push("slides", newSlide);
                await _Escenario.UpdateOneAsync(filter, update);
            }
        }

        public async Task deletelides(string id,string slide_id, addSlides slides)
        {
            //falta el deleteFile
            var filter = Builders<Escenario>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Escenario>.Update.PullFilter("slides", Builders<BsonDocument>.Filter.Eq("slide_id", ObjectId.Parse(slide_id)));
            var result = await _Escenario.UpdateOneAsync(filter, update);
        }


        public async Task Update( Escenario escenario)
        {
            var filter = Builders<Escenario>.Filter.Eq(s => s.Id, escenario.Id);
            await _Escenario.ReplaceOneAsync(filter, escenario);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<Escenario>.Filter.Eq(s => s.Id, new string(id));
            await _Escenario.DeleteOneAsync(filter);
        }

    }
}

 