import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { puntosinteres, CreatetDTO } from '../../model/puntointeres';
@Injectable({
  providedIn: 'root'
})

export class PuntosinteresService {


  _url= "http://localhost:37539/api/portal/page/puntosInteres/";
  _urlCreate= "http://localhost:37539/api/eventos";

  constructor(private http: HttpClient) { }

  getPuntoInteres(id_Escenario:string){

    return this.http.get<puntosinteres[]>(this._url, {params : {id_Escenario}})
  }

  addPuntoInteres(formData:FormData){

    return this.http.post(this._urlCreate, formData)
  }



/*
  subirArchivo(formData:FormData){
    return this.http.post<sarchivo>(this._url, formData)
  }
*/

}
