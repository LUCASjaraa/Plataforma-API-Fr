using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.UsuarioApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAppController : Controller
    {
        public UsuarioAppService _UsuarioAppService;
        public UsuarioAppController(UsuarioAppService usuarioAppService)
        {
            _UsuarioAppService = usuarioAppService;
        }
        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _UsuarioAppService.Get());
        }
        [HttpGet]

        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _UsuarioAppService.Get(id));
        }


        [HttpPost]
        public async Task<ActionResult> Create( [FromBody] UsuarioApp usuarioApp)
        {
            if (usuarioApp == null)
            {
                return BadRequest();
            }
            await _UsuarioAppService.Create(usuarioApp);
            return Created("Created", true);
        }

        [HttpPut]
        public async Task <ActionResult> Update([FromBody]  UsuarioApp usuarioApp)
        {
            if (usuarioApp == null)
            {
                return BadRequest();
            }
            await _UsuarioAppService.Update(usuarioApp);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await _UsuarioAppService.Delete(id);
            return NoContent();

        }

    }
}
