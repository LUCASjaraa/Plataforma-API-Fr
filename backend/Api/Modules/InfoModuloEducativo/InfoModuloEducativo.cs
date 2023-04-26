using System;
using MongoDB.Bson.Serialization.Attributes;
using static Api.Modules.ModuloEductativo.ModuloEducativo;
using System.Collections.Generic;

namespace Api.Modules.InfoModuloEducativo
{
	public class InfoModuloEducativo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? subtitulo { get; set; }
        public string? contenido { get; set; }
        public string? site { get; set; }
        public string? icono { get; set; }
        public string? iconoColor { get; set; }

	}
}

