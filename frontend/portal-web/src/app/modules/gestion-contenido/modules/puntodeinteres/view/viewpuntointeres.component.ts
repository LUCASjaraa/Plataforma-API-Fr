import { Component, Input, OnInit } from '@angular/core';
import { puntosinteres } from '../model/puntointeres';
import { PuntosinteresService } from '../service/puntosinteres/puntosinteres.service';
@Component({
  selector: 'app-viewpuntointeres',
  templateUrl: './viewpuntointeres.component.html',
  styleUrls: ['./viewpuntointeres.component.scss']
})
export class ViewpuntointeresComponent implements OnInit {
  isDisplay = true;
  @Input() puntoIntres:puntosinteres = {
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
  constructor(private puntosinteresService : PuntosinteresService){}

  ngOnInit(): void {}

  ngUpdatePinters(id:string):void{

  }

  toggleDisplay(){
    this.isDisplay = !this.isDisplay;
  }

}
