using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Modules.Comentario
{
    public class Comentario
    {
        public List<comentario>? comentarios { get; set; }
    }

    public class comentario

    {
        [BsonRepresentation(BsonType.ObjectId)]
        [Required(ErrorMessage = "El usuario_id es requerido")]
        public string? usuario_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string? comentario_id { get; private set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public string? titulo { get; set; }
        [Required(ErrorMessage = "El contenido es requerido")]
        public string? contenido { get; set; }
        [Required(ErrorMessage = "La fecha_subida es requerida")]
        public string? fecha_subida { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? likes { get; private set; }
        public bool? aceptado { get; private set; }

        public comentario(){}

        public comentario(addComentario comentario)
        {
            usuario_id = comentario.usuario_id;   
            titulo = comentario.titulo;
            contenido = comentario.contenido;
            fecha_subida = comentario.fecha_subida;
            comentario_id = ObjectId.GenerateNewId().ToString();
            likes = new List<string>();
            aceptado = true;
            
        }
    }

    public class addComentario {
        [Required(ErrorMessage = "El usuario_id es requerido")]
        public string? usuario_id { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public string? titulo { get; set; }
        [Required(ErrorMessage = "El contenido es requerido")]
        public string? contenido { get; set; }
        [Required(ErrorMessage = "La fecha_subida es requerida")]
        public string? fecha_subida { get; set; }

    }


    public class updatecomentario
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [Required(ErrorMessage = "El comentario_id es requerido")]
        public string? comentario_id { get; set; }
        public string? titulo { get; set; }
        public string? contenido { get; set; }
        public string? fecha_subida { get; set; }

    }

}
