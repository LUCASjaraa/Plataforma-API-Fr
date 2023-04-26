import { Component, Input, OnInit } from '@angular/core';
import { datointeres } from '../model/datointeres';
import { DatointeresService } from '../service/datointeres/datointeres.service';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-viewdatosdeinteres',
  templateUrl: './viewdatosdeinteres.component.html',
  styleUrls: ['./viewdatosdeinteres.component.scss']
})
export class ViewdatosdeinteresComponent implements OnInit {
  @Input() id:string = "";
  vdatosinteres:boolean =true;
  page_zise : number = 2;
  page_number:number = 1;
  datosinteres:datointeres[]=[]

  constructor(private datointeresService:DatointeresService) { }

  ngOnInit(): void {
    this.datointeresService.getdatointeres(this.id)
    .subscribe(data=>{
      this.datosinteres =data;
    })
  }
  handlePage(e:PageEvent){
    this.page_zise   = e.pageSize;
    this.page_number = e.pageIndex + 1
  }

  addDinteres(){
    this.vdatosinteres =!this.vdatosinteres;
  }

}
