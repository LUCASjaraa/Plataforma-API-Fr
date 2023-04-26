using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Api.Modules.Valoraciones
{
    public class Valoracion
    {
        public List<valoracion> valoraciones { get; set; }
    }
    public partial class valoracion
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        public long val_interes { get; set; }
        public long val_inmersion { get; set; }
        public string? fecha_val { get; set; }
    }

    public class Promedio
    {
        public long promedio_interes { get; set; }
        public long promedio_inmersion { get; set; }
    }
}