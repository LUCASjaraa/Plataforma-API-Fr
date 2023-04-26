using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Modules.CategoriaTrivia
{
    public class CategoriaTrivia
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? tipo { get; set; }

    }
}

