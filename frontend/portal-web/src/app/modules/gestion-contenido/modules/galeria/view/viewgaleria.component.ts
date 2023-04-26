import { Component, Input, OnInit } from '@angular/core';
import { galeria } from '../model/galeria';
import { SgaleriaService } from '../service/sgaleria.service';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-viewgaleria',
  templateUrl: './viewgaleria.component.html',
  styleUrls: ['./viewgaleria.component.scss']
})
export class ViewgaleriaComponent implements OnInit {
  @Input() id:string=""
  galerias:galeria[]=[];
  page_zise : number = 3;
  page_number:number = 1;
  vgaleria:boolean=true;

  constructor(private sgaleriaService:SgaleriaService) { }

  ngOnInit(): void {
    this.sgaleriaService.getGaleria(this.id)
    .subscribe(data=>{
      this.galerias = data;
    })
  }
  handlePage(e:PageEvent){
    this.page_zise   = e.pageSize;
    this.page_number = e.pageIndex + 1
  }
  addgaleria(){
    this.vgaleria = !this.vgaleria;
  }
}
