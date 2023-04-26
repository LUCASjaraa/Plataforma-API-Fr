import { Component, Input, OnInit } from '@angular/core';
import { galeria } from '../model/galeria';

@Component({
  selector: 'app-card-galeria',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  @Input() galeria:galeria[]= []


  public page!: any;

  constructor() { }

  ngOnInit(): void {
  }

}
