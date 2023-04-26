import { Component, OnInit } from '@angular/core';
import { datos,CreatetDTO } from '../../shared/models/datos';
import { ApiService } from '../../service/api/api.service';

@Component({
  selector: 'app-desastre-memoria',
  templateUrl: './desastre-memoria.component.html',
  styleUrls: ['./desastre-memoria.component.scss']
})
export class DesastreMemoriaComponent implements OnInit {

  myData:datos[] = [];

  upData:CreatetDTO = {
    titulo: '',
    descripcion: '',
    tipo: '',
    zona: '',
    fecha: '',
    pos: {
      lat: '',
      lng: ''
    },
    img: [],
    slider: []
  }
   imagen = [
    'https://www.subpesca.cl/portal/617/articles-89765_galeria006.jpg',
    'https://www.terram.cl/wp-content/uploads/2017/12/villa-santa-lucia-3-1200x675.jpeg',
    'https://noticias.unab.cl/wp-content/uploads/2014/04/valpo-fuego.jpg',
    'https://www.terram.cl/wp-content/uploads/2017/12/villa-santa-lucia-3-1200x675.jpeg',
    'https://noticias.unab.cl/wp-content/uploads/2014/04/valpo-fuego.jpg',
    'https://www.subpesca.cl/portal/617/articles-89765_galeria006.jpg',
    'https://www.terram.cl/wp-content/uploads/2017/12/villa-santa-lucia-3-1200x675.jpeg',
    'https://www.subpesca.cl/portal/617/articles-89765_galeria006.jpg',
    'https://www.subpesca.cl/portal/617/articles-89765_galeria006.jpg',
  ]
  constructor(private apiService :ApiService)
  {

    this.apiService.getInfoEvento(this.apiService.contenido)
    .subscribe(resp => {
      // this.upData = resp[0];
      this.myData = resp;
      console.log(this.myData)
    });

  }

  ngOnInit(): void {


  }

  ngUpdatC(data:datos){
    console.log(data);
    this.upData = data;

  }

}
