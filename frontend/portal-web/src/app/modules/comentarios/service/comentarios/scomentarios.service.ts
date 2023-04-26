import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { comentarios } from '../../model/comentarios';
@Injectable({
  providedIn: 'root'
})
export class scomentariosService {

  _url = "https://164.77.114.239:8129/api/Comentario/"
  constructor(private http: HttpClient) { }

  getComentarios(id:string){
    return this.http.get<comentarios[]>(this._url + id)
  }

}
