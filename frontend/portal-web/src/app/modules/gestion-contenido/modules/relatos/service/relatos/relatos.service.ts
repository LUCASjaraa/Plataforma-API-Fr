import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { relato } from '../../model/relatos';

@Injectable({
  providedIn: 'root'
})
export class RelatosService {

  _url = "http://localhost:37539/api/relato/"
  constructor(private http:HttpClient) {
   }

   getRelatos(id:string){
    return this.http.get<relato[]>(this._url ,{params:{id}});
   }
   postRelato(id:string,formData:FormData){
    return this.http.post(this._url ,formData,{params:{id}});
   }
   deleteRelato(id:string,id_relato:string){
    return this.http.delete(this._url,{params:{id,id_relato}});
   }
   aprobarRelato(id:string,id_relato:string){
    return this.http.post(this._url+"Aprobar" ,{params:{id,id_relato}});

   }

}
