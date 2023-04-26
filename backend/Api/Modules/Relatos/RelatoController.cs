using System.Threading.Tasks;
using Api.Modules.Galeria;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Relatos
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoController : Controller
    {
        public RelatoService _RelatoService;

        public RelatoController(RelatoService RelatoService)
        {
            _RelatoService = RelatoService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _RelatoService.getAllRelato(id));
        }
        
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<ActionResult> Create(string id, [FromForm] relatoDTO relato)
        {
            if (relato            == null ||
                relato.usuario_id == null ||
                relato.titulo     == null ||
                relato.Archivo    == null ||
                relato.fecha_subida == null)
            {
                return BadRequest();
            }

            await _RelatoService.createRelato(id, relato);
            return Created("Created", true);
        }


        [HttpPatch]
        public async Task<ActionResult> testUpdate(string id, [FromForm] relatoDTO relato)
        {
            if (relato == null || relato.relato_id == null || relato.relato_id =="")
            {
                return BadRequest();
            }
            await _RelatoService.updateRelato(id, relato);
            return Ok();
        }


        [HttpDelete]
        public async Task<ActionResult> delete(string id, string id_relato)
        {
            await _RelatoService.deleteRelato(id, id_relato);
            return NoContent();

        }
        [HttpPost("Aprobar")]
        public async Task<ActionResult> AprobarComentario(string id, string id_relato)
        {
            await _RelatoService.aprobarRelato(id, id_relato);
            return Created("Created", true);
        }

        [HttpPost("like")]
        public async Task<ActionResult> InsertLike(string id_relato, string id_usuario)
        {
            if (id_usuario == null)
            {
                return BadRequest();
            }
            await _RelatoService.insertLike(id_relato, id_usuario);
            return Created("Created", true);

        }


        [HttpDelete("like")]
        public async Task<ActionResult> deleteLike(string id_relato, string id_usuario)
        {
            await _RelatoService.deleteLike(id_relato, id_usuario);
            return NoContent();
        }

    }
}