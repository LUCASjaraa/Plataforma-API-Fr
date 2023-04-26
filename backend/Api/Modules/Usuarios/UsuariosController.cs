using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Usuaios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuariosService _UsuariosService;
        
        public UsuariosController(UsuariosService usuariosService)
        {
            _UsuariosService = usuariosService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _UsuariosService.GetAll());
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _UsuariosService.Get(id));
        }


        [HttpGet("us")]
        public async Task<IActionResult> usr(string usr)
        {
            
            return Ok(await _UsuariosService.GetUser(usr));
        }


        [HttpPost]
        public async Task<IActionResult> Create(Usuarios usuario)
        {
            if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            if (await _UsuariosService.GetUser(usuario.usuario))
            {
                await _UsuariosService.Create(usuario);
                return Created("Created", true);
            }
            else
            {
                return BadRequest($"El usuario {usuario.usuario} ya existe");
            }
            
            
        }

        [HttpPut]
        public async Task<IActionResult> Update(Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            await _UsuariosService.Update(usuario.Id ,usuario);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await _UsuariosService.Delete(id);
            return NoContent();

        }

    }  
}

         