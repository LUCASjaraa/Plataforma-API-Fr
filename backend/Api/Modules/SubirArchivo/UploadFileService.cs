using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;
using System.Security.Policy;
using System.Xml.Linq;

namespace Api.Modules.SubirArchivo
{
    public class UploadFileService
    {

        private readonly string _RutaServidorFile;
        private readonly string _url;

        public UploadFileService()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _RutaServidorFile = configuration.GetSection("Configuracion").GetSection("RutaServidorFile").Value;
            _url = configuration.GetSection("Configuracion").GetSection("Url").Value;

        }
        /*
        "Url": "https://localhost/Fr-files/",
        "RutaServidorFile": "/Users/lucas_jara/Documents/tesis/Fr-files"
         */

        //Metodo OK
        public async Task<UploadFile> datoInteresAdd(string id,string name, IFormFile file)
        {
            string path = Path.Combine(id, "datosInteres");
            return await subirFile(path, name, file);
        }
        //Metodo OK
        public bool datoInteresDelete(string id, string url)
        {
            string namefile = Path.GetFileName(url);
            string path = Path.Combine(id, "datosInteres", namefile);
            return deleteFile(path);
        }
        //Metodo Ok
        public async Task<UploadFile> galeriaAdd(string tipo, string id, string usuario_id, string galeria_id, IFormFile file)
        {
            string path = "";
            switch (tipo)
            {
                case "img":
                    path = Path.Combine(id, "galeria", "img", usuario_id);
                    break;

                case "video":
                    path = Path.Combine(id, "galeria", "video", usuario_id);
                    break;

                default:
                    break;
            }

            if (!Directory.Exists(rutaCreatedir(path)))
            {
                Directory.CreateDirectory(rutaCreatedir(path));

                return await subirFile(path, galeria_id, file);
            }
            else
            {
                return await subirFile(path, galeria_id, file);
            }

        }
        //Metodo Ok
        public bool GaleriaDelete(string tipo, string id, string usuario_id, string name)
        {

            switch (tipo)
            {
                case "img":
                    string namefilei = Path.GetFileName(name);
                    string pathGi = Path.Combine(id, "galeria", "img", usuario_id, namefilei);
                    return deleteFile(pathGi);
                case "video":
                    string namefilev = Path.GetFileName(name);
                    string pathGv = Path.Combine(id, "galeria", "video", usuario_id, namefilev);
                    return deleteFile(pathGv);
                default:
                    return false;
            }
        }

        //Metodo ok
        public async Task<UploadFile> reltaroAdd(string id, string usuario_id, string relato_id, IFormFile file)
        {
            string path = Path.Combine( id, "relatos", usuario_id);

            if (!Directory.Exists(rutaCreatedir(path)))
            {
                Directory.CreateDirectory(rutaCreatedir(path));
                return await subirFile(path, relato_id, file);
            }
            else
            {
                return await subirFile(path, relato_id, file);
            }
        }
        //Metodo ok
        public bool reltaroDelete(string id, string usuario_id, string relato_id ,string url)
        {
            string namefile = Path.GetFileName(url);
            string path = Path.Combine(id, "relatos", usuario_id, namefile);
            return deleteFile(path);
        }

        //Metodo ok
        public async Task<UploadFile> defaultAdd(string tipo, string id,string name, IFormFile file)
        {

            string pathPia = "";
            switch (tipo)
            {
                case "img":
                    pathPia = Path.Combine(id, "default", "imagen");
                    break;
                case "aud":
                    pathPia = Path.Combine(id, "default", "audio");
                    break;
                default:
                    break;
            }
            return await subirFile(pathPia, name, file);
        }


        public bool defaultdelete(string tipo, string id, string name)
        {
            var nameFile= Path.GetFileName(name);
            string path;
            switch (tipo)
            {
                case "img":
                    path = Path.Combine(id, "default", "img", nameFile);
                    return deleteFile(path);
                case "aud":
                    path = Path.Combine(id, "default", "audio", nameFile);
                    return deleteFile(path);
                default:
                    return false;
            }
        }
        //Metodo Ok
        public async Task<UploadFile> imgMapaAdd(string id, string name, IFormFile file)
        {
            //path imgMapa
            string path = Path.Combine(id, "imgmapa", "img");
            return await subirFile(path, name, file);
        }


        public bool imgMapaDelete(string id, string name)
        {
            var nameFile = Path.GetFileName(id);
            string path = Path.Combine(id, "imgmapa", "img", nameFile);
            return deleteFile(path);
        }


