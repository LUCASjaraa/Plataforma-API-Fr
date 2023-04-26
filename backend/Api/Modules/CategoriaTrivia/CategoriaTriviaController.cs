using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.CategoriaTrivia
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaTriviaController : Controller
    {
        public CategoriaTriviaService _CategoriaTriviaService;

        public CategoriaTriviaController(CategoriaTriviaService categoriaTriviaService)
        {
            _CategoriaTriviaService = categoriaTriviaService;
        }

        [HttpGet("all")]
        public async Task <ActionResult> Get()
        {
            return Ok(await _CategoriaTriviaService.Get());
        }
        [HttpGet]

        public async Task <ActionResult> Get(string id)
        {
            return Ok(await _CategoriaTriviaService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoriaTrivia categoriaTrivia)
        {
            if (categoriaTrivia == null)
            {
                return BadRequest();
            }
            await _CategoriaTriviaService.Create(categoriaTrivia);
            return Created("Created", true);
        }


        [HttpPut]
        public async Task <ActionResult> Update(CategoriaTrivia categoriaTrivia)
        {
            if (categoriaTrivia == null)
            {
                return BadRequest();
            }
            await _CategoriaTriviaService.Update(categoriaTrivia);
            return Ok();
        }

        [HttpDelete]

        public async Task <ActionResult> Delete(string id)
        {
            await _CategoriaTriviaService.Delete(id);
            return NoContent();

        }
    }
}

