import { Component, OnInit  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from '../../service/api/api.service';
import { datos,ps,Img,Slider } from '../../shared/models/datos';
@Component({
  selector: 'app-gis',
  templateUrl: './gis.component.html',
  styleUrls: ['./gis.component.scss']
})
export class GisComponent implements OnInit {
  marcador: datos[] = []
  accion = 'Agregar';
  form: FormGroup;
  id: string | undefined;
  //pos: ps;

  constructor
  (private fb: FormBuilder,
   private toastr: ToastrService,
   private apiService: ApiService)
  {
    this.form = this.fb.group({
      lat: ['', Validators.required],
      lng: ['', Validators.required],
      titulo: ['', Validators.required],
      tipo: ['', Validators.required],
      descripcion: ['', Validators.required],
      zona: ['', Validators.required],
      fecha: ['', Validators.required],
      img_antes: ['', Validators.required],
      img_despues: ['', Validators.required],
      img_actual: ['', Validators.required],
      slider_antes: ['', Validators.required],
      slider_actual: ['', Validators.required]

    })
  }

  ngOnInit(): void {
    this.getInformacion();
  }

  getInformacion() {
    this.apiService.getInformacionC().subscribe((resp: datos[]) => {
      this.marcador = resp
    // console.log(this.marcador)
  })

  }

  deleteInformacion(id:string | undefined) {
    this.apiService.deleteInformacion(id).subscribe(data =>{
      this.toastr.error("El registro fue eliminado con exito","Registro eliminado");
      this.getInformacion();
    },error => { console.log(error);
    })
  }

  addInformacion() {

    const pos: ps = {
      lat:      this.form.get('lat')?.value,
      lng:      this.form.get('lng')?.value,

    }

    const info: datos = {

      pos:      pos,
      titulo:   this.form.get('titulo')?.value,
      tipo:     this.form.get('tipo')?.value,
      descripcion:  this.form.get('descrip')?.value,
      zona:     this.form.get('zona')?.value,
      fecha:    this.form.get('fecha')?.value,
      img:[{
        antes: this.form.get('img_antes')?.value,
        justo_despues: this.form.get('img_despues')?.value,
        ahora: this.form.get('img_actual')?.value
      }],
      slider:[{
        antes:this.form.get('slider_antes')?.value,
        ahora:this.form.get('slider_actual')?.value
      }
      ]

    }
     console.log("add",this.id);
    if(this.id == undefined) {
      // Agregamos una nueva tarjeta
        this.apiService.addInformacion(info).subscribe(() => {
          this.toastr.success('El marcador fue registrado con exito!', 'Marcador Registrado');
          this.getInformacion();
          this.form.reset();
        }, error => {
          this.toastr.error('Opss.. ocurrio un error','Error')
          console.log(error);
        })
    }else {

      info.id = this.id;
      // Editamos tarjeta
      console.log("update",info);
      this.apiService.updateMarcador(info).subscribe(() => {
        this.form.reset();
        this.accion = 'Agregar';
        this.id = undefined;
        this.toastr.info('El marcador fue actualizado con exito!', 'Marcador Actualizado');
        this.getInformacion();
      }, error => {
        console.log(error);
      })

    }

  }

  updateInformacion(info: datos) {
    console.log(info);
    this.accion = 'Editar';
    this.id = info.id;

    this.form.patchValue({
      lat:          info.pos.lat,
      lng:          info.pos.lng,
      titulo:       info.titulo,
      tipo:         info.tipo,
      descripcion:      info.descripcion,
      zona:         info.zona,
      fecha:        info.fecha,
      img_antes:    info.img[0].antes,
      img_despues:  info.img[0].justo_despues,
      img_actual:   info.img[0].ahora,
      slider_antes: info.slider[0].antes,
      slider_actual:info.slider[0].ahora

    })
  }

}







