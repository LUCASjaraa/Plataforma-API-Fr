using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Api.Modules.Galeria;
using Api.Modules.Comentario;
using Api.Modules.Relatos;
using Api.Modules.Valoraciones;
using Api.Modules.Slides;
using Api.Modules.Visitas;
using Api.Modules.CategoriaEvento;
namespace Api.Modules.AppPage
{
    public class MapPins
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
        public string? zona { get; set; }
        public string? fecha { get; set; }
        public string? nombre { get; set; }
        public string? icon { get; set; }
        public Eventos.Eventos.Pos_evento? pos_evento { get; set; }
        
    }

    public class slidePage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
        public string? zona { get; set; }
        public string? fecha { get; set; }
        public List<slides>? slides { get; set; }
    }

    public class CamaraPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        public Eventos.Eventos.Camera_pose? camera_pose { get; set; }
        public Eventos.Eventos.Pos_evento? pos_evento { get; set; }
        public List<relato>? relatos { get; set; }
        public string? audio { get; set; }
        public List<visita>? visitas { get; set; }
    }

    public class GaleriaPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? titulo { get; set; }
        public string? fecha { get; set; }
        public List<galeria>? galeria { get; set; }



    }

    public class RelatosPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? titulo { get; set; }
        public string? fecha { get; set; }
        public List<relato>? relatos { get; set; }

    }

    public class ValoracionesPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? titulo { get; set; }
        public string? fecha { get; set; }
        public List<valoracion>? valoraciones { get; set; }
    }

    public class ComentariosPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? titulo { get; set; }
        public string? fecha { get; set; }
        public List<comentario>? comentarios { get; set; }
    }


    public class EventosPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? escenario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
        public string? titulo { get; set; }
        public string? fecha { get; set; }
        public string? zona { get; set; }
    }
    public class topdata
    {
        public string? titulo { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? categoria { get; set; }
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
        public string? nombre { get; set; }
        public string? icon { get; set; }
        public string? nombre_pi { get; set; }
        public double valor { get; set; }
    }

}
