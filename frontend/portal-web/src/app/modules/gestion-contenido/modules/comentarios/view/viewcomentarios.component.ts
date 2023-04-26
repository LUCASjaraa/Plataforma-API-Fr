import { Component, Input, OnInit } from '@angular/core';
import { comentario } from '../model/comentarios';
import {scomentariosService} from '../service/comentarios/scomentarios.service';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-viewcomentarios',
  templateUrl: './viewcomentarios.component.html',
  styleUrls: ['./viewcomentarios.component.scss']
})

export class ViewcomentariosComponent implements OnInit {
  @Input() id:string = ""
  page_zise : number = 2;
  page_number:number = 1;
  vcomentarios:boolean = true;
  comentarios:comentario[] = []




  constructor(
    private comentariosService:scomentariosService
    ) {  }

  ngOnInit(): void {
    this.comentariosService.getComentarios(this.id)
    .subscribe(data=>{
      this.comentarios = data;
    })
  }

  ngCambioZoom(Event:boolean): void {
    if(Event){
      this.comentariosService.getComentarios(this.id)
      .subscribe(data=>{
        this.comentarios = data;
      })
    }
  }
  handlePage(e:PageEvent){
    this.page_zise   = e.pageSize;
    this.page_number = e.pageIndex + 1
  }
  addcomentarios(){
    this.vcomentarios = !this.vcomentarios;
  }
}
