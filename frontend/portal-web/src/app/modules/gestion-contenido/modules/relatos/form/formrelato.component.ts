import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { RelatosService } from '../service/relatos/relatos.service';
import {formatDate} from '@angular/common';
@Component({
  selector: 'app-formrelato',
  templateUrl: './formrelato.component.html',
  styleUrls: ['./formrelato.component.scss']
})
export class FormrelatoComponent implements OnInit {
  @Input() id:string="";
  relatoFrom!:FormGroup;

  relatoFile!: Blob;

  constructor(private readonly fb: FormBuilder ,
              private RelatosService:RelatosService) { }

  ngOnInit(): void {
    this.relatoFrom = this.initForm();
  }


  changeFile(evt:any) {
     this.relatoFile = evt.target.files[0];
  }

  initForm():FormGroup{
    return this.fb.group({
      Archivo: this.fb.control(null),
      usuario_id: ['',[Validators.required]],
      titulo:['',[Validators.required]],
    })

  }

  submit(): void {
    const formData = new FormData();
    //id de lucas
    formData.append('usuario_id', "632a072930305800b2d85220");
    formData.append('titulo', this.relatoFrom.get('titulo')?.value);
    formData.append('Archivo', this.relatoFile);
    formData.append('fecha_subida', formatDate(new Date(), 'yyyy/MM/dd', 'en'));

    this.RelatosService.postRelato(this.id,formData).subscribe(data=>{console.log(data)});
 }



}
