using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Modules.DatoInteres;
using Api.Modules.Galeria;
using Api.Modules.Comentario;
using Api.Modules.Relatos;
using Api.Modules.Valoraciones;
using Api.Modules.Slides;
using Api.Modules.Visitas;
using Microsoft.Extensions.Configuration;
using Api.Modules.SubirArchivo;
using static Api.Modules.Eventos.Eventos;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;

namespace Api.Modules.Eventos
{
    public class EventosService
    {

        private IMongoCollection<Eventos> _Eventos;
        private UploadFileService _subirFile;


        public EventosService(IEventosSettings settings, IConfiguration configuration)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _Eventos = database.GetCollection<Eventos>(settings.Collection);
            _subirFile = new UploadFileService();

        }

        public async Task<List<Eventos>> Get()
        {
            return await _Eventos.FindAsync(d => true).Result.ToListAsync();
        }

        public async Task<Eventos> Get(string id)
        {
            return await _Eventos.FindAsync(d => d.id == id).Result.FirstAsync();
        }

        public async Task<List<Eventos>> GetEventosbyEscenario(string id)
        {

            return await _Eventos.FindAsync(d => d.escenario_id == id).Result.ToListAsync();
        }


        public async Task<List<Eventos>> GetEventosbyCategory(string id)
        {
            return await _Eventos.FindAsync(d => d.categoria == id).Result.ToListAsync();
        }

        public async Task Create(addEvento evento)
        { 
            evento.id = ObjectId.GenerateNewId().ToString();
            _subirFile.CreateDirectorys(evento.id);

            UploadFile FileImg_evento = await _subirFile.defaultAdd("img", evento.id, evento.id, evento.fileimg_evento);
            if (FileImg_evento.status) { evento.img_evento = FileImg_evento.urlFile; }

            List<string> img = new List<string>();

            UploadFile oneFileimg = await _subirFile.defaultAdd("img", evento.id, ObjectId.GenerateNewId().ToString(), evento.oneFileimg);
            if (oneFileimg.status)
            {
                img.Add(oneFileimg.urlFile);
                UploadFile twoFileimg = await _subirFile.defaultAdd("img", evento.id, ObjectId.GenerateNewId().ToString(), evento.twoFileimg);
                if (twoFileimg.status)
                {
                    img.Add(twoFileimg.urlFile);
                }
            }

            List<string> audio = new List<string>();

            UploadFile FileAudione = await _subirFile.defaultAdd("aud", evento.id, ObjectId.GenerateNewId().ToString(), evento.oneFileaudio);
            if (FileAudione.status)
            {
                audio.Add(FileAudione.urlFile);

                UploadFile FileAudiotwo = await _subirFile.defaultAdd("aud", evento.id, ObjectId.GenerateNewId().ToString(), evento.twoFileaudio);
                if (FileAudiotwo.status)
                {
                    audio.Add(FileAudiotwo.urlFile);
                }
            }

            Img_aerea img_aerea = new Img_aerea()
                                {
                                    url_antes="",
                                    url_despues="",
                                    descripcion = evento.addescripcion
                                };

            UploadFile FileUrl_antes = await _subirFile.imgMapaAdd(evento.id, ObjectId.GenerateNewId().ToString(), evento.file_antes);
            if (FileUrl_antes.status) { img_aerea.url_antes = FileUrl_antes.urlFile; }

            UploadFile FileUrl_despues = await _subirFile.imgMapaAdd(evento.id, ObjectId.GenerateNewId().ToString(), evento.file_despues);
            if (FileUrl_despues.status) { img_aerea.url_despues = FileUrl_despues.urlFile; }

            evento.img_aerea = img_aerea;
            evento.img_camara = img;
            evento.audio_camara = audio;
           

            evento.pos_evento = new Pos_evento() { lat = Convert.ToDouble(evento.latitud), lng = Convert.ToDouble(evento.longitud), alt = Convert.ToDouble(evento.altura) };
            evento.camera_pose = new Camera_pose() { head = Convert.ToDouble(evento.head), pitch = Convert.ToDouble(evento.pitch), roll = Convert.ToDouble(evento.roll) };

            var newEvento = new Eventos(evento);
            await _Eventos.InsertOneAsync(newEvento);
        }


