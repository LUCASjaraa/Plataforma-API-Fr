using System;
namespace Api.Modules.ModuloEductativo
{
    public class ModuloEducativoSettings : IModuloEducativoSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
    public interface IModuloEducativoSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}

