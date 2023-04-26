using System;
namespace Api.Modules.CategoriaEvento
{
    public class CategoriaEventoSettings : ICategoriaEventoSettings
    {
        public string? Server { get; set; }
        public string? Database { get; set; }
        public string? Collection { get; set; }

    }

    public interface ICategoriaEventoSettings
    {
        string? Server { get; set; }
        string? Database { get; set; }
        string? Collection { get; set; }
    }
}

