using System;
using Api.Modules.AppPage;
using Api.Modules.CategoriaEvento;
using Api.Modules.CategoriaTrivia;
using Api.Modules.Comentario;
using Api.Modules.DatoInteres;
using Api.Modules.Escenario;
using Api.Modules.Eventos;
using Api.Modules.Galeria;
using Api.Modules.InfoModuloEducativo;
using Api.Modules.ModuloEductativo;
using Api.Modules.PortalPage;
using Api.Modules.Relatos;
using Api.Modules.Slides;
using Api.Modules.Usuaios;
using Api.Modules.UsuarioApp;
using Api.Modules.Valoraciones;
using Api.Modules.Visitas;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Api
{
	public static class DependencyInyections
	{

		public static IServiceCollection addServices(this IServiceCollection services, IConfiguration configuration)
		{

            services.Configure<ModuloEducativoSettings>(configuration.GetSection(nameof(ModuloEducativoSettings)));
            services.AddSingleton<IModuloEducativoSettings>(d => d.GetRequiredService<IOptions<ModuloEducativoSettings>>().Value);
            services.AddSingleton<ModuloEducativoService>();

            services.Configure<CategoriaTriviaSettings>(configuration.GetSection(nameof(CategoriaTriviaSettings)));
            services.AddSingleton<ICategoriaTriviaSettings>(d => d.GetRequiredService<IOptions<CategoriaTriviaSettings>>().Value);
            services.AddSingleton<CategoriaTriviaService>();

            services.Configure<UsuarioAppSettings>(configuration.GetSection(nameof(UsuarioAppSettings)));
            services.AddSingleton<IUsuarioAppSettings>(d => d.GetRequiredService<IOptions<UsuarioAppSettings>>().Value);
            services.AddSingleton<UsuarioAppService>();

            services.Configure<EscenarioSettings>(configuration.GetSection(nameof(EscenarioSettings)));
            services.AddSingleton<IEscenarioSettings>(d => d.GetRequiredService<IOptions<EscenarioSettings>>().Value);
            services.AddSingleton<EscenarioService>();



            services.Configure<CategoriaEventoSettings>(configuration.GetSection(nameof(CategoriaEventoSettings)));
            services.AddSingleton<ICategoriaEventoSettings>(d => d.GetRequiredService<IOptions<CategoriaEventoSettings>>().Value);
            services.AddSingleton<CategoriaEventoService>();
            services.AddSingleton<AppPageService>();
            services.AddSingleton<PortalPageService>();




            services.Configure<InfoModuloEducativoSettings>(configuration.GetSection(nameof(InfoModuloEducativoSettings)));
            services.AddSingleton<IInfoModuloEducativoSettings>(d => d.GetRequiredService<IOptions<InfoModuloEducativoSettings>>().Value);
            services.AddSingleton<InfoModuloEducativoService>();



            services.Configure<UsuariosSettings>(configuration.GetSection(nameof(UsuariosSettings)));
            services.AddSingleton<IUsuariosSettings>(d => d.GetRequiredService<IOptions<UsuariosSettings>>().Value);
            services.AddSingleton<UsuariosService>();


            /*Inyeccion a los servicios*/

            services.Configure<EventosSettings>(configuration.GetSection(nameof(EventosSettings)));
            services.AddSingleton<IEventosSettings>(d => d.GetRequiredService<IOptions<EventosSettings>>().Value);
            services.AddSingleton<EventosService>();
            services.AddSingleton<GaleriaService>();
            services.AddSingleton<PortalPageService>();
            services.AddSingleton<ComentarioService>();
            services.AddSingleton<DatosInteresService>();
            services.AddSingleton<SlidesService>();
            services.AddSingleton<ValoracionService>();
            services.AddSingleton<VisitaService>();
            services.AddSingleton<RelatoService>();
            services.AddSingleton<AppPageService>();

            return services;
		}
	}
}

