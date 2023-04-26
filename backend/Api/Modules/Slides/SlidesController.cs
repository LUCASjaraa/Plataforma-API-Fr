using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.Slides
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : Controller
    {
        public SlidesService _slidesService;

        public SlidesController(SlidesService slidesService)
        {
            _slidesService = slidesService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _slidesService.GetAllSlides(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(string id, [FromForm] addSlides slides)
        {
            if (slides == null)
            {
                return BadRequest();
            }

            await _slidesService.CreateSlides(id, slides);
            return Created("Created", true);
        }

        [HttpPut]
        public async Task<ActionResult> Update(string id ,[FromForm] updateSlides slides)
        {
            if (slides == null)
            {
                return BadRequest();
            }
            await _slidesService.UpdateSlides(id, slides);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> delete(string id, string id_slides)
        {

            await _slidesService.deleteSlides(id, id_slides);
            return NoContent();

        }


    }
}