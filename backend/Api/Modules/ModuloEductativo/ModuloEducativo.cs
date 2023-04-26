using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Modules.ModuloEductativo
{
    public class ModuloEducativo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? instrucciones { get; set; }
        public string? logo_trivia { get; set; }
        public List<Pregunta>? preguntas { get; set; }
        public List<Puntaje>? puntajes { get; set; }

        public partial class Pregunta {
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string? pregunta_id { get; set; }
            public string? preguntaText { get; set; }
            public List<string>? imagen { get; set; }
            public string? explicacion { get; set; }
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string? categoria { get; set; }
            public string? dificultad { get; set; }
            public List<Alternativas>? alternativas { get; set; }
        }

        public partial class Alternativas {

            public string? alternativaText { get; set; }
            public bool correcto { get; set; } 

        }


        public partial class Puntaje
        {
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string? usuario_id { get; set; }
            public Int32 puntaje { get; set; }
            public string? fecha { get; set; }
            public Int32 cantcorrectas { get; set; }
            public Int32 cantincorrectas { get; set; }
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public List<string?>? rcorrectas { get; set; }
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public List<string?>? rincorrectas { get; set; }
        }
    }
}

