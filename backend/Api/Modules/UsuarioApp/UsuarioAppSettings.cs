using System;
namespace Api.Modules.UsuarioApp
{
    public class UsuarioAppSettings : IUsuarioAppSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
    public interface IUsuarioAppSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}

  