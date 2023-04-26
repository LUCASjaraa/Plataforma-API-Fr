
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Threading.Tasks;
using Api.Modules.Eventos;
using Api.Modules.SubirArchivo;
using Microsoft.AspNetCore.Http;
using Api.Modules.Galeria;
using Api.Modules.Escenario;
using System.Drawing;

namespace Api.Modules.Slides
{
    public class SlidesService
    {
        private IMongoCollection<BsonDocument> _Slides;
        private UploadFileService _subirFile;

        public SlidesService(IEventosSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Slides = database.GetCollection<BsonDocument>(settings.Collection);
            _subirFile = new UploadFileService();

        }

        public async Task<List<slides>> GetAllSlides(string id)
        {
            var projection = Builders<BsonDocument>.Projection.Include("slides").Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var options = new FindOptions<BsonDocument> { Projection = projection };
            var result = await _Slides.FindAsync(filter, options).Result.FirstAsync();
            return BsonSerializer.Deserialize<Slides>(result.ToJson()).slides;


        }


        /*
                 public async Task<galeriaDelete> getUrl(string id, string id_galeria)
        {
            var galerias= await GetGaleriabyId(id);
            galeriaDelete galeriad = new galeriaDelete();
            galeriad.usuario_id = galerias.Where(i => i.galeria_id == id_galeria).FirstOrDefault().usuario_id;
            galeriad.contenido = galerias.Where(i => i.galeria_id == id_galeria).FirstOrDefault().contenido;
            galeriad.tipo = galerias.Where(i => i.galeria_id == id_galeria).FirstOrDefault().tipo;

            return galeriad;
        }
         
         */
        public async Task<slides> GetSlidesbyId(string id, string slide_id)
        {
            var slides = await GetAllSlides(id);
            return slides.Where(i=>i.slide_id == slide_id).FirstOrDefault();
        }


        public async Task CreateSlides(string id, addSlides slide)
        {

            //public async Task<UploadFile> slideAdd(string id, string usuario_id, string slide_id, IFormFile file)
            var img = new List<string>();
            var fechas = new List<string>();
            var descripciones = new List<string>();

            var slide_id = ObjectId.GenerateNewId().ToString();


            if (slide.antesFile != null)
            {
                UploadFile antesF = await _subirFile.slideAdd(id, slide.usuario_id, slide_id, slide.antesFile);
                if (antesF.status)
                {
                    img.Add(antesF.urlFile);
                    descripciones.Add(slide.antesdescripcion);
                    fechas.Add(slide.antesfecha);
                }
            }
            else
            {
                img.Add("url-pordefecto");
                descripciones.Add("null");
                fechas.Add("null");
            }

            if (slide.duranteFile != null)
            {
                UploadFile duranteF = await _subirFile.slideAdd(id, slide.usuario_id, slide_id, slide.duranteFile);
                if (duranteF.status)
                {
                    img.Add(duranteF.urlFile);
                    descripciones.Add(slide.durantedescripcion);
                    fechas.Add(slide.durantefecha);
                }

            }
            else
            {
                img.Add("url-pordefecto");
                descripciones.Add("null");
                fechas.Add("null");
            }

            if (slide.jdespuesFile != null)
            {

                UploadFile jdespuesF = await _subirFile.slideAdd(id, slide.usuario_id, slide_id, slide.jdespuesFile);
                if (jdespuesF.status)
                {
                    img.Add(jdespuesF.urlFile);
                    descripciones.Add(slide.jdespuesdescripcion);
                    fechas.Add(slide.jdespuesfecha);
                }
            }
            else
            {
                img.Add("url-pordefecto");
                descripciones.Add("null");
                fechas.Add("null");
            }

            if (slide.ahoraFile != null)
            {
                UploadFile ahoraF = await _subirFile.slideAdd(id, slide.usuario_id, slide_id, slide.ahoraFile);
                if (ahoraF.status)
                {
                    img.Add(ahoraF.urlFile);
                    descripciones.Add(slide.ahoradescripcion);
                    fechas.Add(slide.ahorafecha);

                }
            }
            else
            {
                img.Add("url-pordefecto");
                descripciones.Add("null");
                fechas.Add("null");
            }
            slide.slide_id = slide_id;
            slide.img = img;
            slide.fechas = fechas;
            slide.descripciones = descripciones;

            slides newSlide = new slides(slide);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.Push("slides", newSlide);
            await _Slides.UpdateOneAsync(filter, update);

        }




        public async Task UpdateSlides(string id, updateSlides slide)
        {


            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<BsonDocument>.Filter.Eq("slides.slide_id", ObjectId.Parse(slide.slide_id)));

            var updateSlide = new List<UpdateDefinition<BsonDocument>>();
            var slideItem = await GetSlidesbyId(id, slide.slide_id);

            //array de objetos
            //0 - antes 1 - durante 2- justo despues  3- ahora

            var img = slideItem.img;
            var fechas = slideItem.fechas;
            var descipciones = slideItem.descripciones;


            if (slide.titulo != "" && slide.titulo != null)
            {
                updateSlide.Add(Builders<BsonDocument>.Update.Set("slides.$.titulo", slide.titulo));
            }

