using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Api.Modules.Slides
{
    public class Slides
    {
        public List<slides>? slides { get; set; }
    }

    public partial class slides
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? slide_id { get; set; }
        public string? titulo { get; set; }
        public List<string>? img { get; set; }
        public List<string>? fechas { get; set; }
        public List<string>? descripciones { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string>? likes { get; set; }
        public string? fecha_subida { get; set; }
        public bool aceptado { get; set; }

        public slides() { }

        public slides(addSlides slides)
        {
            usuario_id = slides.usuario_id;
            slide_id = slides.slide_id;
            titulo = slides.titulo;
            img = slides.img;
            fechas = slides.fechas;
            descripciones =slides.descripciones;
            fecha_subida = slides.fecha_subida;
            likes = new List<string>();
            aceptado = true;
        }

    }


    //0 - antes 1 - durante 2- justo despues  3- ahora

    public partial class addSlides
    {

        [Required(ErrorMessage = "El usuario_id es requerido")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? slide_id { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public string? titulo { get; set; }


        public IFormFile? antesFile        { get; set; }
        public string?    antesfecha       { get; set; }
        public string?    antesdescripcion { get; set; }


        public IFormFile? duranteFile          { get; set; }
        public string?    durantefecha         { get; set; }
        public string?    durantedescripcion   { get; set; }



        public IFormFile? jdespuesFile        { get; set; }
        public string?    jdespuesfecha       { get; set; }
        public string?    jdespuesdescripcion { get; set; }


        public IFormFile? ahoraFile        { get; set; }
        public string?    ahorafecha       { get; set; }
        public string?    ahoradescripcion { get; set; }

        public List<string>? img { get; set; }
        public List<string>? fechas { get; set; }
        public List<string>? descripciones { get; set; }

        [Required(ErrorMessage = "la fecha_subida es requerida")]
        public string? fecha_subida { get; set; }

    }

    public partial class updateSlides
    {

        [Required(ErrorMessage = "El slide_id es requerido")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? slide_id { get; set; }

        public string? titulo { get; set; }


        public IFormFile? antesFile { get; set; }
        public string? antesfecha { get; set; }
        public string? antesdescripcion { get; set; }


        public IFormFile? duranteFile { get; set; }
        public string? durantefecha { get; set; }
        public string? durantedescripcion { get; set; }



        public IFormFile? jdespuesFile { get; set; }
        public string? jdespuesfecha { get; set; }
        public string? jdespuesdescripcion { get; set; }


        public IFormFile? ahoraFile { get; set; }
        public string? ahorafecha { get; set; }
        public string? ahoradescripcion { get; set; }

        public List<string>? img { get; set; }
        public List<string>? fechas { get; set; }
        public List<string>? descripciones { get; set; }


        public string? fecha_subida { get; set; }

    }




}