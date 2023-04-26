using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.InfoModuloEducativo
{
    [Route("api/[controller]")]
    public class InfoModuloEducativoController : Controller
    {
        public InfoModuloEducativoService _InfoMe;

        public InfoModuloEducativoController(InfoModuloEducativoService InfoMe)
        {

            _InfoMe = InfoMe;
        }

        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {

            return Ok(await _InfoMe.Get());
        }

    }
}