            //[0]
            if (slide.antesFile != null)
            {
                if (img[0] != "null")
                {
                    if (_subirFile.slideDelete(id, img[0], slideItem.usuario_id, slideItem.slide_id))
                    {
                        UploadFile antesF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.antesFile);
                        if (antesF.status)
                        {
                            img[0] = antesF.urlFile;
                        }
                    }
                }
                else
                {
                    UploadFile antesF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.antesFile);
                    if (antesF.status)
                    {
                        img[0] = antesF.urlFile;
                    }

                }
            }

            if (slide.antesfecha != null && slide.antesfecha != "")
            {
                fechas[0] = slide.antesfecha;
            }
            if (slide.antesdescripcion != null && slide.antesdescripcion != "")
            {
                descipciones[0] = slide.antesdescripcion;
            }



            //[1]
            if (slide.duranteFile != null)
            {
                if (img[1] != "null")
                {
                    if (_subirFile.slideDelete(id, img[1], slideItem.usuario_id, slideItem.slide_id))
                    {
                        UploadFile duranteF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.duranteFile);
                        if (duranteF.status)
                        {
                            img[1] = duranteF.urlFile;
                        }
                    }
                }
                else
                {
                    UploadFile duranteF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.duranteFile);
                    if (duranteF.status)
                    {
                        img[1] = duranteF.urlFile;
                    }

                }

            }

            if (slide.durantefecha != null && slide.durantefecha != "")
            {
                fechas[1] = slide.durantefecha;
            }
            if (slide.durantedescripcion != null && slide.durantedescripcion != "")
            {
                descipciones[1] = slide.durantedescripcion;
            }



            //[2]
            if (slide.jdespuesFile != null)
            {
                if (img[2] != "null")
                {
                    if (_subirFile.slideDelete(id, img[2], slideItem.usuario_id, slideItem.slide_id))
                    {
                        UploadFile jdespuesF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.jdespuesFile);
                        if (jdespuesF.status)
                        {
                            img[2] = jdespuesF.urlFile;
                        }
                    }
                }
                else
                {
                    UploadFile jdespuesF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.jdespuesFile);
                    if (jdespuesF.status)
                    {
                        img[2] = jdespuesF.urlFile;
                    }
                }


            }
            if (slide.jdespuesfecha != null && slide.jdespuesfecha != "")
            {
                fechas[2] = slide.jdespuesfecha;
            }
            if (slide.jdespuesdescripcion != null && slide.jdespuesdescripcion != "")
            {
                descipciones[2] = slide.jdespuesdescripcion;
            }


            //[3]
            if (slide.ahoraFile != null)
            {
                if (img[3] != "null")
                {
                    if (_subirFile.slideDelete(id, img[3], slideItem.usuario_id, slideItem.slide_id))
                    {
                        UploadFile ahoraF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.ahoraFile);
                        if (ahoraF.status)
                        {
                            img[3] = ahoraF.urlFile;
                        }
                    }
                }
                else
                {
                    UploadFile ahoraF = await _subirFile.slideAdd(id, slideItem.usuario_id, slideItem.slide_id, slide.ahoraFile);
                    if (ahoraF.status)
                    {
                        img[3] = ahoraF.urlFile;
                    }

                }

            }

            if (slide.ahorafecha != null && slide.ahorafecha != "")
            {
                fechas[3] = slide.ahorafecha;
            }
            if (slide.ahoradescripcion != null && slide.ahoradescripcion != "")
            {
                descipciones[3] = slide.ahoradescripcion;
            }



            if (slide.fecha_subida != null && slide.fecha_subida != "")
            {
                updateSlide.Add(Builders<BsonDocument>.Update.Set("slides.$.fecha_subida", slide.fecha_subida));
            }

            updateSlide.Add(Builders<BsonDocument>.Update.Set("slides.$.img", img));
            updateSlide.Add(Builders<BsonDocument>.Update.Set("slides.$.fechas", fechas));
            updateSlide.Add(Builders<BsonDocument>.Update.Set("slides.$.descripciones", descipciones));

            var update = Builders<BsonDocument>.Update.Combine(updateSlide);
            await _Slides.UpdateOneAsync(filter, update);
        }


        public async Task deleteSlides(string id, string slide_id)
        {
            var slideItem = await GetSlidesbyId(id, slide_id);

            if (_subirFile.slideDelete(id, slideItem.img[0], slideItem.usuario_id, slideItem.slide_id) &&
                _subirFile.slideDelete(id, slideItem.img[1], slideItem.usuario_id, slideItem.slide_id) &&
                _subirFile.slideDelete(id, slideItem.img[2], slideItem.usuario_id, slideItem.slide_id) &&
                _subirFile.slideDelete(id, slideItem.img[3], slideItem.usuario_id, slideItem.slide_id))
            {

                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<BsonDocument>.Update.PullFilter("memoria", Builders<BsonDocument>.Filter.Eq("memoria_id", ObjectId.Parse(slide_id)));
                await _Slides.UpdateOneAsync(filter, update);
            }

        }

    }
}

