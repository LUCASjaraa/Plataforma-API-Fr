import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-juega-aprende',
  templateUrl: './juega-aprende.component.html',
  styleUrls: ['./juega-aprende.component.scss']
})
export class JuegaAprendeComponent implements OnInit {
  img = "./assets/imagenes/desastres/sismos.png";

  constructor() { }

  ngOnInit(): void {
  }

}
