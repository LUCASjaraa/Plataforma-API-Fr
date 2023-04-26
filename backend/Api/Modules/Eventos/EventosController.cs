using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Api.Modules.Eventos.Eventos;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Eventos
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public EventosService _EventosService;

        public EventosController(EventosService eventosService)
        {
            _EventosService = eventosService;
        }
        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _EventosService.Get());
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _EventosService.Get(id));
        }


        [HttpGet("categoria")]
        public async Task<ActionResult> GetEventosbyCategory(string id_categoria)
        {
            return Ok(await _EventosService.GetEventosbyCategory(id_categoria));
        }

        [HttpGet("all/escenario")]
        public async Task<ActionResult> GetEventosbyEscenario(string id)
        {
            return Ok(await _EventosService.GetEventosbyEscenario(id));
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] addEvento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _EventosService.Create(evento);
            return Created("Created", true);
        }


        
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPatch]
        public async Task<ActionResult> Update([FromForm] updateEvento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _EventosService.updateEventos(evento);
            return Ok();
        }
        


        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await _EventosService.Delete(id);
            return NoContent();

        }
    }
}