import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { escenario } from '../../models/escenario';

@Injectable({
  providedIn: 'root'
})
export class EscenariosService {
  _url = "http://localhost:37539/api/Escenario/all";
  constructor(private http:HttpClient) { }
  getEscenarios(){
    return this.http.get<escenario[]>(this._url)
  }
}
