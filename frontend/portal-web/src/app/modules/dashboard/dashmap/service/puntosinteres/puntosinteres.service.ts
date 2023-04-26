import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { puntosinteres } from '../../models/puntointeres';
@Injectable({
  providedIn: 'root'
})

export class PuntosinteresService {

  _url = "http://localhost:37539/api/portal/page/puntosInteres/";

  constructor(private http: HttpClient) { }

  getPuntoInteres(id_Escenario:string){

    return this.http.get<puntosinteres[]>(this._url,{params:{id_Escenario}})
  }


}
