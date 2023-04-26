import { Component, Input, OnInit } from '@angular/core';
import { relato } from '../model/relatos';
import { RelatosService } from '../service/relatos/relatos.service';
import { FormrelatoComponent } from '../form/formrelato.component';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-viewrelatos',
  templateUrl: './viewrelatos.component.html',
  styleUrls: ['./viewrelatos.component.scss']
})
export class ViewrelatosComponent implements OnInit {
  @Input() id=""
  page_zise : number = 3;
  page_number:number = 1;
  vrelato:boolean=true;


  constructor(private relatosService:RelatosService) { }

  relatos:relato[]=[]

  ngOnInit(): void {
    this.relatosService.getRelatos(this.id)
    .subscribe(data=>{
      this.relatos = data;
    })
  }
  
  handlePage(e:PageEvent){
    this.page_zise   = e.pageSize;
    this.page_number = e.pageIndex + 1
  }

  addRelatos(){
    this.vrelato = !this.vrelato;
  }



}

