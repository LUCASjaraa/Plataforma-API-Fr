import { Component, OnInit } from '@angular/core';

import { datos,CreatetDTO } from '../../shared/models/datos';
import { ApiService } from '../../service/api/api.service';
import { ChartConfiguration, ChartType } from 'chart.js';
@Component({
  selector: 'app-home-usuario',
  templateUrl: './home-usuario.component.html',
  styleUrls: ['./home-usuario.component.scss']
})
export class HomeUsuarioComponent implements OnInit {

  public lineChartData: ChartConfiguration['data'] = {
    datasets: [
      // {
      //   data: [ 18, 9, 2, 1],
      //   label: 'Semanas de Gestacion (cantidades)',
      //   backgroundColor: 'rgba(148,159,177,0.2)',
      //   borderColor: 'rgba(148,159,177,1)',
      //   pointBackgroundColor: 'rgba(148,159,177,1)',
      //   pointBorderColor: '#fff',
      //   pointHoverBackgroundColor: '#fff',
      //   pointHoverBorderColor: 'rgba(148,159,177,0.8)',
      //   fill: 'origin',
      // },
      {
        data: [ 60.00,	30.00,	6.67,	3.33],
        label: 'Semanas de Gestacion (porcentajes)',
        backgroundColor: 'rgba(148,159,177,0.2)',
        borderColor: 'red',
        pointBackgroundColor: 'rgba(148,159,177,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin',
      },

    ],
    labels: [ "rango [5-10[",	"rango [10-15[",	"rango [15-20[",	"rango [20-24]" ]
  };

  public lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      line: {
        tension: 0.5
      }
    },
    scales: {
      // We use this empty structure as a placeholder for dynamic theming.
      x: {},
      'y-axis-0': {
        position: 'left',
        grid: {
          color: 'green',
        },
        ticks: {
          color: 'green'
        }
      }
    },
  };

  public lineChartType: ChartType = 'line';

  constructor() {     

  }
  // myData:datos[] = [];

  // upData:CreatetDTO={
  //   titulo: '',
  //   descripcion: '',
  //   tipo: '',
  //   zona: '',
  //   fecha: '',
  //   pos: {
  //     lat: '',
  //     lng: ''
  //   },
  //   img: [],
  //   slider: []
  // }

  // constructor(private apiService :ApiService)
  // {
  //   this.apiService.getInformacionC()
  //   .subscribe(resp => {
  //     this.upData = resp[0];
  //     this.myData = resp;
  //   });

  // }

  ngOnInit(): void {


  }

  // ngUpdatC(data:datos){
  //   console.log(data);
  //   this.upData = data;

  // }

}
