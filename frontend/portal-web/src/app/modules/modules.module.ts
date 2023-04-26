import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgChartsModule } from 'ng2-charts';
import { LoginComponent } from '../modules/login/login.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { GisComponent } from './gis/gis.component';
import { UserComponent } from './user/user.component';
import { KtdGridModule } from '@katoid/angular-grid-layout';
import { HomeInstitucionalComponent } from './home-institucional/home-institucional.component';
import { HomeUsuarioComponent } from './home-usuario/home-usuario.component';
import { TriviaComponent } from './modulo-educativo/trivia-welcome/trivia.component';
import { DesastreMemoriaComponent } from './desastre-memoria/desastre-memoria.component';
import { PrepostcatastrofeComponent } from './prepostcatastrofe/prepostcatastrofe.component';
import { ComentariosComponent } from './comentarios 2/comentarios.component';
import { Home2Component } from './home2/home2.component';
import { CaarouselComponent } from './caarousel/caarousel.component';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { NgxPaginationModule } from 'ngx-pagination';
import { RouterModule } from '@angular/router';
import { GaleriaComponent } from './galeria/galeria-especifica/galeria.component';
import { DashmapComponent } from './dashboard/dashmap/dashmap.component';
import { AgmCoreModule } from '@agm/core';
import { AgmDirectionModule } from 'agm-direction';
import { JuegaAprendeComponent } from './modulo-educativo/juega-aprende/juega-aprende.component';
import { AcercaDeComponent } from './acerca-de/acerca-de.component';
import { RegistroComponent } from './registro/registro.component';
import { BarraComponent } from './dashboard/graficas/barra/barra.component';
import { BarraDobleComponent } from './dashboard/graficas/barra-doble/barra-doble.component';
import { DonaComponent } from './dashboard/graficas/dona/dona.component';
import { PieComponent } from './dashboard/graficas/pie/pie.component';
import { QuizComponent } from './modulo-educativo/quiz/quiz.component';
import { GaleriaGeneralComponent } from './galeria/galeria-general/galeria-general.component';
import { CardcomentarioComponent } from './comentarios/card/cardcomentario.component'
import { ViewcomentariosComponent } from './comentarios/view/viewcomentarios.component'


import { GisPinteresComponent} from '../modules/dashboard/dashmap/modules/PuntosInteres/gis-pinteres/gis-pinteres.component';
import { DatausuarioComponent } from './usuario/view/datausuario.component';
import { CardComponent } from './galeria/card/card.component';
import { TablaResumenComponent } from './dashboard/tabla-resumen/tabla-resumen.component';
import { SitiosInteresComponent } from './modulo-educativo/sitios-interes/sitios-interes.component';
import { DatosInteresComponent } from './modulo-educativo/datos-interes/datos-interes.component';
import { RankingComponent } from './modulo-educativo/ranking/ranking.component';





@NgModule({
  declarations: [

    LoginComponent,
    HomeComponent,
    DashboardComponent,
    GisComponent,
    UserComponent,
    HomeInstitucionalComponent,
    HomeUsuarioComponent,
    TriviaComponent,
    DesastreMemoriaComponent,
    PrepostcatastrofeComponent,
    ComentariosComponent,
    Home2Component,
    CaarouselComponent,
    GaleriaComponent,
    DashmapComponent,
    JuegaAprendeComponent,
    AcercaDeComponent,
    RegistroComponent,
    BarraComponent,
    BarraDobleComponent,
    DonaComponent,
    PieComponent,
    QuizComponent,
    GaleriaGeneralComponent,
    GisPinteresComponent,
    ViewcomentariosComponent,
    CardcomentarioComponent,
    DatausuarioComponent,
    CardComponent,
    TablaResumenComponent,
    SitiosInteresComponent,
    DatosInteresComponent,
    RankingComponent,

  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    KtdGridModule,
    ToastrModule,
    NgxPaginationModule,
    AgmCoreModule.forRoot({apiKey:"AIzaSyADsM5FOd2nrYv3l1EIYvx__3KgLUqBqR4"}),
    AgmDirectionModule,
    NgChartsModule,
    RouterModule,
    ReactiveFormsModule,


  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class ModulesModule { }
