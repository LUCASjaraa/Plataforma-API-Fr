using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Modules.Comentario;
using Api.Modules.PortalPage;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Modules.DatoInteres
{
    public class DatosInteres
    {
        public List<datosInteres>? datos_interes { get; set; }

    }

    public partial class datosInteres
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? interes_id { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }

        public datosInteres() { }

        public datosInteres(adddatosInteres datointeres)
        {
            interes_id = ObjectId.GenerateNewId().ToString();
            titulo = datointeres.titulo;
            descripcion = datointeres.descripcion;
        }
    }

    public partial class adddatosInteres
    {
        [Required(ErrorMessage = "El titulo es requerido")]
        public string? titulo { get; set; }

        [Required(ErrorMessage = "La descripcion es requerido")]
        public string? descripcion { get; set; }
    }

    public partial class updatedatosInteres
    {
        [Required(ErrorMessage = "El interes_id es requerido")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? interes_id { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
    }



}