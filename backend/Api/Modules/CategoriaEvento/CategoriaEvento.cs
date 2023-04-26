using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Modules.CategoriaEvento
{
    public class CategoriaEvento
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required(ErrorMessage = "El tipo es requerido")]
        public string? tipo { get; set; }
        [Required(ErrorMessage = "El icon es requerido")]
        public string? icon { get; set; }
    }
}

