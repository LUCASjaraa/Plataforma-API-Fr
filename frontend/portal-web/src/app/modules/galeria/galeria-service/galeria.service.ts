import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { galerias } from '../model/galeria';

@Injectable({
  providedIn: 'root'
})
export class GaleriaService {

  _urlGaleriaGeneral:string    = "https://164.77.114.239:8129/api/galeria/all"
  _urlGaleriaEspecifica:string = "https://164.77.114.239:8129/api/galeria/"

  constructor(private http: HttpClient) { }

  getGaleriaGeneral() {
    return this.http.get<galerias[]>(this._urlGaleriaGeneral)
  }

  getGaleriaEspecifica(id:string | undefined) {
    return this.http.get<galerias[]>(this._urlGaleriaEspecifica + id)
  }
  
}
