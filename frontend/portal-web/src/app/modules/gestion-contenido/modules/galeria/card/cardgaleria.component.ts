import { Component, Input, OnInit } from '@angular/core';
import { strings } from '@material/form-field';
import { galeria } from '../model/galeria';
import { SgaleriaService } from '../service/sgaleria.service';

@Component({
  selector: 'app-cardgaleria',
  templateUrl: './cardgaleria.component.html',
  styleUrls: ['./cardgaleria.component.scss']
})
export class CardgaleriaComponent implements OnInit {
  @Input() id:string="";

  @Input() galeria:galeria=
  {
    usuario_id: "",
    galeria_id: "",
    tipo: "",
    contenido: "",
    likes: [""],
    descripcion: "",
    fecha_subida: "",
    aceptado: false
  }
  constructor(private galeriaService:SgaleriaService) { }

  ngOnInit(): void {
  }

  deleteGaleria(id_galeria:string){
    this.galeriaService.deleteGaleria(this.id,id_galeria).subscribe(res=>{console.log(res,this.id,id_galeria);})
  }

  aprobarGaleria(id_galeria:string){
    this.galeriaService.aprobarGaleria(this.id,id_galeria).subscribe(res=>{console.log(res);})
  }
}
