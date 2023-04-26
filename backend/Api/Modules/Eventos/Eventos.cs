using System.Collections.Generic;
using Api.Modules.DatoInteres;
using Api.Modules.Galeria;
using Api.Modules.Comentario;
using MongoDB.Bson.Serialization.Attributes;
using Api.Modules.Relatos;
using Api.Modules.Valoraciones;
using Api.Modules.Slides;
using Api.Modules.Visitas;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using static Api.Modules.Eventos.Eventos;
using System.ComponentModel.DataAnnotations;

namespace Api.Modules.Eventos
{
    public class Eventos
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? descripcion_corta { get; set; }
        public string? descripcion { get; set; }
        public string? titulo { get; set; }
        public string? zona { get; set; }
        public string? fecha              { get; set; }
        public Pos_evento? pos_evento     { get; set; }
        public Camera_pose? camera_pose   { get; set; }
        public List<string>? audio_camara { get; set; }
        public string? img_evento         { get; set; }
        public List<string>? img_camara   { get; set; }
        public Img_aerea? img_aerea       { get; set; }
        public List<datosInteres>? datos_interes { get; private set; }
        public List<galeria>? galeria            { get; private set; }
        public List<comentario>? comentarios     { get; private set; }
        public List<relato>? relatos             { get; private set; }
        public List<valoracion>? valoraciones    { get; private set; }
        public List<slides>? slides              { get;  set; }     
        public List<visita>? visitas             { get; private set; }

        public partial class Pos_evento
        {
            public double lat { get; set; }
            public double lng { get; set; }
            public double alt { get; set; }
        }
        public partial class Camera_pose
        {
            public double head { get; set; }
            public double pitch { get; set; }
            public double roll { get; set; }
        }

        public partial class Img_aerea
        {
            public string? url_antes { get; set; }
            public string? url_despues { get; set; }
            public string? descripcion { get; set; }
        }

        public Eventos() { }

        public Eventos(addEvento evento)
        {



            id = evento.id;
            escenario_id = evento.escenario_id;
            categoria = evento.categoria;
            titulo = evento.titulo;
            descripcion_corta = evento.descripcion_corta;
            descripcion = evento.descripcion;
            zona = evento.zona;
            fecha = evento.fecha;
            img_evento = evento.img_evento;
            pos_evento = evento.pos_evento;
            camera_pose = evento.camera_pose;
            img_aerea = evento.img_aerea;
            audio_camara = evento.audio_camara;
            img_camara = evento.img_camara;
            datos_interes = new List<datosInteres>();
            galeria = new List<galeria>();
            comentarios = new List<comentario>();
            relatos = new List<relato>();
            valoraciones = new List<valoracion>();
            slides = new List<slides>();
            visitas = new List<visita>();
        }



        public class addEvento
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string? id { get; set; }

            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            [Required(ErrorMessage = "El escenario_id es requerido")]
            public string? escenario_id { get; set; }

            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            [Required(ErrorMessage = "La categoria es requerido")]
            public string? categoria { get; set; }

            [Required(ErrorMessage = "El titulo es requerido")]
            public string? titulo { get; set; }

            [Required(ErrorMessage = "La descripcion es requerido")]
            public string? descripcion { get; set; }

            [Required(ErrorMessage = "La descripcion corta es requerido")]
            public string? descripcion_corta { get; set; }


            [Required(ErrorMessage = "La zona es requerido")]
            public string? zona { get; set; }

            [Required(ErrorMessage = "La fecha es requerido")]
            public string? fecha { get; set; }


            /***********/
            public List<string>? audio_camara { get; set; }

            [Required(ErrorMessage = "La oneFileaudio es requerido")]
            public IFormFile? oneFileaudio { get; set; }

            [Required(ErrorMessage = "La twoFileaudio es requerido")]
            public IFormFile? twoFileaudio { get; set; }
            /***********/


            /***********/
            public List<string>? img_camara { get; set; }

            [Required(ErrorMessage = "La oneFileimg es requerido")]
            public IFormFile? oneFileimg { get; set; }

            [Required(ErrorMessage = "La twoFileimg es requerido")]
            public IFormFile? twoFileimg { get; set; }
            /***********/

            /***********/
            public string? img_evento { get; set; }
            [Required(ErrorMessage = "El fileimg_evento es requerido")]
            public IFormFile? fileimg_evento { get; set; }
            /***********/

            /****/
            public Img_aerea? img_aerea { get; set; }


            [Required(ErrorMessage = "La addescripcion descripcion de la imagen aerea es requerido")]
            public string? addescripcion { get; set; }

            [Required(ErrorMessage = "El file_antes de antes es requerido")]
            public IFormFile? file_antes { get; set; }

            [Required(ErrorMessage = "El file_despues es requerido")]
            public IFormFile? file_despues { get; set; }
            /****/





            /****/
            public Pos_evento? pos_evento { get; set; }


            [Required(ErrorMessage = "La latitud es requerido")]
            public string? latitud { get; set; }

            [Required(ErrorMessage = "La longitud es requerido")]
            public string? longitud { get; set; }

            [Required(ErrorMessage = "La altura es requerido")]
            public string? altura { get; set; }
            /****/



            /****/
            public Camera_pose? camera_pose { get; set; }


            [Required(ErrorMessage = "El head es requerido")]
            public string? head { get; set; }

            [Required(ErrorMessage = "El pitch es requerido")]
            public string? pitch { get; set; }

            [Required(ErrorMessage = "El roll es requerido")]
            public string? roll { get; set; }
            /****/
        }


        public class updateEvento
        {
            [Required(ErrorMessage = "El id es requerido")]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? id { get; set; }

            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string? escenario_id { get; set; }

            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string? categoria { get; set; }

            public string? titulo { get; set; }

            public string? descripcion { get; set; }

            public string? descripcion_corta { get; set; }


            public string? zona { get; set; }

            public string? fecha { get; set; }


            /***********/
            public List<string>? audio_camara { get; set; }

            public IFormFile? oneFileaudio { get; set; }

            public IFormFile? twoFileaudio { get; set; }
            /***********/


            /***********/
            public List<string>? img_camara { get; set; }

            public IFormFile? oneFileimg { get; set; }

            public IFormFile? twoFileimg { get; set; }
            /***********/

            /***********/
            public string? img_evento { get; set; }
            public IFormFile? fileimg_evento { get; set; }
            /***********/

            /****/
            public Img_aerea? img_aerea { get; set; }


            public string? addescripcion { get; set; }

            public IFormFile? file_antes { get; set; }

            public IFormFile? file_despues { get; set; }
            /****/





            /****/
            public Pos_evento? pos_evento { get; set; }


            public string? latitud { get; set; }

            public string? longitud { get; set; }

            public string? altura { get; set; }
            /****/



            /****/
            public Camera_pose? camera_pose { get; set; }


            public string? head { get; set; }

            public string? pitch { get; set; }

            public string? roll { get; set; }
            /****/
        }



    }
}

