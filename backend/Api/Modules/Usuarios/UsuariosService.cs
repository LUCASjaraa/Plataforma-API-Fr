using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace Api.Modules.Usuaios
{
    public class UsuariosService
    {
        private IMongoCollection<Usuarios> _Usuarios;
        public UsuariosService(IUsuariosSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Usuarios = database.GetCollection<Usuarios>(settings.Collection);
        }
        public async Task<List<Usuarios>> GetAll()
        {
            return await _Usuarios.FindAsync(d => true).Result.ToListAsync();
        }
        //si el usuario exite retorna False - si no existe retorna True
        public async Task<bool> GetUser(string user)
        {
           List<Usuarios> usuario = await _Usuarios.FindAsync(u => u.usuario == user).Result.ToListAsync();
            if (usuario == null)
            {
                return true;
            }

            return usuario.Count == 0;

        }

        public async Task<Usuarios> Get(string id)
        {
            return await _Usuarios.FindAsync(d => d.Id == id).Result.FirstAsync();
        }

        public async Task Create(Usuarios usuarios)
        {
            Usuarios usuario = new Usuarios(usuarios);
            await _Usuarios.InsertOneAsync(usuario);
            
        }

        public async Task Update(string id, Usuarios usuarios)
        {
            await _Usuarios.ReplaceOneAsync(usuarios => usuarios.Id == id, usuarios);
        }

        public async Task Delete(string id)
        {
            await _Usuarios.DeleteOneAsync(d => d.Id == id);
        }
    }
}   

   