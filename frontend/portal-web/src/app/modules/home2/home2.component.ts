import { Component, OnInit } from '@angular/core';
import { Img } from '../../shared/models/datos';

@Component({
  selector: 'app-home2',
  templateUrl: './home2.component.html',
  styleUrls: ['./home2.component.scss'],

})
export class Home2Component implements OnInit {
  textSize = 20

  constructor() { }
  img: Img[] = [{
    antes: 'https://www.subpesca.cl/portal/617/articles-89765_galeria006.jpg',
    justo_despues: 'https://www.terram.cl/wp-content/uploads/2017/12/villa-santa-lucia-3-1200x675.jpeg',
    ahora: 'https://noticias.unab.cl/wp-content/uploads/2014/04/valpo-fuego.jpg'
  }]
  ngOnInit(): void {
  }
  ControlText(size:number){
    this.textSize = size
  }

}