        public async Task updateEventos(updateEvento eventos)
        {
            var filter = Builders<Eventos>.Filter.Eq(s => s.id, eventos.id);
            var updatePinteres = new List<UpdateDefinition<Eventos>>();


            //Listo
            if (eventos.escenario_id != "" && eventos.escenario_id != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.escenario_id, eventos.escenario_id));
            }
            //Listo

            if (eventos.categoria != "" && eventos.categoria != null)
            {

                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.categoria, eventos.categoria));
            }
            //Listo

            if (eventos.titulo != "" && eventos.titulo != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.titulo, eventos.titulo));


            }
            //Listo

            if (eventos.descripcion != "" && eventos.descripcion != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.descripcion, eventos.descripcion));

            }
            //Listo
            if (eventos.descripcion_corta != "" && eventos.descripcion_corta != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.descripcion_corta, eventos.descripcion_corta));
            }

            //Listo
            if (eventos.zona != "" && eventos.zona != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.zona, eventos.zona));

            }
            //Listo
            if (eventos.fecha != "" && eventos.fecha != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.fecha, eventos.fecha));
            }

            Eventos data = await Get(eventos.id);


            // if (eventos.latitud.ToString() != "" && eventos.latitud.ToString() != null)
            if (eventos.latitud != "" && eventos.latitud != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.pos_evento.lat, Convert.ToDouble(eventos.latitud)));
            }

            if (eventos.longitud != "" && eventos.longitud != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.pos_evento.lng, Convert.ToDouble(eventos.longitud)));
            }
            if (eventos.altura != "" && eventos.altura !=null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.pos_evento.alt, Convert.ToDouble(eventos.altura)));
            }


            var aaaa = double.Parse("10");
            var aas= Convert.ToDouble(1);

            if (eventos.head != "" && eventos.head != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.camera_pose.head, Convert.ToDouble(eventos.head)));
            }
            if (eventos.pitch !="" && eventos.pitch != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.camera_pose.pitch, Convert.ToDouble(eventos.pitch)));
            }
            if (eventos.roll != "" && eventos.roll != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.camera_pose.roll, Convert.ToDouble(eventos.roll)));
            }








            if (eventos.fileimg_evento != null)
            {
                if(_subirFile.defaultdelete("img", eventos.id, eventos.id))
                {
                    UploadFile fileimg_evento = await _subirFile.defaultAdd("img", eventos.id, eventos.id, eventos.fileimg_evento);
                    if (fileimg_evento.status)
                    {
                        updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.img_evento, fileimg_evento.urlFile));
                    }
                }
            }



            

            if (eventos.file_antes != null)
            {
                if (_subirFile.imgMapaDelete(eventos.id, data.img_aerea.url_antes))
                {
                    UploadFile file_antes = await _subirFile.imgMapaAdd(eventos.id, ObjectId.GenerateNewId().ToString(), eventos.file_antes);
                    if (file_antes.status)
                    {
                        updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.img_aerea.url_antes, file_antes.urlFile));
                    }
                }
            }

            if (eventos.file_despues != null)
            {
                if (_subirFile.imgMapaDelete(eventos.id, data.img_aerea.url_despues))
                {
                    UploadFile url_despues = await _subirFile.imgMapaAdd(eventos.id, ObjectId.GenerateNewId().ToString(), eventos.file_despues);
                    if (url_despues.status)
                    {
                        updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.img_aerea.url_despues, url_despues.urlFile));
                    }
                }
            }
            if (eventos.addescripcion != "" && eventos.addescripcion != null)
            {
                updatePinteres.Add(Builders<Eventos>.Update.Set(p => p.img_aerea.descripcion, eventos.addescripcion));
            }




            if (eventos.oneFileaudio != null) {

                if (_subirFile.defaultdelete("aud", eventos.id, data.audio_camara[0]))
                {
                    UploadFile FileAudione = await _subirFile.defaultAdd("aud", eventos.id, ObjectId.GenerateNewId().ToString(), eventos.oneFileaudio);
                    if (FileAudione.status)
                    {
                        var dataudio = data.audio_camara;
                        dataudio[0] = FileAudione.urlFile;
                        updatePinteres.Add(Builders<Eventos>.Update.Set("audio_camara", dataudio));
                    }    
                }

            }
            if (eventos.twoFileaudio != null) {

                if (_subirFile.defaultdelete("aud", eventos.id, data.audio_camara[1]))
                {
                    UploadFile FileAudiotwo = await _subirFile.defaultAdd("aud", eventos.id, ObjectId.GenerateNewId().ToString(), eventos.twoFileaudio);
                    if (FileAudiotwo.status)
                    {
                        var dataudio = data.audio_camara;
                        dataudio[1] = FileAudiotwo.urlFile;
                        updatePinteres.Add(Builders<Eventos>.Update.Set("audio_camara", dataudio));
                    }
                }
            }


            if (eventos.oneFileimg != null) {

                if (_subirFile.defaultdelete("img", eventos.id, data.img_camara[0]))
                {
                    UploadFile oneFileimg = await _subirFile.defaultAdd("img", eventos.id, ObjectId.GenerateNewId().ToString(), eventos.oneFileimg);
                    if (oneFileimg.status)
                    {

                        var dataimg = data.img_camara;
                        dataimg[0] = oneFileimg.urlFile;
                        updatePinteres.Add(Builders<Eventos>.Update.Set("img_camara", dataimg));
                    }
                }

            }
            if (eventos.twoFileimg != null)
            {
                if (_subirFile.defaultdelete("img", eventos.id, data.img_camara[1]))
                {
                    UploadFile twoFileimg = await _subirFile.defaultAdd("img", eventos.id, ObjectId.GenerateNewId().ToString(), eventos.twoFileimg);
                    if (twoFileimg.status)
                    {
                        var dataimg = data.img_camara;
                        dataimg[1] = twoFileimg.urlFile;
                        updatePinteres.Add(Builders<Eventos>.Update.Set("img_camara", dataimg));
                    }

                }
            }

            var update = Builders<Eventos>.Update.Combine(updatePinteres);
            await _Eventos.UpdateOneAsync(filter, update);
        }

        


        public async Task Delete(string id)
        {
            Eventos evento = await Get(id);
             _subirFile.defaultdelete("aud", id,id);
             _subirFile.defaultdelete("img", id,id);
             _subirFile.imgMapaDelete(id, "antes");
             _subirFile.imgMapaDelete(id, "despues");
            var filter = Builders<Eventos>.Filter.Eq(s => s.id, new string(id));
            await _Eventos.DeleteOneAsync(filter);
        }

    }
}