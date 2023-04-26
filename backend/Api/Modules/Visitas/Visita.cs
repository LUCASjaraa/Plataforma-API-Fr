using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Modules.Visitas
{
    public class Visita
    {
        public List<visita>? visitas { get; set; }
    }
    public partial class visita
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        public string? fecha_visita { get; set; }
    }

}