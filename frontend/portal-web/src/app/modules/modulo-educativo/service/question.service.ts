import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Quiz } from '../quiz';
@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  nombre:     string = "";
  dificultad: string = "Facil";
  url: string = "http://localhost:37539/api/moduloeducativo/all"

  constructor(private http : HttpClient) { }

  getQuestionJson(){
    //  return this.http.get<any>("assets/preguntas.json");
    return this.http.get<any>(this.url);

  }
}
