import { Component, Input, ViewChild, OnInit } from '@angular/core';
import { ChartConfiguration, ChartData, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { ApiService } from '../../../../service/api/api.service';

@Component({
  selector: 'app-pie',
  templateUrl: './pie.component.html',
  styleUrls: ['./pie.component.scss']
})
export class PieComponent implements OnInit{

  // labelPieChart:string[]  = [];
  // datosPieChart:number[]  = [];

  @Input() labels:string[] = []

  @Input() data:number[] = []

  @Input() largo:number[] = [];

  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

  // myData: any[] = [];
  // myData2: any[] = [];
  // cantPuntos: any[] = []; 
  

  public pieChartOptions: ChartConfiguration['options'] = {
    responsive: true,
  
    
  };
  public pieChartData: ChartData<'pie', number[], string | string[]> = {
    labels: [],
    datasets: [ {
      data: []
    } ]
  };
  public pieChartType: ChartType = 'pie';

  constructor( private apiService: ApiService ) {
    
    // this.apiService.getInfoCategoria()
    // .subscribe(resp => {
    //   let data = resp
    //   for (let x of data) {
    //     this.pieChartData.labels?.push(x.tipo)
    //     this.apiService.getInfoPie(x.id)
    //     .subscribe(resp2 => {
    //       let data2 = resp2
    //       this.pieChartData.datasets[0].data.push(Object.values(data2)[0])
    //     })
    //   }
    // })


    // this.pieChartData.labels = this.labels
    // this.pieChartData.datasets[0].data = this.data
    // console.log("labels", this.pieChartData.labels, "data",  this.pieChartData.datasets[0].data)

    // this.apiService.getInfoCategoria().subscribe
    //   (resp => {
    //     this.myData = resp
    //     for (let x of this.myData) {
    //       this.pieChartData.labels?.push(x.tipo)
    //       this.apiService.getInfoPie(x.id).subscribe
    //         (resp2 => {
    //           this.myData2 = resp2
    //           // this.pieChartData.datasets.push(Object.values(this.myData2))
    //           // console.log(Object.values(this.myData2))
    //           this.cantPuntos.push(Object.values(this.myData2))

    //         })
    //     }
    //     this.chart?.update();
    //   })
      // console.log(this.cantPuntos)


  }
  ngOnInit(): void {

    this.pieChartData.labels = this.labels
    this.pieChartData.datasets[0].data = this.data
    // console.log("labels", this.pieChartData.labels, "data",  this.pieChartData.datasets[0].data, this.largo)
    // this.largoData = this.pieChartData.datasets[0].data[0]
    // console.log(Object.values(this.pieChartData.datasets[0].data[0]))
    
    // this.pieChartData.labels = this.pieChartData.labels
    // this.pieChartData.datasets[0].data = this.pieChartData.datasets[0].data

  }


}
