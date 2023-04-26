import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/service/api/api.service';
import { galeria } from '../model/galeria';
import { GaleriaService } from '../galeria-service/galeria.service';

@Component({
  selector: 'app-galeria',
  templateUrl: './galeria.component.html',
  styleUrls: ['./galeria.component.scss']
})
export class GaleriaComponent implements OnInit {

  galeriaListEspecifica:galeria[] = [];


  constructor(private apiService    :ApiService,
              private galeriaService:GaleriaService) {}

  ngOnInit(): void {
    this.getInfoGaleria();
  }

  getInfoGaleria() {
    let id = this.apiService.contenido
    this.galeriaService.getGaleriaEspecifica(id)
    .subscribe(data => {
      let contenido = data
      for (let element of contenido) {
        for (let galeria of element.galeria) {
          this.galeriaListEspecifica.push(galeria)
        }
      }
      console.log(this.galeriaListEspecifica)
      
    })

  }


}
