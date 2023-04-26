using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Modules.PortalPage;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.AppPage
{
    [Route("api/app/page/")]
    [ApiController]

    public class AppPageController : Controller
    {
        public AppPageService _AppPageService;

        public AppPageController(AppPageService appPageService)
        {
            _AppPageService = appPageService;
        }

        [HttpGet("mappins")]
        public async Task<ActionResult> GetMapGis()
        {
            return Ok(await _AppPageService.getMapGist());
        }

        [HttpGet("memoria")]
        public async Task<ActionResult> GetMemoriaPage(string id)
        {
            return Ok(await _AppPageService.getMemoriaPage(id));
        }

        [HttpGet("camara")]
        public async Task<ActionResult> getCamaraPage(string id)
        {
            return Ok(await _AppPageService.getCamaraPage(id));
        }

        [HttpGet("galeria")]
        public async Task<ActionResult> getGaleriaPage(string id)
        {
            return Ok(await _AppPageService.getGaleriaPage(id));
        }

        [HttpGet("relatos")]
        public async Task<ActionResult> getRelatosPage(string id)
        {
            return Ok(await _AppPageService.getRelatosPage(id));
        }

        [HttpGet("valoraciones")]
        public async Task<ActionResult> ValoracionesPage(string id)
        {
            return Ok(await _AppPageService.ValoracionesPage(id));
        }

        [HttpGet("comentarios")]
        public async Task<ActionResult> ComentariosPage(string id)
        {
            return Ok(await _AppPageService.ComentariosPage(id));
        }

        [HttpGet("evento")]
        public async Task<ActionResult> GeneralEvento(string id)
        {
            return Ok(await _AppPageService.GeneralEvento(id));
        }


        [HttpGet("test")]
        public async Task<ActionResult> testt()
        {
            return Ok(await _AppPageService.Teest());
        }
        [HttpGet("top")]
        public async Task<ActionResult> tops( int top = 10)
        {
            return Ok(await _AppPageService.listop(top));
        }

    }
}