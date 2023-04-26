using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Modules.SubirArchivo
{
    [Route("api/add/")]
    [ApiController]
    public class DocController : Controller
    {
        private UploadFileService _subirFile;

        public DocController()
        {
            _subirFile = new UploadFileService();    
        }
       [HttpPost]
        public async Task<UploadFile> iSubirAsynccc([FromForm]IFormFile file)
        {
            return await _subirFile.slideAdd("63a21fa26c20db6c3a853cfa", "632a072930305800b2d85221", "63a33df7d00c7eb42d185255", file);
        }

        /*[HttpDelete]
        public bool delete(string Tipo, string nombre)
        {
            return _subirFile.borrarFile("img", "638ecdd046567c873c049d8a");
        }

        [HttpPost("{id}")]
        public bool create(string id)
        {
            return _subirFile.CreateDirectorys(id);
        }*/

    }
}