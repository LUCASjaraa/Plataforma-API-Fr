import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { datointeres ,datointeresDTO} from '../../model/datointeres';

@Injectable({
  providedIn: 'root'
})
export class DatointeresService {

  _url = "http://localhost:37539/api/DatosInteres/";
  constructor(private http:HttpClient) { }

  getdatointeres(id:string){
    return this.http.get<datointeres[]>(this._url ,{params:{id}})
  }

  addDatointeres(id:string,datoInteres:datointeresDTO){
    return this.http.post(this._url,datoInteres,{params:{id}});

  }
}
