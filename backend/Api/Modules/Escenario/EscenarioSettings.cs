namespace Api.Modules.Escenario
{
    public class EscenarioSettings : IEscenarioSettings
    {
        public string? Server { get; set; }
        public string? Database { get; set; }
        public string? Collection { get; set; }
    }
    public interface IEscenarioSettings
    {
        string? Server { get; set; }
        string? Database { get; set; }
        string? Collection { get; set; }
    }
}

