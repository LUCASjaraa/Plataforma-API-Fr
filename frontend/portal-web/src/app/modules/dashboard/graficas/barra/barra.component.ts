import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { ApiService } from '../../../../service/api/api.service';

@Component({
  selector: 'app-barra',
  templateUrl: './barra.component.html'
})
export class BarraComponent implements OnInit {

  @Input() labels:string[] = []

  @Input() data:number[] = []

  @Input() largo:number[] = [];

  @Input() etiqueta:string = ""

  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;


  // etiqueta:string = "Visitas ";

  public barChartOptions: ChartConfiguration['options'] = {
    responsive: true,

  };
  public barChartType: ChartType = 'bar';
  
  public barChartData: ChartData<'bar'> = {

    labels: [],
    datasets: [
      { data: [], 
        label: ""  , 
        backgroundColor: ["#DAF7A6 "],
      },
    ],
    
  };

  constructor(private apiService: ApiService) { 
    
    // this.apiService.getInfoEscenario()
    // .subscribe(resp => {
    //   this.myData = resp;
    //   for (let x of this.myData) {
    //     this.apiService.getInfoVisitas(x.id)
    //     .subscribe(resp2 => {
    //       this.myData2 = resp2;
    //       this.test.push(Object.values(this.myData2)[0])
    //       // this.barChartData.datasets[0].data.push(Object.values(this.myData2)[0])
    //       // console.log( x.id)
    //     })
    //     // console.log(this.myLavels, this.barChartData.datasets[0].data)
    //     // console.log(Object.values(this.myData2)[0])
    //     // this.barChartData.datasets[0].data.push(Object.values(this.myData2)[0]) 
    //     this.myLavels.push(x.titulo)
    //     // console.log(this.myLavels, this.barChartData.datasets[0].data)
    //   }
     
    //   this.chart?.update();
      
    // });
    
}



  ngOnInit(): void {
    // console.log("labels", this.labels, "data", this.data, "bar", this.largo)
    this.barChartData.labels = this.labels;
    this.barChartData.datasets[0].data = this.data
    this.barChartData.datasets[0].label = this.etiqueta
    // this.barChartData.datasets[1].data = this.data
    // this.chart?.update();
  }

}

