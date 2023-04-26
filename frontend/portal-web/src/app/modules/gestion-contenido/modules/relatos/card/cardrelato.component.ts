import { Component, Input, OnInit } from '@angular/core';
import { relato } from '../model/relatos';
import { RelatosService } from '../service/relatos/relatos.service';

@Component({
  selector: 'app-cardrelato',
  templateUrl: './cardrelato.component.html',
  styleUrls: ['./cardrelato.component.scss']
})
export class CardrelatoComponent implements OnInit {
  @Input() id:string = "";
  @Input() relato:relato =
        {
          usuario_id: "",
          relato_id: "",
          titulo: "",
          contenido: "",
          likes: [""],
          fecha_subida: "",
          aceptado: false
        };
  constructor(private relatosService:RelatosService) { }

  ngOnInit(): void {

  }
  aprobarRelato(id_relato:string){
    this.relatosService.aprobarRelato(this.id,id_relato).subscribe(res=>{console.log(res);})
  }
  deleteRelato(id_relato:string){
    this.relatosService.deleteRelato(this.id,id_relato).subscribe(res=>{console.log(res);})
  }
  
}
