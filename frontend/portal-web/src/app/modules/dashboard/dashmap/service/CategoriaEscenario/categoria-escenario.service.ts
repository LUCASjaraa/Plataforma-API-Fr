import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CategoriaEvento } from '../../models/categoriaEvento';

@Injectable({
  providedIn: 'root'
})
export class CategoriaEscenarioService {
  _url  ="http://localhost:37539/api/CategoriaEvento";
  constructor(private http:HttpClient) { }

  getallCategoriaEventos(){
    return this.http.get<CategoriaEvento[]>(this._url+"/all");
  }
  getCategoriaEventos(id:string){

    return this.http.get<CategoriaEvento[]>(this._url ,{params:{id}});
  }

}
