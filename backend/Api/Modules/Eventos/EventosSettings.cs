namespace Api.Modules.Eventos
{
    public class EventosSettings : IEventosSettings
    {
        public string Server     { get; set; }
        public string Database   { get; set; }
        public string Collection { get; set; }
    }


    public interface IEventosSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }

}
