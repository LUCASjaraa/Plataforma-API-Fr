import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ChartData, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { ApiService } from 'src/app/service/api/api.service';

@Component({
  selector: 'app-dona',
  templateUrl: './dona.component.html',
  styleUrls: ['./dona.component.scss']
})
export class DonaComponent implements OnInit {

  @Input() labels:string[] = []

  @Input() data:number[] = []

  @Input() largo:number[] = [];

  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

  // myData:any[] = [];
  // myData2:any[] = [];
  // cantPInteres:number[] = [];

  // public doughnutChartLabels: string[] = [];
  public doughnutChartData: ChartData<'doughnut'> = {
    labels: [],
    datasets: [
      { data: [] },
    ]
  };
  public doughnutChartType: ChartType = 'doughnut';

  constructor( private apiService: ApiService ) { 
    // this.apiService.getInfoEscenario()
    // .subscribe(resp => {
    //   this.myData = resp
    //   for (let x of this.myData) {
    //     this.doughnutChartLabels.push(x.titulo)
    //     this.apiService.getInfoDona(x.id).subscribe(
    //       resp2 => {
    //         this.myData2 = resp2
    //         this.cantPInteres.push(this.myData2.length)
            
    //       }
    //     )
    //   }
    // })
   }

  ngOnInit(): void {
    this.doughnutChartData.labels = this.labels
    this.doughnutChartData.datasets[0].data = this.data
    this.chart?.update();

  }

}
