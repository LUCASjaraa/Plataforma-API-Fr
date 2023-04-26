using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.CategoriaEvento
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaEventoController : Controller
    {
        public CategoriaEventoService _CategoriaEventoService;

        public CategoriaEventoController(CategoriaEventoService categoriaEventoService)
        {
            _CategoriaEventoService = categoriaEventoService;

        }
        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _CategoriaEventoService.Get());
        }


        [HttpGet]
        public async Task<ActionResult> Getc(string id_categoria)
        {
            return Ok(await _CategoriaEventoService.Getbyid(id_categoria));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoriaEvento categoriaEventoService)
        {
            if (categoriaEventoService == null)
            {
                return BadRequest();
            }
            await _CategoriaEventoService.Create(categoriaEventoService);
            return Created("Created",true);
        }




        [HttpPut]
        public async Task <ActionResult> Update(CategoriaEvento categoriaEventoService)
        {
            if (categoriaEventoService == null)
            {
                return BadRequest();
            }

            await _CategoriaEventoService.Update(categoriaEventoService);
            return Ok();
        }

        [HttpDelete]

        public async Task <ActionResult> Delete(string id_categoria)
        {
            await _CategoriaEventoService.Delete(id_categoria);
            return NoContent();

        }

    }
}

