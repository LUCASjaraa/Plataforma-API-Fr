import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DatointeresService } from '../service/datointeres/datointeres.service';

@Component({
  selector: 'app-formdatosinteres',
  templateUrl: './formdatosinteres.component.html',
  styleUrls: ['./formdatosinteres.component.scss']
})
export class FormdatosinteresComponent implements OnInit {
  @Input() id : string="";
  dinteresFrom!:FormGroup;
  constructor(private readonly fb:FormBuilder,
              private datointeresService:DatointeresService) { }

  ngOnInit(): void {
    this.dinteresFrom = this.initForm();
  }

  initForm():FormGroup{
    return  this.fb.group({
      titulo:[''],
      descripcion:['']
    })
  }
  ngSubmit(){
    this.datointeresService.addDatointeres(this.id,this.dinteresFrom.value)
    .subscribe(res=>{console.log(res)})
  }
/*    this.comentarioService.postComentario(this.id,this.comentarioForm.value)
                          .subscribe(
                              res=>{
                                console.log(res)
                                this.cambio.emit(true)
                              })*/
}
