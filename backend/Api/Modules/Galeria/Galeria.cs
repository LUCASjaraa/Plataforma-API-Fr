using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Modules.Galeria
{
    public class Galeria
    {
        public List<galeria> galeria { get; set; }
    }
    public partial class galeria
    {
        [Required(ErrorMessage = "El usuario_id es requerido")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? galeria_id { get; set; }
        public string? tipo { get; set; }
        public string? contenido { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string>? likes { get; private set; }

        [Required(ErrorMessage = "La descripcion es requerido")]
        public string? descripcion { get; set; }

        [Required(ErrorMessage = "La fecha_subida es requerido")]
        public string? fecha_subida { get; set; }

        public bool? aceptado { get; private set; }

        public galeria() { }

        public galeria(addGaleria galeria)
        {

            usuario_id = galeria.usuario_id;
            galeria_id = galeria.galeria_id;
            tipo = galeria.tipo;
            contenido = galeria.contenido;
            likes = new List<string>();
            descripcion = galeria.descripcion;
            fecha_subida = galeria.fecha_subida;
            aceptado = true;
        }
    }




    public class addGaleria : galeria
    {
        [Required(ErrorMessage = "La Archivo file es requerido")]

        public IFormFile? Archivo { get; set; }
    }


    public class updateGaleria
    {
        [Required(ErrorMessage = "La galeria_id es requerido")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? galeria_id { get; set; }

        public IFormFile? Archivo { get; set; }
        public string? descripcion { get; set; }
        public string? fecha_subida { get; set; }
    }

    public class galeriaDelete
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        public string? contenido { get; set; }
        public string? tipo { get; set; }
    }

}

   