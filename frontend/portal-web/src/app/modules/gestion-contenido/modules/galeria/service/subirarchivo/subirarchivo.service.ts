import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { sarchivo } from '../../model/sarchivo';

@Injectable({
  providedIn: 'root'
})
export class SubirarchivoService {




 _url = "https://164.77.114.239:8129/api/galeria/imagen/632a2d8030305800b2d85225";
  constructor(private http: HttpClient) { }

  subirArchivo(formData:FormData){
    return this.http.post<sarchivo>(this._url, formData)
  }

}
