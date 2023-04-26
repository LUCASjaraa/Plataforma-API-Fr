using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Api.Modules.Relatos
{
    public class Relato
    {
        public List<relato> relatos { get; set; }
    }
    public partial class relato
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? relato_id { get; set; }
        public string? titulo { get; set; }
        public string? contenido { get; set; }
       // [JsonIgnore]

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string>? likes { get; set; }
        public string? fecha_subida { get; set; }
        public bool aceptado { get; set; }
    }


    public class relatoDTO : relato
    {
        public IFormFile Archivo { get; set; }
    }

    public class relatoDelete
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        public string? contenido { get; set; }
    }

}