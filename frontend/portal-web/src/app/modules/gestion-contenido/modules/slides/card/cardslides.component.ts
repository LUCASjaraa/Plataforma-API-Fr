import { Component, Input, OnInit } from '@angular/core';
import { slides } from '../model/slides';

@Component({
  selector: 'app-cardslides',
  templateUrl: './cardslides.component.html',
  styleUrls: ['./cardslides.component.scss']
})
export class CardslidesComponent implements OnInit {
  @Input() slides:slides={
    usuario_id   : "",
    slide_id     : "",
    titulo       : "",
    img          : [],
    fechas       : [],
    descripciones: [],
    likes        : [],
    fecha_subida : [],
    aceptado:false,
  }
  tipos:string[]=["Antes", "Durante" ,"Justo Despues" ,"Ahora"]
  constructor() { }

  ngOnInit(): void {
  }

}
