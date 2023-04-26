import { Component, Input, OnInit,Output, EventEmitter } from '@angular/core';
import { comentario } from '../model/comentarios';
import { scomentariosService } from '../service/comentarios/scomentarios.service';

@Component({
  selector: 'app-cardcomentario',
  templateUrl: './cardcomentario.component.html',
  styleUrls: ['./cardcomentario.component.scss']
})

export class CardcomentarioComponent implements OnInit {
  @Output() cambio = new EventEmitter()
  @Input() id:string ="";
  @Input() comentario:comentario =
            {
              usuario_id: "",
              comentario_id: "",
              titulo: "",
              contenido: "",
              likes: [""],
              fecha_subida: "",
              aceptado: false
            }

  constructor(private comentarioService:scomentariosService) { }

  ngOnInit(): void {
  }
  deleteComentario(id_comentario:string){
    this.comentarioService.deleteComentario(this.id,id_comentario)
                          .subscribe(
                            res=>{
                              console.log(res)
                              this.cambio.emit(true)
                            });
  }

  aprobarComentario(id_comentario:string){
    this.comentarioService.aprobarComentario(this.id,id_comentario).subscribe(res=>{console.log(res)})
  }

}
