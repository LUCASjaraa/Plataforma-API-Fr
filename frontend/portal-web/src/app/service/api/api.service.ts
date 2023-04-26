import { Injectable } from '@angular/core';
// import { datos } from 'app/datos';
import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { datos } from '../../shared/models/datos';
import { __param } from 'tslib';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
 //  _url = "https://localhost:5001/api/Marcadores/"

 _urlBase = "http://localhost:37539/"
 _urlEscenario = "http://localhost:37539/api/Escenario/all"
 _url = "https://164.77.114.239:8129/api/Eventos/"
 contenido = "all"
 mapId:string | undefined = ""

 _urlInfoVisitas:string = "http://localhost:37539/api/portal/page/visitas"

 _urlInfoDona:string = "http://localhost:37539/api/portal/page/puntosInteres/"

 _urlInfoCategoria:string = "http://localhost:37539/api/CategoriaEvento/all"

 _urlInfoPie:string = "http://localhost:37539/api/portal/page/caPuntosInteres"


 _urlEstadisticaEscenario:string = "http://localhost:37539/api/portal/page/cr/escenario"


 _urlEstadisticaPInteres:string = "http://localhost:37539/api/portal/page/cr/all"

 _urlEstadisticaTop:string = "http://localhost:37539/api/portal/page/top?id=5"

 _urlInfoModuloEd:string = "http://localhost:37539/api/InfoModuloEducativo/all"

 _urlInfoDatosInteres:string="http://localhost:37539/api/portal/page/datos_interes/all"

 _urlUser = "http://localhost:37539/api/UsuarioApp"

  constructor(private http: HttpClient)
{

}

getInformacion()
{
  return this.http.get(this._url)
}
getInformacionC()
{
  // const headers= new HttpHeaders()
  // .set('content-type', 'application/json')
  // .set('Access-Control-Allow-Origin', '*');
  return this.http.get<any>(this._url + this.contenido)
}
getInfoEvento(id:string)
{
  return this.http.get<datos[]>(this._url + id)
}

getInfoUsuario(id:string)
{
  return this.http.get<any[]>(this._urlUser,{params:{id}})
}

deleteInformacion(id:string | undefined) {
  return this.http.delete(this._url + id)}

addInformacion(info: datos) {
  return this.http.post<datos>(this._url, info)}

updateMarcador(info:datos){
  return this.http.put<datos>(this._url, info)}




  getInfoEscenario() {
    return this.http.get<any[]>(this._urlEscenario)
  }

  getInfoVisitas(id:string) {
    return this.http.get<any[]>(this._urlInfoVisitas,{params:{id}})
  }

  getInfoDona(id:string ) {
    return this.http.get<any[]>(this._urlInfoDona, {params:{id}})
  }

  getInfoCategoria() {
    return this.http.get<any[]>(this._urlInfoCategoria)
  }


  getInfoPie(id:string ) {
    return this.http.get<any[]>(this._urlInfoPie,{params:{id}})
  }



  getEstadisticaEscenario(id:string){
    return this.http.get<any[]>(this._urlEstadisticaEscenario,{params:{id}})
  }

  getEstadisticaPInteres() {
    return this.http.get<any[]>(this._urlEstadisticaPInteres)
  }

  getEstadisticaTop() {
    return this.http.get<any[]>(this._urlEstadisticaTop)
  }

  getInfoModuloEducativo() {
    return this.http.get<any[]>(this._urlInfoModuloEd)
    // return this.http.get("assets/mod-educativo.json")
  }

  getInfoDatosInteres() {
    return this.http.get<any[]>(this._urlInfoDatosInteres)
  }
}



