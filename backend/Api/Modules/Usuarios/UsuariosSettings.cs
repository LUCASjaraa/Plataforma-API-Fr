namespace Api.Modules.Usuaios
{
    public class UsuariosSettings : IUsuariosSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
    public interface IUsuariosSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
 