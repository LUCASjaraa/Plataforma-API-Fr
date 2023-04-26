import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { escenario, AddEscenario, addSlide,addescenario } from '../../model/escenario';
@Injectable({
  providedIn: 'root'
})
export class EscenarioService {


  //_url = "https://localhost:5002/api/escenario"
  _url = "http://localhost:37539/api/Escenario"


  constructor(private http: HttpClient) { }

  getEscenarios(){
    return this.http.get<escenario[]>(this._url+"/all")
  }
  editEscenario(){}

  addEscenario( formData:FormData){
    return this.http.post(this._url, formData)
  }

  addEscenarios( formData:addescenario){
    return this.http.post(this._url, formData)
  }
  deleteEscenario(){}
}





