import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { pigis } from '../../models/pigis';

@Injectable({
  providedIn: 'root'
})
export class GisPinteresService {
  _url = "http://localhost:37539/api/portal/page/PIgis";
  constructor(private http:HttpClient) { }

  getEstGis(id:string){
    return this.http.get<pigis>(this._url,{params:{id}});
  }
}


