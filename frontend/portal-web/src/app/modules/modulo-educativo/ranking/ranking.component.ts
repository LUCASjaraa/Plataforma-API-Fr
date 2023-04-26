import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss']
})
export class RankingComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  flagFacil: boolean = true;
  flagMedio: boolean = false;
  flagDificil: boolean = false;


  async cambioSegment(value: string){
    if(value == '1'){
      console.log('nivel facil');
      this.flagFacil = true;
      this.flagMedio = false;
      this.flagDificil = false;
    }

    if(value == '2'){
      console.log('nivel medio');
      this.flagFacil = false;
      this.flagMedio = true;
      this.flagDificil = false;
    }

    if(value == '3'){
      console.log('nivel dificil');
      this.flagFacil = false;
      this.flagMedio = false;
      this.flagDificil = true;
    }
  }

}
