using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Api.Modules.CategoriaEvento
{
    public class CategoriaEventoService
    {
        private IMongoCollection<CategoriaEvento> _CategoriaEventos;

        public CategoriaEventoService(ICategoriaEventoSettings settings) 
        { 

            
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _CategoriaEventos = database.GetCollection<CategoriaEvento>(settings.Collection);
        }

        public async Task<List<CategoriaEvento>> Get()
        {
            return await _CategoriaEventos.FindAsync(d => true).Result.ToListAsync();
        }

        public async Task<CategoriaEvento> Getbyid(string id)
        {
            return await _CategoriaEventos.FindAsync(d => d.Id == id).Result.FirstAsync();
        }

        public async Task Create(CategoriaEvento categoriaEvento)
        {
            await _CategoriaEventos.InsertOneAsync(categoriaEvento);
        }

        public async Task Update(CategoriaEvento categoriaEvento)
        {
            var filter = Builders<CategoriaEvento>.Filter.Eq(s => s.Id, categoriaEvento.Id);
            await _CategoriaEventos.ReplaceOneAsync(filter, categoriaEvento);
        }


        public async Task Delete(string id)
        {
            var filter = Builders<CategoriaEvento>.Filter.Eq(s => s.Id, new string(id));
            await _CategoriaEventos.DeleteOneAsync(filter);
        }
    }
}

