import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-acerca-de',
  templateUrl: './acerca-de.component.html',
  styleUrls: ['./acerca-de.component.scss']
})
export class AcercaDeComponent implements OnInit {
  img = "./assets/imagenes/desastres/sismos.png";
  constructor() { }

  ngOnInit(): void {
  }

}
