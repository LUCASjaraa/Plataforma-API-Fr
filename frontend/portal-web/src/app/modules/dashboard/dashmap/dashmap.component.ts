import { MapType } from '@angular/compiler';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MapService } from './service/map.service';
import { map } from './models/map'
import { FormArray, FormBuilder, FormControl, FormGroup,Validators } from '@angular/forms';
import { ApiService } from '../../../service/api/api.service';
import { escenario } from './models/escenario';

import { EscenariosService } from './service/Escenario/escenarios.service';
import { PuntosinteresService } from './service/puntosinteres/puntosinteres.service';

import { puntosinteres } from './models/puntointeres';
import { CategoriaEvento } from './models/categoriaEvento';
import { CategoriaEscenarioService } from './service/CategoriaEscenario/categoria-escenario.service';
import { zoom } from './modules/PuntosInteres/models/pointmap';

@Component({
  selector: 'app-dashmap',
  templateUrl: './dashmap.component.html',
  styleUrls: ['./dashmap.component.scss']
})



export class DashmapComponent implements OnInit {

  @Output() mapData = new EventEmitter<string>();
  zoom:zoom = {
    mapLatitude: -33.45694,
    mapLongitude: -70.64827,
    mapZoom: 5
  }



  origin = { lat: -33.04222, lng: -71.37333 };


  pointsMap: map[] = [];
  escenariosID!:FormGroup;
  Escenarios :escenario[] = [];
  PuntosInteres:puntosinteres[]=[];
  cPuntosInteres :puntosinteres[]=[];
  CategoriaEvento:CategoriaEvento[]=[];
  iCategoriaEvento:CategoriaEvento[]=[];
  icon:string="";

  constructor(
    private readonly fb:FormBuilder,
    private mapSeervice : MapService,
    private escenarios:EscenariosService,
    private puntosinteres:PuntosinteresService,
    private categoriaE:CategoriaEscenarioService,
  ) { }

  ngOnInit(): void {
    this.escenariosID = this.initForm();
    this.categoriaE.getallCategoriaEventos().subscribe(data=>{ this.CategoriaEvento = data})
    this.mapSeervice.getPoints().subscribe(data =>{this.pointsMap = data;})

    this.escenarios.getEscenarios()
    .subscribe(data=>{this.Escenarios = data;this.escenariosID.patchValue({escenario_id:this.Escenarios[0].id})

    this.puntosinteres.getPuntoInteres(this.Escenarios[0].id).subscribe(data=>{this.PuntosInteres=data; this.cPuntosInteres=data})})
  }

  initForm():FormGroup{
    return this.fb.group({
      escenario_id:['',[Validators.required]],
      selec:[true],
      categorias:this.buildcatastrofes()
    })
  }

  onChange(event:Event){
    this.puntosinteres.getPuntoInteres(String(event))
    .subscribe(data=>{this.PuntosInteres=data;this.cPuntosInteres=data})

    this.zoom =  {
      mapLatitude: -33.45694,
      mapLongitude: -70.64827,
      mapZoom: 5
    }

  }

  Icons(id:string):string{
    var lucas = this.CategoriaEvento.find(a=>a.id ===id)
    return String(lucas?.icon)
  }

  hola(x:string | undefined) {
    this.mapData.emit(x);
  }

  catastrofes = ["Incendio","Terremoto","Tsunami","Inundación","Sequía"]
  buildcatastrofes(){
    const value= this.catastrofes.map(v => new FormControl(true))
    return this.fb.array(value)
  }

  onChangeSelects(event:Event, id:string){
    if(event){
      this.cPuntosInteres.filter(item => item.categoria == id).map(x=> this.PuntosInteres.push(x))
    }
    else {this.PuntosInteres = this.PuntosInteres.filter((item) => item.categoria !== id)}
  }


  ngCambioZoom(Event:zoom){
    this.zoom=Event
    console.log(this.zoom.mapZoom)
    console.log(Event.mapZoom)
  }





  zoomChange(e:number):number{
    this.zoom.mapZoom = e
    this.zoom.mapLatitude =  this.zoom.mapLatitude
    this.zoom.mapLongitude = this.zoom.mapLongitude
    console.log(e,this.zoom.mapLatitude,this.zoom.mapLongitude )
    //this.zoom.mapZoom = this.zoom.mapZoom - e
    return e
  }

}
