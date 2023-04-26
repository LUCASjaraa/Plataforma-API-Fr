using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Comentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        public ComentarioService _comentarioService;

        public ComentarioController(ComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _comentarioService.GetAllComentario(id));
        }

        [HttpGet("user")]
        public async Task<IActionResult> ComentarioById(string id, string id_usuario)
        {
            return Ok(await _comentarioService.comentarioById(id, id_usuario));

        }

        [HttpPost]
        public async Task<ActionResult> Create(string id, [FromBody] addComentario comentarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _comentarioService.CreateCoemntario(id, comentarios);
            return Created("Created", true);
        }
        [HttpPost("Aprobar")]
        public async Task<ActionResult> AprobarComentario(string id, string id_comentario)
        {
            await _comentarioService.AprobarComentario(id, id_comentario);
            return Created("Created", true);
        }

        [HttpPost("like")]
        public async Task<ActionResult> InsertLike(string id_comentario, string id_usuario)
        {
            if (id_usuario == null)
            {
                return BadRequest();
            }
            await _comentarioService.InsertLike(id_comentario, id_usuario);
            return Created("Created", true);

        }


       /* [HttpPatch]
        public async Task<ActionResult> Update(string id, [FromBody] upcomentario comentarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _comentarioService.UpdateComentario(id, comentarios);
            return Ok();
        }*/

        [HttpDelete]
        public async Task<ActionResult> delete(string id, string id_comentario)
        {
            await _comentarioService.deleteComentario(id, id_comentario);
            return NoContent();
        }


        [HttpDelete("like")]
        public async Task<ActionResult> deleteLike(string id_comentario, string id_usuario)
        {
            await _comentarioService.deleteLike(id_comentario, id_usuario);
            return NoContent();
        }
    }
}