using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Api.Modules.CategoriaTrivia
{
    public class CategoriaTriviaService
    {
        private IMongoCollection<CategoriaTrivia> _CategoriaTrivia;

        public CategoriaTriviaService(ICategoriaTriviaSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _CategoriaTrivia = database.GetCollection<CategoriaTrivia>(settings.Collection);
        }

        public async Task<List<CategoriaTrivia>> Get()
        {
            return await _CategoriaTrivia.FindAsync(d => true).Result.ToListAsync();
        }

        public async Task<CategoriaTrivia> Get(string id)
        {
            return await _CategoriaTrivia.FindAsync(d => d.Id == id).Result.FirstAsync();
        }

        public async Task Create(CategoriaTrivia categoriatrivia)
        {
            await _CategoriaTrivia.InsertOneAsync(categoriatrivia);
        }

        public async Task Update(CategoriaTrivia categoriatrivia)
        {
            var filter = Builders<CategoriaTrivia>.Filter.Eq(s => s.Id, categoriatrivia.Id);
            await _CategoriaTrivia.ReplaceOneAsync(filter, categoriatrivia);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<CategoriaTrivia>.Filter.Eq(s => s.Id, new string(id));
            await _CategoriaTrivia.DeleteOneAsync(filter);
        }

    }
}

