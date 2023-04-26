import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { usuario } from '../../model/usuario';

@Injectable({
  providedIn: 'root'
})

export class UsuariosService {
  _url = "http://localhost:37539/api/UsuarioApp";
  constructor(private http:HttpClient) { }

  getUsuario(id:string ){
    return this.http.get<usuario>(`${this._url}`, {
      params: {id}
    })
  }

}
