using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Api.Modules.Galeria;
using Api.Modules.Comentario;
using Api.Modules.Relatos;
using Api.Modules.Valoraciones;
using Api.Modules.Slides;
using Api.Modules.Visitas;
using MongoDB.Bson;
using System.Collections;

namespace Api.Modules.PortalPage
{
    /*
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
     
     
     */
    public class PortalPage
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
    public Eventos.Eventos.Pos_evento? pos_evento     { get; set; }
    public Eventos.Eventos.Camera_pose? camera_pose   { get; set; }
    public List<string>? audio_camara { get; set; }
    public string? img_evento         { get; set; }
    public List<string>? img_camara   { get; set; }
    public Eventos.Eventos.Img_aerea? img_aerea       { get; set; }
        
    }

    public class PuntoIndasboard
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? titulo { get; set; }
        public List<DatoInteres.datosInteres>? datos_interes { get; set; }

        public List<galeria>? galeria { get; set; }
        public List<comentario>? comentarios { get; set; }
        public List<relato>? relatos { get; set; }
        public List<valoracion>? valoraciones { get; set; }
        public List<slides>? slides { get; set; }
        public List<visita>? visitas { get; set; }
    }

    public class relatosComentarios
    {
        public string? titulo { get; set; }
        public List<relato>? relatos { get; set; }
        public List<comentario>? comentarios { get; set; }
        public List<valoracion>? valoraciones { get; set; }
        public List<visita>? visitas { get; set; }


    }

    public class esTPuntoIndasboard
    {
        public string? titulo { get; set; }
        public int cDatosInteres { get; set; }
        public int cGaleria { get; set; }
        public int cComentarios { get; set; }
        public int cRelatos { get; set; }
        public int cValoraciones { get; set; }
        public int cVisitas { get; set; }
    }


    public class allvisitas
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public List<visita>? visitas { get; set; }
    }

    public class mapVisitas
    {
        public int data { get; set; }
    }

    public class sumGaleria
    {
        public List<Likes>? galeria { get; set; }
    }

    public partial class Likes
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string>? likes { get; set; }
    }

    public class sumLikes
    {
        public int data { get; set; }
    }

    public class sumPinteres
    {
        public int data { get; set; }
    }

    public class dataRandC
    {

        public string? titulo { get; set; }
        public int relatos { get; set; }
        public int comentarios { get; set; }
        public int visitas { get; set; }
        public int cant_valoraciones { get; set; }
        public long prom_val_interes { get; set; }
        public long prom_val_inmersion { get; set; }

    }



    public class topdata
    {
        public string? titulo { get; set; }
        public List<valoracion>? valoraciones { get; set; }
        public List<visita>? visitas { get; set; }
    }

    public class top
    {
       public List<topd>? visitas { get; set; }
       public List<topd>? val_inmersion { get; set; }
       public List<topd>? val_interes { get; set; }
    }

    public partial class topd
    {
        public string? nombre_pi { get; set; }
        public double valor { get; set; }
    }



    public class datInteres
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string escenario_id { get; set; }
        public List<DatoInteres.datosInteres> datos_interes { get; set; }

    }

    public class datInteress
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string titulo { get; set; }
        public List<DatoInteres.datosInteres> datos_interes { get; set; }

    }

}
