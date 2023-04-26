using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.DatoInteres
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosInteresController : Controller
    {
        public DatosInteresService _DatosInteresService;

        public DatosInteresController(DatosInteresService datosInteresService)
        {
            _DatosInteresService = datosInteresService;
        }
        [HttpGet("all")]
        public async Task<ActionResult> Getall()
        {
            return Ok(await _DatosInteresService.GetAllDatoInteres());
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _DatosInteresService.GetDatoInteres(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(string id, [FromBody] datosInteres datosInteres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _DatosInteresService.CreateDatoInteres(id, datosInteres);
            return Created("Created", true);
        }

        [HttpPatch]
        public async Task<ActionResult> Update(string id, [FromBody] datosInteres datosInteres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _DatosInteresService.UpdateDatoInteres(id, datosInteres);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> deleteDatoInteres(string id, string id_dinteres)
        {
            await _DatosInteresService.deleteDatoInteres(id, id_dinteres);
            return NoContent();

        }

    }
}