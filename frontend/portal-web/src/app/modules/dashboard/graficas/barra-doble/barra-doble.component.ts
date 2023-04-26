import { Component, ViewChild, OnInit, Input } from '@angular/core';
import { Chart, ChartConfiguration, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';


@Component({
  selector: 'app-barra-doble',
  templateUrl: './barra-doble.component.html',
  styleUrls: ['./barra-doble.component.scss']
})
export class BarraDobleComponent implements OnInit {

  @Input() labels:string[] = []

  @Input() data:number[] = []

  @Input() largo:number[] = [];

  @Input() marcador:string = "";


  public lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: [],
        label: "",
        backgroundColor: 'rgba(148,159,177,0.2)',
        borderColor: 'rgba(148,159,177,1)',
        pointBackgroundColor: '#1E293B ',
        pointBorderColor: '#1E293B ',
        hoverBackgroundColor: "#1E293B ",
        pointHoverBackgroundColor: '#1E293B ',
        pointHoverBorderColor: '#1E293B ',
        fill: 'origin',
      },

    ],
    labels: []
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
  ngOnInit(): void {
    this.lineChartData.labels = this.labels
    this.lineChartData.datasets[0].data = this.data
    this.lineChartData.datasets[0].label = this.marcador
  }

}
