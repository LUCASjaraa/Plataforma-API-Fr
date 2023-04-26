import { Component, Input, OnInit } from '@angular/core';
import { escenario, viewEscenario } from '../model/escenario';
import { PuntosinteresService } from '../../puntodeinteres/service/puntosinteres/puntosinteres.service';
import { puntosinteres } from '../../puntodeinteres/model/puntointeres';


@Component({
  selector: 'app-viewescenarios',
  templateUrl: './viewescenarios.component.html',
  styleUrls: ['./viewescenarios.component.scss']
})
export class ViewescenariosComponent implements OnInit {
  isDisplay = true;
  isEscenario=true;
  isPinteres=true;
  showFiller = true;
  numbrePintes = 0;
  recargarPi : number= 0;

  @Input() dataEscenario:escenario={
    id: "",
    titulo: "",
    short_descrip : "",
    long_descrip: "",
    ciudades: [""],
    slides : [
      {
      slide_id:"",
      titulo:"",
      img_url:"",
      fecha:""
    }],
    lat_long:[{
      lat: 0,
      lng: 0,
    }]
  }

  pIntres:puntosinteres[] = [];
  constructor(private puntosinteresService : PuntosinteresService) { }


  ngOnInit(): void {
    this.puntosinteresService.getPuntoInteres(this.dataEscenario.id)
    .subscribe(data =>{
      this.pIntres = data;

    })
  }
  toggleDisplay(){
    this.isDisplay = !this.isDisplay;
  }
  toggleEdit(){
    this.isEscenario = !this.isEscenario;
  }

  toggleAddEscenario(){
    this.isPinteres = !this.isPinteres;

  }
  changePinteres(data:number){
    this.numbrePintes = data;
    this.recargarPi = this.recargarPi * -1 + 1 ;


  }

}

