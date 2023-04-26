using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Visitas
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitaController : Controller
    {
        public VisitaService _VisitaService;

        public VisitaController(VisitaService visitaService)
        {
            _VisitaService = visitaService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _VisitaService.GetAllVisita(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(string id, [FromBody]visita visitas)
        {
            if (visitas == null)
            {
                return BadRequest();
            }
            await _VisitaService.CreateVisita(id, visitas);
            return Created("Created", true);
        }

        [HttpDelete]
        public async Task<ActionResult> delete(string id, string id_visita)
        {

            await _VisitaService.deleteVisita(id, id_visita);
            return NoContent();

        }

    }
}