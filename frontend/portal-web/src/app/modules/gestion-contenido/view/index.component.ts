import { Component, OnInit } from '@angular/core';
import { escenario } from '../modules/escenario/model/escenario';
import { puntosinteres } from '../modules/puntodeinteres/model/puntointeres';
import { EscenarioService } from '../modules/escenario/service/escenario/escenario.service';

import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';


export interface User {
  name: string;
}
@Component({
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  addtogle = true;
  btndata:string="Agregar Escenario";
  lEscenarios : escenario[]  = [];
  pInteres : puntosinteres[] = [];
  options:string[]=[]

  constructor(private escenarioService : EscenarioService) {
  }

  ngOnInit(): void {

    this.escenarioService.getEscenarios()
    .subscribe(data =>{
      this.lEscenarios = data;
      data.map(data=>this.options.push(data.titulo));
      }
    )
  }
  addEscenario(){
    console.log(this.lEscenarios)
    this.addtogle = !this.addtogle;
    this.btndata="cerrar"
    if(this.addtogle){this.btndata="Agregar Escenario"}
  }

}
