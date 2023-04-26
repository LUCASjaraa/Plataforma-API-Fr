import { Component, Input, OnInit } from '@angular/core';
import { memoria } from '../model/memoria';

@Component({
  selector: 'app-cardmemoria',
  templateUrl: './cardmemoria.component.html',
  styleUrls: ['./cardmemoria.component.scss']
})
export class CardmemoriaComponent implements OnInit {
  @Input() memoria:memoria={
    usuario_id : "",
    memoria_id : "",
    titulo     : "",
    img    : [],
    fechas     : []
  }
  constructor() { }

  ngOnInit(): void {
  }

}
