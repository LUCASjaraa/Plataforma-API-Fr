import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-tabla-resumen',
  templateUrl: './tabla-resumen.component.html',
  styleUrls: ['./tabla-resumen.component.scss']
})
export class TablaResumenComponent implements OnInit {

  @Input() data:any[] = []

  @Input() label:string = ""

  constructor() { }

  ngOnInit(): void {
  }

}
