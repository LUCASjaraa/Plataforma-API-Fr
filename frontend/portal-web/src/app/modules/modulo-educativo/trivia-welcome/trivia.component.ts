import { Component, OnInit,ViewChild,ElementRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { QuestionService } from '../service/question.service';

@Component({
  selector: 'app-trivia',
  templateUrl: './trivia.component.html',
  styleUrls: ['./trivia.component.scss']
})
export class TriviaComponent implements OnInit {

  form: FormGroup;
  dif: any = ""
  nombre= new FormControl('');
  nom: any = ""  

  // @ViewChild('name') nameKey!: ElementRef;
  constructor(private fb: FormBuilder, 
              private questionService: QuestionService) {
    this.form = this.fb.group({
      dif: "Facil"
    })  
   }

  ngOnInit(): void {
  }

  startQuiz(){
    // localStorage.setItem("name",this.nameKey.nativeElement.value);
    //console.log(this.nameKey.nativeElement.value);
    console.log(this.nombre.value)
    this.nom = this.nombre.value
    this.dif = this.form.controls['dif'].value;
    // localStorage.setItem("dif",this.dif.nativeElement.value);
    // console.log(this.dif);
    this.questionService.dificultad = this.dif
    this.questionService.nombre = this.nom;
    // this.questionService.nombre = this.nameKey.nativeElement.value;

  }


}
