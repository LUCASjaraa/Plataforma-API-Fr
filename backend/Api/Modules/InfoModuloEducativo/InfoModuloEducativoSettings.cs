using System;
namespace Api.Modules.InfoModuloEducativo
{
	public class InfoModuloEducativoSettings : IInfoModuloEducativoSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }

    public interface IInfoModuloEducativoSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
