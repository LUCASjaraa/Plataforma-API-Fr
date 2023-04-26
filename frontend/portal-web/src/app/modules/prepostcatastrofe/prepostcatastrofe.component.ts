import { Component, OnInit } from '@angular/core';
import { datos,UpDTO } from '../../shared/models/datos';
import { ApiService } from '../../service/api/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-prepostcatastrofe',
  templateUrl: './prepostcatastrofe.component.html',
  styleUrls: ['./prepostcatastrofe.component.scss']
})
export class PrepostcatastrofeComponent {
  public page!: any;
  myData:any[] = [];
  detalle: boolean = false;

  upData:UpDTO={
    titulo: '',
    descripcion: '',
    img: [{
      antes: '',
      justo_despues: '',
      ahora: ''
    }],
    slider: [{
      antes: '',
      ahora: ''}
    ]
  }

  constructor(public apiService :ApiService)
  {
    this.apiService.getInformacionC()
    .subscribe(resp => {
      this.myData = resp;
      // console.log(this.myData);
    });

  }


  cambiar(id:any) {
    this.detalle = true;
    // console.log (id);
    this.apiService.contenido = id
    this.apiService.getInformacionC()
    .subscribe(resp2=> {
      this.myData = resp2;
      // console.log(this.myData);
      // console.log(this.myData[0].slider[0].url_antes)
    });
    

  }

  hola() {
    console.log(this.apiService.contenido, "metodo Hola")
  }

}
