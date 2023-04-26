import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../service/api/api.service';

@Component({
  selector: 'app-sitios-interes',
  templateUrl: './sitios-interes.component.html',
  styleUrls: ['./sitios-interes.component.scss']
})
export class SitiosInteresComponent implements OnInit {

  tarjetas: any
  public page!: any;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.InfoSitios();
  }

  InfoSitios(){
    this.apiService.getInfoModuloEducativo()
    .subscribe(resp=>{
        this.tarjetas = resp
        console.log(this.tarjetas)
      })
  }

}
