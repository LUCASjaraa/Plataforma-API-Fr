import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { usuario } from '../../model/usuario';

@Injectable({
  providedIn: 'root'
})

export class UsuariosService {
  _url = "https://164.77.114.239:8129/api/UsuarioApp/"
  constructor(private http:HttpClient) { }

  getUsuario(id:string | unknown){
    return this.http.get<usuario[]>(this._url + id)
  }

}
