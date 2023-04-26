import { Component, Input, OnInit } from '@angular/core';
import { memoria } from '../model/memoria';
import { MemoriaService } from '../service/memoria.service';

@Component({
  selector: 'app-viewmemoria',
  templateUrl: './viewmemoria.component.html',
  styleUrls: ['./viewmemoria.component.scss']
})
export class ViewmemoriaComponent implements OnInit {
  @Input() id="";
  constructor(private memoriaService:MemoriaService) { }
  memorias:memoria[]=[];
  ngOnInit(): void {
    this.memoriaService.getMemroria(this.id)
    .subscribe(data=>{
      this.memorias = data;
    })
  }

}
