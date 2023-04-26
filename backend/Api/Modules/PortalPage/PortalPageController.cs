using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.PortalPage
{
    [Route("api/portal/page/")]
    public class PortalPageController : Controller
    {
        public PortalPageService _portalPageService;

        public PortalPageController(PortalPageService portalPageService)
        {
            _portalPageService = portalPageService;

        }

        // GET api/values/5
        [HttpGet("puntosInteres")]
        public async Task<ActionResult> Get(string id_Escenario)
        {
            return Ok(await _portalPageService.GetAllPuntoInteres(id_Escenario));
        }

        [HttpGet("visitas")]
        public async Task<ActionResult> Gett(string id)
        {
            return Ok(await _portalPageService.GetVisitas(id));
        }

        [HttpGet("test")]
        public async Task<ActionResult> Pruebas(string id)
        {
            return Ok(await _portalPageService.getTest(id));
        }
        [HttpGet("cPuntosInteres")]
        public async Task<ActionResult> getPinteres(string id)
        {
            return Ok(await _portalPageService.getPinteres(id));
        }
        [HttpGet("caPuntosInteres")]
        public async Task<ActionResult> getPinteresCategoria(string id)
        {
            return Ok(await _portalPageService.getPinteresCategoria(id));
        }

        [HttpGet("PIgis")]
        public async Task<ActionResult> getPuntoIndasboard(string id)
        {
            return Ok(await _portalPageService.getPuntoIndasboard(id));
        }

        [HttpGet("cr/puntodeinteres")]
        public async Task<ActionResult> getByPinteres(string id)
        {
            return Ok(await _portalPageService.relatoscomentarios(id, "puntodeinteres"));
        }

        [HttpGet("cr/escenario")]
        public async Task<ActionResult> getByEscenario(string id)
        {
            return Ok(await _portalPageService.relatoscomentarios(id, "escenario"));
        }
        [HttpGet("cr/all")]
        public async Task<ActionResult> getByall(string id)
        {
            return Ok(await _portalPageService.relatoscomentarios(id, "all"));
        }
        [HttpGet("top")]
        public async Task<ActionResult> topd(string id)
        {
            return Ok(await _portalPageService.listop(10));
        }
        [HttpGet("tops")]
        public async Task<ActionResult> tops(string id, int top = 10)
        {
            return Ok(await _portalPageService.listop(top));
        }

        [HttpGet("datos_interes/all")]
        public async Task<ActionResult> dInteres()
        {
            return Ok(await _portalPageService.datosInteresAll());
        }




    }
}