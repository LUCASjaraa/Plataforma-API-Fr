using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.ModuloEductativo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloEducativoController : Controller
    {
        public ModuloEducativoService _ModuloEducativoService;

        public ModuloEducativoController(ModuloEducativoService moduloEducativoService)
        {
            _ModuloEducativoService = moduloEducativoService;
        }

        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _ModuloEducativoService.Get());
        }
        [HttpGet]

        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _ModuloEducativoService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ModuloEducativo moduloEducativo)
        {
            if (moduloEducativo == null)
            {
                return BadRequest();
            }
            await _ModuloEducativoService.Create(moduloEducativo);
            return Created("Created", true);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]  ModuloEducativo moduloEducativo)
        {
            if (moduloEducativo == null)
            {
                return BadRequest();
            }
            await _ModuloEducativoService.Update(moduloEducativo);
            return Ok();
        }

        [HttpDelete]

        public async Task<ActionResult> Delete(string id)
        {
            await _ModuloEducativoService.Delete(id);
            return NoContent();

        }




    }
}

