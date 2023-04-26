import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../service/api/api.service';

@Component({
  selector: 'app-datos-interes',
  templateUrl: './datos-interes.component.html',
  styleUrls: ['./datos-interes.component.scss']
})
export class DatosInteresComponent implements OnInit {

  datosInteres: any;

  constructor(private apiService:ApiService) { }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.apiService.getInfoDatosInteres().
      subscribe(resp=>{
        this.datosInteres = resp;
    
      })
  }



}
