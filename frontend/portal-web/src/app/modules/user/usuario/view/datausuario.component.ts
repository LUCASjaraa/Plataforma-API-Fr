import { Component, Input, OnInit } from '@angular/core';
import { usuario } from '../model/usuario';
import { UsuariosService } from '../service/usuarios/usuarios.service';
@Component({
  selector: 'app-datausuario',
  templateUrl: './datausuario.component.html',
  styleUrls: ['./datausuario.component.scss']
})
export class DatausuarioComponent implements OnInit {
  @Input() id =""

  Usuario: usuario[]=[{
    id: "",
    nombre: "",
    apellido: "",
    edad: 0,
    fecha_nacimiento: "",
    rol: "",
    correo: "",
    password: "",
    ciudad: "",
    region: "",
    img_perfil: ""

  }];

  constructor(   private usuariosService:UsuariosService) { }

  ngOnInit(): void {
    this.usuariosService.getUsuario(this.id)
    .subscribe(data=>{
      this.Usuario = data;
    })
  }




}
