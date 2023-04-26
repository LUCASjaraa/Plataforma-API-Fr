import { Component, Input, OnInit,Output, EventEmitter} from '@angular/core';
import {NgbCarouselConfig} from '@ng-bootstrap/ng-bootstrap';
import {carrousel} from './../../shared/models/carrousel';
@Component({
  selector: 'app-caarousel',
  templateUrl: './caarousel.component.html',
  styleUrls: ['./caarousel.component.scss'],
  providers: [NgbCarouselConfig]  // add NgbCarouselConfig to the component providers
})


export class CaarouselComponent  implements OnInit {
  //@Input() carrousel:carrousel[]=[];
  Carrousel:carrousel[]=[
    {
      title : 'Seccion destinada al Titulo',
      url : 'http://laopiniondechiloe.cl/wp-content/uploads/2017/12/tragedia-Chait%C3%A9n.jpg',
      description : 'Seccion destinada a una breve descripcion',
    },
    {
      title : 'Seccion destinada al Titulo',
      url : 'https://cnnespanol.cnn.com/wp-content/uploads/2017/12/cnn-chile-aluviocc81n-2.jpg?quality=100&strip=info',
      description : 'Seccion destinada a una breve descripcion',
    },
    {
      title : 'Seccion destinada al Titulo',
      url : 'https://www.sernageomin.cl/wp-content/uploads/2018/04/villa_santa_luci%CC%81a.jpg',
      description : 'Seccion destinada a una breve descripcion',
    },
  ]



  constructor(config: NgbCarouselConfig) {
    // customize default values of carousels used by this component tree
    config.interval = 10000;
    config.wrap = false;
    config.keyboard = false;
    config.pauseOnHover = false;
   // console.log(this.dataImg);
  }


  ngOnInit() {
    //console.log(this.dataImg);
}
}

