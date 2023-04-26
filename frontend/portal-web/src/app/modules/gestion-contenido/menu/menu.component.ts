import { Component, Input, OnInit } from '@angular/core';
import { puntosinteres } from '../modules/puntodeinteres/model/puntointeres';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  @Input() mPuntoIntres:puntosinteres = {
    id           : "",
    escenario_id : "",
    categoria    : "",
    titulo       : "",
    descripcion  : "",
    zona         : "",
    fecha        : "",
    audio        : "",
    img_evento   : "",
    pos_evento  :  {
      lat : 0,
      lng : 0,
      alt : 0,
    },
    camera_pose :  {
      head : 0,
      pidch: 0,
      roll : 0,
    }
  };
  constructor() { }

  ngOnInit(): void {
    //this.mPuntoIntres = this.mPuntoIntres;
  }

}
