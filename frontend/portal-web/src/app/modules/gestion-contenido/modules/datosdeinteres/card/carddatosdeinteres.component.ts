import { Component, Input, OnInit } from '@angular/core';
import {  datointeres } from '../model/datointeres';
import { DatointeresService } from '../service/datointeres/datointeres.service';

@Component({
  selector: 'app-carddatosdeinteres',
  templateUrl: './carddatosdeinteres.component.html',
  styleUrls: ['./carddatosdeinteres.component.scss']
})
export class CarddatosdeinteresComponent implements OnInit {
  @Input() datosdeinteres:datointeres=
                {
                  interes_id: "",
                  titulo: "",
                  descripcion: ""
                }

  constructor(private datointeresService:DatointeresService) { }

  ngOnInit(): void {
  }

}