        public async Task<UploadFile> slideAdd(string id, string usuario_id, string slide_id, IFormFile file)
        {
            string path = Path.Combine(id, "slides", usuario_id, slide_id);

            if (!Directory.Exists(rutaCreatedir(path)))
            {
                Directory.CreateDirectory(rutaCreatedir(path));
                return await subirFile(path, ObjectId.GenerateNewId().ToString(), file);
            }
            else {
                Directory.CreateDirectory(rutaCreatedir(path));
                return await subirFile(path, ObjectId.GenerateNewId().ToString(), file);
            }
        }



        public bool slideDelete(string id, string name, string usuario_id, string slide_id)
        {
            var nameFile = Path.GetFileName(name);

            string path = Path.Combine(id, "slides", usuario_id, slide_id, nameFile);
      
            return deleteFile(path);
        }



        //Metodo ok
        public string rutaCreatedir(string ruta)
        {

            return Path.Combine(_RutaServidorFile, ruta);
        }
        //Metodo ok
        public async Task<UploadFile> subirFile(string ruta, string name, IFormFile file)
        {
            string path = Path.Combine(_RutaServidorFile, ruta);

            FileInfo fileInfo = new FileInfo(file.FileName);
            string FileName = name.ToString() + fileInfo.Extension;
            string  rutaDocumento = Path.Combine(path, FileName);
            try
            {
                await using (FileStream newFile = File.Create(rutaDocumento))
                {

                    file.CopyTo(newFile);
                    newFile.Flush();
                }
                
                return new UploadFile { status = true, urlFile = Path.Combine(_url, ruta, FileName) };
            }
            catch (Exception)
            {
                return new UploadFile { status = false, urlFile = rutaDocumento };
            }
        }
        //Metodo ok
        public bool deleteFile(string path)
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(Path.Combine(_RutaServidorFile,path));
                return true;
            }
            catch (Exception) { return false; }
        }
        //metodo ok
        public bool CreateDirectorys(string id)
        {
            string subPath = Path.Combine(_RutaServidorFile, id);
            bool exists = Directory.Exists(subPath);

            if (!exists)
            {
                //se crea la estructura de carpetas para los archivos por defecto
                Directory.CreateDirectory(subPath);
                string def = Path.Combine(subPath, "default");
                string defimg = Path.Combine(def, "imagen");
                string defaud = Path.Combine(def, "audio");
                Directory.CreateDirectory(def);
                Directory.CreateDirectory(defimg);
                Directory.CreateDirectory(defaud);

                //Se crea la estructura de carpetas para los datos de ineteres
                string datosInteres = Path.Combine(subPath, "datosInteres");
                Directory.CreateDirectory(datosInteres);

                //Se crea la estructura de carpetas para los relatos
                string relatos = Path.Combine(subPath, "relatos");
                Directory.CreateDirectory(relatos);

                //Se crea la estructura de carpetas para la galeria
                string galeria = Path.Combine(subPath,"galeria");
                string galeriaimg = Path.Combine(galeria, "img");
                string galeriavid = Path.Combine(galeria, "video");
                Directory.CreateDirectory(galeria);
                Directory.CreateDirectory(galeriaimg);
                Directory.CreateDirectory(galeriavid);

                //Se crea la estructura de carpetas para la imgMapa
                string imgMapa = Path.Combine(subPath,"imgmapa");
                string imgmapaim = Path.Combine(imgMapa, "img");
                Directory.CreateDirectory(imgMapa);
                Directory.CreateDirectory(imgmapaim);

                //Se crea la estructura de carpetas para la Slide
                string Slide =   Path.Combine(subPath,"slides");
                Directory.CreateDirectory(Slide);
                return true;
            }

            return true;
        }

        public bool CreatedirectorysEs( string id)
        {
            string subPath = Path.Combine(_RutaServidorFile, "escenarios", id);
            bool exists = Directory.Exists(subPath);
            if (!exists)
            {
                Directory.CreateDirectory(subPath);
                string Slide = Path.Combine(subPath, "slides");
                Directory.CreateDirectory(Slide);

                return true;
            }

            return true;

        }

        /*
        public async Task<UploadFile> imgMapaAdd(string id, string name, IFormFile file)
        {
            //path imgMapa
            string path = Path.Combine(id, "imgmapa", "img");
            return await subirFile(path, name, file);
        }*/

        public async Task<UploadFile> addslidesEscenario(string id, IFormFile file)
        {
            string path = Path.Combine("escenarios", id, "slides");
            return await subirFile(path, ObjectId.GenerateNewId().ToString(), file);


        }
        public bool deleteslidesEscenario(string id, IFormFile file)
        {
            
            return true;


        }




    }
}