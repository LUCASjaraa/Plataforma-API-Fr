import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import {formatDate} from '@angular/common';
import { scomentariosService } from '../service/comentarios/scomentarios.service';

@Component({
  selector: 'app-formcomentario',
  templateUrl: './formcomentario.component.html',
  styleUrls: ['./formcomentario.component.scss']
})
export class FormcomentarioComponent implements OnInit {
  @Output() cambio = new EventEmitter()
  @Input() id:string = "";
  comentarioForm!:FormGroup;
  constructor(private readonly fb: FormBuilder, private comentarioService:scomentariosService) { }

  ngOnInit(): void {
    this.comentarioForm = this.initForm();
  }
/*
    titulo: string,
    contenido: string,
    likes: [string],
    fecha_subida: string,

*/

  initForm():FormGroup{
    return this.fb.group({
      usuario_id:['632a072930305800b2d85220',[Validators.required]],
      titulo:['',[Validators.required]],
      contenido:["",[Validators.required]],
      fecha_subida:[formatDate(new Date(), 'yyyy/MM/dd', 'en'),[Validators.required]],
    })
  }


  submit(): void {
    this.comentarioService.postComentario(this.id,this.comentarioForm.value)
                          .subscribe(
                              res=>{
                                console.log(res)
                                this.cambio.emit(true)
                              })
 }



}
