using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using Api.helper;

namespace Api.Modules.Usuaios
{
    public class Usuarios
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required(ErrorMessage = "El campo usuario es requerido")]
        public string? usuario { get; set; }
        [Required(ErrorMessage = "La clave no debe estar vacia")]
        public string? clave { get; set; }
        /*[Compare("clave", ErrorMessage = "Las claves no coinciden")]
        [NotMapped]
        public string ConfirmarClave { get; set; }*/
        public string? sal { get; set; }
        /*public string nombre { get; set; }
        public string apellido { get; set; }
        public Int32  edad { get; set; }
        public string rol { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string ciudad { get; set; }
        public string region { get; set; }
        public string img_perfil { get; set; }   */
        public Usuarios(){}

        public Usuarios(Usuarios usuario)
        {
            this.usuario = usuario.usuario;
            HashedPassword hashedPassword = HashHelper.Hash(usuario.clave);
            this.clave = hashedPassword.Password;
            this.sal = hashedPassword.Salt;
        }
    }
}

