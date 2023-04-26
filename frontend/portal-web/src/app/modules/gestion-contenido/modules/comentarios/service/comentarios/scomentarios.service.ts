import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { comentario,comentarioDTO  } from '../../model/comentarios';

@Injectable({
  providedIn: 'root'
})
export class scomentariosService {

  _url = "http://localhost:37539/api/Comentario/"
  constructor(private http: HttpClient) { }

  getComentarios(id:string){
    return this.http.get<comentario[]>(this._url ,{params:{id}})
  }
  postComentario(id:string, comentario:comentarioDTO){
    return this.http.post(this._url,comentario,{params:{id}})
  }
  deleteComentario(id:string,id_comentario:string){
    return this.http.delete(this._url,{params:{id,id_comentario}})
  }
  aprobarComentario(id:string,id_comentario:string){
    return this.http.post(this._url,{params:{id,id_comentario}})
  }


}
