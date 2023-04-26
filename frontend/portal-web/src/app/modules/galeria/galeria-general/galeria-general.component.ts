import { Component, OnInit } from '@angular/core';
import { galeria } from '../model/galeria';
import { GaleriaService } from '../galeria-service/galeria.service';

@Component({
  selector: 'app-galeria-general',
  templateUrl: './galeria-general.component.html',
  styleUrls: ['./galeria-general.component.scss']
})
export class GaleriaGeneralComponent implements OnInit {
 
  galeriaListGeneral:galeria[] = []


  constructor(private galeriaService:GaleriaService) {

   }

  ngOnInit(): void {
    this.getInfoGaleria();
  }

  getInfoGaleria() {
    this.galeriaService.getGaleriaGeneral()
    .subscribe(data => {
      let contenido = data
      for (let element of contenido) {
        for (let galeria of element.galeria) {
          this.galeriaListGeneral.push(galeria)
        }
      }
      console.log(this.galeriaListGeneral)
      
    })

  }
}
