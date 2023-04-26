import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { pcategoria } from '../../model/pcategoria';

@Injectable({
  providedIn: 'root'
})
export class PcategoriaService {

  _url = "http://localhost:37539/api/CategoriaEvento/all"
  constructor(private  http:HttpClient) { }

  getPcategoria(){
    return this.http.get<pcategoria[]>(this._url)
  }
}
