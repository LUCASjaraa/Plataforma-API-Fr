using System.Threading.Tasks;
using Api.Modules.Comentario;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Galeria
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaleriaController : Controller
    {
        public GaleriaService _GaleriaService;

        public GaleriaController(GaleriaService galeriaService)
        {
            _GaleriaService = galeriaService;
        }
        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _GaleriaService.GetGaleriabyId(id));
        }
        [HttpGet("all")]
        public async Task<ActionResult> Getall()
        {
            return Ok(await _GaleriaService.GetAllGaleria());
        }
        [HttpGet("top")]

        public async Task<ActionResult> Gettop(int t)
        {
            return Ok(await _GaleriaService.top(t));
        }


        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("add/imagen")]
        public async Task<ActionResult> CreateI(string id, [FromForm] addGaleria galeria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _GaleriaService.CreateGaleria(id, "imagen", galeria);
            return Created("Created", true);
    
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost("add/video")]
        public async Task<ActionResult> CreateV(string id, [FromForm] addGaleria galeria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _GaleriaService.CreateGaleria(id, "video", galeria);
            return Created("Created", true);

        }

        [HttpDelete]
        public async Task<ActionResult> delete(string id, string id_galeria)
        {
            await _GaleriaService.deleteGaleria(id, id_galeria);
            return Ok();

        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPatch]
        public async Task<ActionResult> Update(string id, string tipo, [FromForm] updateGaleria galeria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _GaleriaService.UpdateGaleria(id, galeria);
            return Ok();
        }



        [HttpPost("Aprobar")]
        public async Task<ActionResult> AprobarComentario(string id, string id_galeria)
        {
            await _GaleriaService.AprobarGaleria(id, id_galeria);
            return Created("Created", true);
        }

        [HttpPost("like")]
        public async Task<ActionResult> InsertLike(string id_galeria, string id_usuario)
        {
            if (id_usuario == null)
            {
                return BadRequest();
            }
            await _GaleriaService.InsertLike(id_galeria, id_usuario);
            return Created("Created", true);

        }
        [HttpDelete("like")]
        public async Task<ActionResult> deleteLike(string id_galeria, string id_usuario)
        {
            await _GaleriaService.deleteLike(id_galeria, id_usuario);
            return NoContent();
        }




    }
}


