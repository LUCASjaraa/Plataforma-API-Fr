import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { galeria } from '../model/galeria';

@Injectable({
  providedIn: 'root'
})
export class SgaleriaService {


  _url = "http://localhost:37539/api/Galeria/"

  _urlAdd = "http://localhost:37539/api/Galeria/add/imagen"
  _urlAddv = "http://localhost:37539/api/Galeria/add/video"
  _urlAprobar = "http://localhost:37539/api/Galeria/add/video"



  constructor(private http:HttpClient) { }

  getGaleria(id:string){
    return this.http.get<galeria[]>(this._url, {params:{id}});
  }

  postGaleriaI(id:string, formData:FormData){

    return this.http.post(this._url+"add/imagen",formData,{params:{id}})
  }
  postGaleriaV(id:string, formData:FormData){
    return this.http.post(this._url+"add/video",formData,{params:{id}})
  }

  deleteGaleria(id:string,id_galeria:string){
    console.log(id,id_galeria)
    return this.http.delete(this._url,{params:{id,id_galeria}})
  }

  aprobarGaleria(id:string,id_galeria:string){
    console.log(this._url+"Aprobar",{params:{id,id_galeria}});
    return this.http.post(this._url+"Aprobar",{params:{id,id_galeria}});
  }

}
