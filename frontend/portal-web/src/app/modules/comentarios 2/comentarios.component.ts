import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/service/api/api.service';
import { datos } from 'src/app/shared/models/datos';

@Component({
  selector: 'app-comentarios',
  templateUrl: './comentarios.component.html',
  styleUrls: ['./comentarios.component.scss']
})
export class ComentariosComponent implements OnInit {
  myData:any[] = [];
  myUser:any[] = [];
  comentariosList = [];
  nombreList = [];
  w:string  = ""
  objectKeys = Object.keys;
  objectValue= Object.values;

  constructor(public apiService :ApiService) { 
    this.w = this.apiService.contenido;
    console.log(this.w)
    // this.apiService.getInfoEvento(this.apiService.contenido)
    // .subscribe(resp => {
    //   this.myData = resp;
    //   console.log(this.myData, "xd")
    //   this.comentariosList = Object.values(this.myData[0].comentarios)
    //   console.log(this.comentariosList, "hola")
    //   this.comentariosList.forEach(element => { 
    //     // console.log(Object.values(element)[0])
    //      this.w.push(Object.values(element)[0])
    //   });
    //     // console.log(this.w)
    //     this.w.forEach(element => {
    //       this.apiService.getInfoUsuario(element).subscribe(
    //         resp2 => {
    //         this.myUser.push(resp2)
    //       });
    //     })
    //     console.log(this.myUser, "hasasja")
    // });


      
  }

  ngOnInit(): void {
  }

}
