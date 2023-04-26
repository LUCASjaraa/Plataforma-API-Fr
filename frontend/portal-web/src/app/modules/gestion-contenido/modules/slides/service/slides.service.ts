import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { slides } from '../model/slides';

@Injectable({
  providedIn: 'root'
})
export class SlidesService {
_url = "http://localhost:37539/api/slides"
constructor(private http:HttpClient) { }

getSlides(id:string){
  return this.http.get<slides[]>(this._url,{params:{id}})
}
addSlides(id:string,formData:FormData){
  console.log(id)
  return this.http.post(this._url,formData,{params:{id}})
}

}
