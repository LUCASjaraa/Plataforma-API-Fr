import { Component, Input, OnInit } from '@angular/core';
import { comentario } from '../model/comentarios';

@Component({
  selector: 'app-cardcomentario',
  templateUrl: './cardcomentario.component.html',
  styleUrls: ['./cardcomentario.component.scss']
})

export class CardcomentarioComponent implements OnInit {
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

  constructor() { }

  ngOnInit(): void {
  }

}
