import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-imagen',
  templateUrl: './imagen.component.html',
  styleUrls: ['./imagen.component.scss']
})
export class ImagenComponent implements OnInit {
 @Input() src:string="";
 @Input() alt:string=""
  constructor() { }

  ngOnInit(): void {
  }

}
