using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Escenario
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscenarioController : Controller
    {
        public EscenarioService _EscenarioService;

        public EscenarioController(EscenarioService escenarioService)
        {
            _EscenarioService = escenarioService;
        }
        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _EscenarioService.Get());
        }
        [HttpGet]

        public async Task<ActionResult> GetbyId(string id)
        {
            return Ok(await _EscenarioService.GetbyId(id));
        }

        [HttpPost]
        public async Task <ActionResult> Create([FromBody] addEscenario escenarioService)
        {
            if (escenarioService == null)
            {
                return BadRequest();
            }
            await _EscenarioService.Create(escenarioService);
            return Created("Created", true);
        }

        [HttpPost("slide")]
        public async Task<ActionResult> CreatesLide(string id, [FromForm] addSlides slide)
        {
            if (slide == null)
            {
                return BadRequest();
            }
            await _EscenarioService.Createslides(id,slide);
            return Created("Created", true);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm]  Escenario escenarioService)
        {
            if (escenarioService == null)
            {
                return BadRequest();
            }
            await _EscenarioService.Update(escenarioService);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await _EscenarioService.Delete(id);
            return NoContent();

        }
    }
}

