using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Api.Modules.UsuarioApp
{
    public class UsuarioAppService 
    {
        private IMongoCollection<UsuarioApp> _UsuarioApp;
        public UsuarioAppService(IUsuarioAppSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _UsuarioApp = database.GetCollection<UsuarioApp>(settings.Collection);
        }
        public async Task<List<UsuarioApp>> Get()
        {
            return await _UsuarioApp.FindAsync(d => true).Result.ToListAsync();
        }
        public async Task<UsuarioApp> Get(string id)
        {
            return await _UsuarioApp.FindAsync(d => d.Id == id).Result.FirstAsync();
        }

        public async Task Create(UsuarioApp usuarioApp)
        {
            await _UsuarioApp.InsertOneAsync(usuarioApp);
        }

        public async Task Update(UsuarioApp usuarioApp)
        {
            var filter = Builders<UsuarioApp>.Filter.Eq(s => s.Id, usuarioApp.Id);
            await _UsuarioApp.ReplaceOneAsync(filter, usuarioApp);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<UsuarioApp>.Filter.Eq(s => s.Id, new string(id));
            await _UsuarioApp.DeleteOneAsync(filter);
        }


    }

}

