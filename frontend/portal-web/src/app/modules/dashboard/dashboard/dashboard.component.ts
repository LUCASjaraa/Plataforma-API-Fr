import { Component, OnInit, EventEmitter } from '@angular/core';
import { ApiService } from '../../../service/api/api.service';
import { visita } from '../../../shared/models/datos2';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  myData:any[] = [];
  dataTablaInmersion:any[] = [];
  labelTablaInmersion:string="Promedio de Valoracion"
  dataTablaInteres:any[] = [];
  labelTablaInteres:string="Promedio de Valoracion"
  dataTablaVisitas:any[] = [];
  labelTablaVisitas:string="Cantidad de Visitas"
  valoracionListGeneral:any[] = [];
  test:any[] = [];
  promEventoVal:any[] = [];
  promEventoInm:any[] = [];
  cantEventos: number = 0;
  cantValoraciones: number = 0;
  sumaVal: number = 0;
  sumaInmersivo: number = 0;
  promVal: number | string = 0;
  promInmersivo: number | string = 0;

  infoGrafico:string | undefined = ""

  infoEscenario:any[] = [];

  // labelDonaChart:string[] = [];
  pInteresDonaChart: number[] = [];
  // largoDataDonaChart:number[] = [];

  // labelBarChartL:string[] = [];
  datosBarChartL:number[] = [];
  etiquetaBarChartL:string = "Visitas";
  datosBarChartR:number[] = [];
  etiquetaBarChartR:string = "Valoraciones"
  // largoDataBarChartL:number[] = [];

  labelPieChart:string[]  = [];
  datosPieChart:number[]  = [];
  largoDataPieChart:number[] = [];

  // labelLineChart:string[]  = [];
  datosLineChartRelatos:number[]  = [];
  datosLineChartComentarios:number[]  = [];
  // largoDataLineChart:number[] = [];
  marcadorComentario:string = "Comentarios"
  marcadorRelatos:string = "Relatos"

  largoDataEscenario:number[] = [];
  labelDataEscenario:string[] = [];

  constructor(public apiService: ApiService) {
    this.apiService.contenido = "all";
    this.apiService.getInformacionC()
    .subscribe(resp => {
      this.myData = resp;
      this.cantEventos = this.myData.length
      for (let elemento of this.myData) {
        this.test.push(elemento.valoraciones)
        for (let x of elemento.valoraciones) {
          this.valoracionListGeneral.push(x);
        }
      }
      let sumaVal = 0
      let sumaInm = 0
      let contador = 0
      let contador2 = 0
      let promedioVal:number | string = 0
      let promedioInm:number | string = 0
      // let bandera: boolean = true;
      // console.log(this.test.length)
      for (let promEvento of this.test) {
        if (contador != 0) {
          // console.log(sumaVal, contador)
          promedioVal = (sumaVal / contador2).toFixed(2)
          promedioInm = (sumaInm / contador2).toFixed(2)
          this.promEventoVal.push(promedioVal)
          this.promEventoInm.push(promedioInm)
          contador2 = 0
          sumaVal = 0
          sumaInm = 0
        }
        contador ++

        for(let item of promEvento) {
          sumaVal = sumaVal + item.val_interes
          // console.log(sumaVal)
          sumaInm = sumaInm + item.val_inmersion
          contador2 ++
          if (contador == this.test.length && contador2 == Object.keys(promEvento).length) {
            promedioVal = (sumaVal / contador2).toFixed(2)
            promedioInm = (sumaInm / contador2).toFixed(2)
            this.promEventoVal.push(promedioVal)
            this.promEventoInm.push(promedioInm)
          }
        }
      }

      // console.log(this.promEventoVal)
       this.cantValoraciones = this.valoracionListGeneral.length;
       for (let val of this.valoracionListGeneral) {
        this.sumaVal = this.sumaVal + val.val_interes
        this.sumaInmersivo = this.sumaInmersivo + val.val_inmersion
      }
      this.promVal = (this.sumaVal / this.cantValoraciones).toFixed(2)
      this.promInmersivo = (this.sumaInmersivo / this.cantValoraciones).toFixed(2)


    });

   }

  ngOnInit(): void {
    this.dataTablaEstadistica();
    this.getDataEscenario();
    // this.dataDonaChart();
    // this.dataBarChartL();
    this.dataPieChart();
    // this.dataLineChart();

  }

  recibirData(mensaje:string | undefined) {
    this.infoGrafico = mensaje;
    console.log(this.infoGrafico, "ss");
  }

  getDataEscenario() {
    let sumaRelatos = 0;
    let sumaComentarios = 0;
    let sumaVisitas = 0;
    let sumaCantValoraciones = 0;
    this.apiService.getInfoEscenario()
    .subscribe(resp => {
      let data = resp
      this.largoDataEscenario.push(resp.length)
      for (let x of data) {
        // console.log(x, "x")
        this.apiService.getEstadisticaEscenario(x.id)
        .subscribe(resp2 => {
          let data2 = resp2
          //console.log(data2)
          // sumaRelatos = sumaRelatos + data2[0].relatos
          for (let y of data2) {
            //console.log(y, "2do for")
            sumaRelatos = sumaRelatos + y.relatos
            sumaComentarios = sumaComentarios + y.comentarios
            sumaVisitas = sumaVisitas + y.visitas
            sumaCantValoraciones = sumaCantValoraciones + y.cant_valoraciones
          }
          this.labelDataEscenario.push(x.titulo);
         // console.log("Puntos de interes por escenario", data2.length, x.titulo) // Info Grafica Dona
          this.pInteresDonaChart.push(data2.length);
         // console.log("Relatos por escenario = ", sumaRelatos, x.titulo) // Info Grafica de Linea 1
          this.datosLineChartRelatos.push(sumaRelatos);
         // console.log("Comentarios por escenario", sumaComentarios, x.titulo) // Info Grafica de Linea 2
          this.datosLineChartComentarios.push(sumaComentarios);
         // console.log("Visitas por escenario", sumaVisitas, x.titulo) // Info grafica de barra 1
          this.datosBarChartL.push(sumaVisitas);
         // console.log("Valoraciones por escenario" , sumaCantValoraciones, x.titulo) // Info grafica de barra 2
          this.datosBarChartR.push(sumaCantValoraciones)
          sumaRelatos = 0;
          sumaComentarios = 0;
          sumaVisitas = 0;
          sumaCantValoraciones = 0;
        })

      }
      });
  }


  dataPieChart() {
    this.apiService.getInfoCategoria()
    .subscribe(resp => {
      let data = resp
      this.largoDataPieChart.push(resp.length);
      // console.log(this.largoDataPieChart)
      for (let x of data) {
        this.labelPieChart.push(x.tipo)
        this.apiService.getInfoPie(x.id)
        .subscribe(resp2 => {
          let data2 = resp2
          this.datosPieChart.push(Object.values(data2)[0])
          // this.largoDataPieChart = this.datosPieChart.length
          // console.log(this.largoDataPieChart)
        })
      }

    })

  }


  dataTablaEstadistica() {
    this.apiService.getEstadisticaTop()
    .subscribe(resp => {
      let dataTabla = resp
      this.dataTablaVisitas   = Object.values(dataTabla)[0]
      this.dataTablaInmersion = Object.values(dataTabla)[1]
      this.dataTablaInteres   = Object.values(dataTabla)[2]

      console.log(this.dataTablaVisitas)


    })
  }

}
