import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import {formatDate} from '@angular/common';
import { SgaleriaService } from '../service/sgaleria.service';


@Component({
  selector: 'app-formgaleria',
  templateUrl: './formgaleria.component.html',
  styleUrls: ['./formgaleria.component.scss']
})
export class FormgaleriaComponent implements OnInit {
  @Input()id:string="";
  galeriaForm!:FormGroup;
  constructor(private readonly fb: FormBuilder,
              private galeriaService:SgaleriaService)
              {}
  ngOnInit() : void {

    this.galeriaForm = this.initForm();

  }

  fileToUpload!: Blob;
  changeFile(evt:any) {
     this.fileToUpload = evt.target.files[0];
  }

  initForm():FormGroup{
    return this.fb.group({
      file: this.fb.control(null),
      usuario_id:['637691b6ab9ffb9d80d0f5e5',[Validators.required]],
      descripcion:["",[Validators.required]],
      fecha_subida:['2022/01/20',[Validators.required]],
    })
  }

  submit(): void {
     const formData = new FormData();

     formData.append('usuario_id', "632a072930305800b2d85220");
     formData.append('descripcion', this.galeriaForm.get("descripcion")?.value);
     formData.append('archivo', this.fileToUpload);
     formData.append('fecha_subida', formatDate(new Date(), 'yyyy/MM/dd', 'en'));
     console.log(this.fileToUpload);


     this.galeriaService.postGaleriaI(this.id,formData).subscribe(res=>{console.log(res)});

     //this.galeriaService.postGaleriaV(this.id,formData).subscribe(res=>{console.log(res)});

  }
}

