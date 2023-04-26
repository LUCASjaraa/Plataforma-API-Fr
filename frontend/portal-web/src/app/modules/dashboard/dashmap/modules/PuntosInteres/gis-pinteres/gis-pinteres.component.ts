import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Pos_evento } from '../../../models/map';
import { pigis } from '../models/pigis';
import { GisPinteresService } from '../service/gis-pinteres/gis-pinteres.service';

@Component({
  selector: 'app-gis-pinteres',
  templateUrl: './gis-pinteres.component.html',
  styleUrls: ['./gis-pinteres.component.scss']
})
export class GisPinteresComponent implements OnInit {
  @Input() id= ""
  @Input() posPinters:Pos_evento={
    lat: 0,
    lng: 0,
    alt: 0}

  @Output() cambio = new EventEmitter()

  data:pigis={
    titulo:"",
    cDatosInteres :0,
    cGaleria :0,
    cComentarios :0,
    cRelatos :0,
    cValoraciones:0,
    cMemoria :0,
    cVisitas :0
  };

  constructor(private gisPinteresService:GisPinteresService) { }

  ngOnInit(): void {
    this.gisPinteresService.getEstGis(this.id)
        .subscribe(elemts=>{this.data= elemts})
  }
  ngCambiar(){this.cambio.emit({
    mapLatitude: this.posPinters.lat,
    mapLongitude: this.posPinters.lng,
    mapZoom: 15
    })}
}
