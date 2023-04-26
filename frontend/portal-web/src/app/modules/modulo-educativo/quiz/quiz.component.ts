import { Component, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { QuestionService } from '../service/question.service';
import { Quiz } from '../quiz';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {

  public nombre: string = "";
  public dif: any = "";
  public preguntasList: any = [];
  public preguntaActual: number = 0;
  public puntaje: number = 0;
  public cantRespondida: number = 0;
  contador2 = 20;
  contador = this.contador2;
  respuestaCorrecta: number = 0;
  respuestaIncorrecta: number = 0;
  interval$: any;
  progreso: string = "0";
  isQuizCompleted : boolean = false;
  constructor(private questionService: QuestionService) { }

  ngOnInit(): void {
    // this.nombre = localStorage.getItem("name")!;
    // this.dif = localStorage.getItem("dif");
    this.nombre = this.questionService.nombre;
    this.dif = this.questionService.dificultad;
    console.log(this.dif, "dif quiz", this.nombre);
    if(this.dif === "Facil")      {this.contador2 = 20}
    if(this.dif === "Intermedio") {this.contador2 = 15
                                   this.contador  = 15}
    if(this.dif === "Dificil")    {this.contador2 = 10
                                   this.contador  = 10}
    this.getAllPreguntas();
    this.startCounter();
  }
  getAllPreguntas() {
    this.questionService.getQuestionJson()
      .subscribe(res => {
        // this.preguntasList = res.preguntas; 
         this.preguntasList = res[0].preguntas;   //Aqui se modifica el elemento que se necesita del Json
        // console.log(res[0].preguntas);
      })
  }
  nextQuestion() {
    this.preguntaActual++;
  }
  previousQuestion() {
    this.preguntaActual--;
  }
  answer(currentQno: number, option: any) {

    if(currentQno === this.preguntasList.length){
      this.isQuizCompleted = true;
      this.stopCounter();
    }
    if (option.correcto) {
      this.puntaje += 10;
      this.respuestaCorrecta++;
      this.cantRespondida ++;
      setTimeout(() => {
        this.preguntaActual++;
        this.resetCounter();
        this.getProgressPercent();
      }, 1000);


    } else {
      setTimeout(() => {
        this.preguntaActual++;
        this.respuestaIncorrecta++;
        this.cantRespondida ++;
        this.resetCounter();
        this.getProgressPercent();
      }, 1000);

      this.puntaje -= 10;
    }
  }
  startCounter() {
    this.interval$ = interval(1000)
      .subscribe(val => {
        this.contador--;
        if (this.contador === 0) {
          // prueba
          if(this.preguntaActual +1  === this.preguntasList.length){
            console.log("pregActual", this.preguntaActual);
            this.isQuizCompleted = true;
            this.stopCounter();
          }
          
          this.preguntaActual++;
          this.contador = this.contador2;
          this.puntaje -= 10;
        }
      });
    setTimeout(() => {
      this.interval$.unsubscribe();
    }, 600000);
  }
  stopCounter() {
    this.interval$.unsubscribe();
    this.contador = 0;
  }
  resetCounter() {
    this.stopCounter();
    this.contador = this.contador2;
    this.startCounter();
  }
  resetQuiz() {
    this.resetCounter();
    this.getAllPreguntas();
    this.puntaje = 0;
    this.contador = this.contador2;
    this.preguntaActual = 0;
    this.progreso = "0";

  }
  getProgressPercent() {
    this.progreso = ((this.preguntaActual / this.preguntasList.length) * 100).toString();
    return this.progreso;

  }

}
