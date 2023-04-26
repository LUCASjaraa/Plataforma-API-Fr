using System;
using System.Collections.Generic;

using MongoDB.Driver;
using System.Threading.Tasks;

namespace Api.Modules.ModuloEductativo
{
    public class ModuloEducativoService
    {
        private IMongoCollection<ModuloEducativo> _ModuloEducativo;
        public ModuloEducativoService(IModuloEducativoSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _ModuloEducativo = database.GetCollection<ModuloEducativo>(settings.Collection);
        }


        public async Task<List<ModuloEducativo>> Get()
        {
            return await _ModuloEducativo.FindAsync(d => true).Result.ToListAsync();
        }
        public async Task<ModuloEducativo> Get(string id)
        {
            return await _ModuloEducativo.FindAsync(d => d.Id == id).Result.FirstAsync();
        }

        public async Task Create(ModuloEducativo moduloEducativo)
        {
            await _ModuloEducativo.InsertOneAsync(moduloEducativo);
        }

        public async Task Update(ModuloEducativo moduloEducativo)
        {
            var filter = Builders<ModuloEducativo>.Filter.Eq(s => s.Id, moduloEducativo.Id);
            await _ModuloEducativo.ReplaceOneAsync(filter, moduloEducativo);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<ModuloEducativo>.Filter.Eq(s => s.Id, new string(id));
            await _ModuloEducativo.DeleteOneAsync(filter);
        }

    }
}

