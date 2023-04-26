using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Valoraciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoracionController : Controller
    {

        public ValoracionService _ValoracionService;

        public ValoracionController(ValoracionService valoracionService)
        {
            _ValoracionService = valoracionService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _ValoracionService.GetAllValoracion(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(string id, valoracion valoracion)
        {
            if (valoracion == null)
            {
                return BadRequest();
            }
            await _ValoracionService.CreateValoracion(id, valoracion);
            return Created("Created", true);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateValoracion(string id, valoracion valoracion)
        {
            if (valoracion == null)
            {
                return BadRequest();
            }

            await _ValoracionService.UpdateValoracion(id, valoracion);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> delete(string id, string id_valoarcion)
        {

            await _ValoracionService.deleteValoracion(id, id_valoarcion);
            return NoContent();
        }



        [HttpGet("promedio")]
        public async Task<ActionResult> GetPromedios(string id)
        {
            return Ok(await _ValoracionService.Promedios(id));
        }



    }
}
