import { Component, Input, OnInit } from '@angular/core';
import { comentarios } from '../model/comentarios';
import {scomentariosService} from '../service/comentarios/scomentarios.service';
import { ApiService } from '../../../service/api/api.service';

@Component({
  selector: 'app-viewcomentarios',
  templateUrl: './viewcomentarios.component.html',
  styleUrls: ['./viewcomentarios.component.scss']
})

export class ViewcomentariosComponent implements OnInit {
  id:string = ""
  // @Input() id:string = ""
  lComentarios:comentarios[] = [{
    id: "",
    comentarios:[
      {
      usuario_id: "",
      comentario_id: "",
      titulo: "",
      contenido: "",
      likes: [""],
      fecha_subida: "",
      aceptado: false
      }
  ]}
]



  constructor(
    private comentariosService:scomentariosService,
    private apiService: ApiService
    ) { 
      this.id = this.apiService.contenido
     }

  ngOnInit(): void {
    this.comentariosService.getComentarios(this.id)
    .subscribe(data=>{
      this.lComentarios = data;
    })


  }
}
