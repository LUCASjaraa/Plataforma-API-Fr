using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Modules.Eventos;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api.Modules.InfoModuloEducativo
{
    public class InfoModuloEducativoService
    {
        private IMongoCollection<InfoModuloEducativo> InfoMe;

        public InfoModuloEducativoService(IInfoModuloEducativoSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            InfoMe = database.GetCollection<InfoModuloEducativo>(settings.Collection);
        }
        public async Task<List<InfoModuloEducativo>> Get()
        {
            return await InfoMe.FindAsync(d => true).Result.ToListAsync();
        }



    }

}



