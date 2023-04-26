import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from '../models/map'
@Injectable({
  providedIn: 'root'
})
export class MapService {

  _url = "http://localhost:37539/api/app/page/mappins"
  constructor(private http: HttpClient) { }

  getPoints(){
    return this.http.get<map[]>(this._url)
  }


}
