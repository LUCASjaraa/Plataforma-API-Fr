import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { memoria } from '../model/memoria';

@Injectable({
  providedIn: 'root'
})
export class MemoriaService {

  _url ="http://localhost:37539/api/Memoria/";
  constructor(private http:HttpClient) { }

  getMemroria(id:string){
    return this.http.get<memoria[]>(this._url, {params:{id}})
  }
}
