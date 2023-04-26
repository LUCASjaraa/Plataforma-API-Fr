using System;
namespace Api.Modules.CategoriaTrivia
{
    public class CategoriaTriviaSettings :ICategoriaTriviaSettings
    {
        public string? Server { get; set; }
        public string? Database { get; set; }
        public string? Collection { get; set; }
    }

    public interface ICategoriaTriviaSettings
    {
        string? Server { get; set; }
        string? Database { get; set; }
        string? Collection { get; set; }
    }
}

