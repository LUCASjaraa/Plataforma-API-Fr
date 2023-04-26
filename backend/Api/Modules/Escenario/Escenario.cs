using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Api.Modules.Escenario
{
    public class Escenario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? titulo { get; set; }
        public string? short_descrip { get; set; }
        public string? long_descrip { get; set; }

        public List<string>? ciudades { get; set; }
        public List<Slides>? slides { get; set; }
        public List<Lat_long>? lat_lng { get; set; }

        public Escenario() { }
        public Escenario(addEscenario escenario)
        {
            Id     = escenario.id;
            titulo = escenario.titulo;
            short_descrip = escenario.short_descrip;
            long_descrip = escenario.long_descrip;
            ciudades = escenario.ciudades;
            lat_lng = escenario.lat_lng;
            slides = new List<Slides>();

        }
    }

    public class addEscenario
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        //[Required(ErrorMessage = "El titulo es requerido")]
        public string? titulo { get; set; }

        //[Required(ErrorMessage = "short_descrip es requerido")]
        public string? short_descrip { get; set; }

        //[Required(ErrorMessage = "long_descrip es requerido")]
        public string? long_descrip { get; set; }

        //[Required(ErrorMessage = "ciudades es requerido")]
        public List<string>? ciudades { get; set; }

      //  [Required(ErrorMessage = "lat_lng son requeridas")]
        public List<Lat_long> lat_lng { get; set; }
    }


    public partial class addSlides
    {
        public string? titulo { get; set; }
        public IFormFile? file { get; set; }
        public string? fecha { get; set; }
    }

    public partial class Slides
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? slide_id { get; set; }
        public string? titulo { get; set; }
        public string? img_url { get; set; }
        public string? fecha { get; set; }
    }
    public partial class Lat_long
    {
        public double? lat { get; set; }
        public double? lng { get; set; }
    }


}

