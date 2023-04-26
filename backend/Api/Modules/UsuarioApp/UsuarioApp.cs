using System;
using MongoDB.Bson.Serialization.Attributes;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Api.Modules.UsuarioApp
{
    public class UsuarioApp
    {    
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public Int32  edad { get; set; }
        public string? fecha_nacimiento { get; set; }
        public string? rol { get; set; }
        public string? correo { get; set; }
        public string? password { get; set; }
        public string? ciudad { get; set; }
        public string? region { get; set; }
        public string? img_perfil { get; set; }
    }

}

  