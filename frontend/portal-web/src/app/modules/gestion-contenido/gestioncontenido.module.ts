import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
//Comentarios
import {ViewcomentariosComponent} from "./modules/comentarios/view/viewcomentarios.component"
import {FormcomentarioComponent} from "./modules/comentarios/form/formcomentario.component"

//Escenario
import {FormescenarioComponent} from "./modules/escenario/form/formescenario.component"
import {ViewescenariosComponent} from "./modules/escenario/view/viewescenarios.component"

//Galeria
import { FormgaleriaComponent} from "./modules/galeria/form/formgaleria.component"

//Memoria
import { FormmemoriaComponent } from "./modules/memoria/form/formmemoria.component"
//puntos de interes
import{FormuntosinteresComponent} from "./modules/puntodeinteres/form/formpuntosinteres.component"
import{ViewpuntointeresComponent} from "./modules/puntodeinteres/view/viewpuntointeres.component"
//relatos
import { ViewrelatosComponent } from './modules/relatos/view/viewrelatos.component';
//datos usuario
import { DatausuarioComponent } from './modules/usuario/view/datausuario.component';
//forms
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//menu de opciones
import { MenuComponent} from "./menu/menu.component"
//pantalla principal
import { ViewdatosdeinteresComponent } from './modules/datosdeinteres/view/viewdatosdeinteres.component';
import { IndexComponent } from './view/index.component';
import { CarddatosdeinteresComponent } from './modules/datosdeinteres/card/carddatosdeinteres.component';
import { MaterialModule } from 'src/app/material/material.module';
import { CardcomentarioComponent} from './modules/comentarios/card/cardcomentario.component';
import { CardmemoriaComponent } from './modules/memoria/card/cardmemoria.component';
import { ViewmemoriaComponent } from './modules/memoria/view/viewmemoria.component';
import { CardrelatoComponent } from './modules/relatos/card/cardrelato.component';
import { ViewgaleriaComponent } from './modules/galeria/view/viewgaleria.component';
import { CardgaleriaComponent } from './modules/galeria/card/cardgaleria.component'
import { NgxPaginationModule} from 'ngx-pagination';
import { ImagenComponent } from './modules/imagen/imagen.component';
import { BuscadorComponent } from './modules/buscador/buscador.component';
import { FormdatosinteresComponent } from './modules/datosdeinteres/form/formdatosinteres.component';
import { FormrelatoComponent } from './modules/relatos/form/formrelato.component';
import { paginationss } from './pipe/paginationss.pipe';
import { FormslidesComponent } from './modules/slides/form/formslides.component';
import { CardslidesComponent } from './modules/slides/card/cardslides.component';
import { ViewslidesComponent } from './modules/slides/view/viewslides.component';
import { UpdateDirective } from './directives/update.directive';
import {  MatChipsModule } from '@angular/material/chips';
import {  MatIconModule } from '@angular/material/icon';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { SlidesEsComponent } from './modules/escenario/form/slides-es/slides-es.component';


@NgModule({
  declarations: [

    FormmemoriaComponent,
    ViewcomentariosComponent,
    FormcomentarioComponent,
    FormescenarioComponent,
    ViewescenariosComponent,
    FormgaleriaComponent,
    FormuntosinteresComponent,
    ViewpuntointeresComponent,
    ViewrelatosComponent,
    DatausuarioComponent,
    MenuComponent,
    ViewdatosdeinteresComponent,
    IndexComponent,
    CarddatosdeinteresComponent,
    CardcomentarioComponent,
    CardmemoriaComponent,
    ViewmemoriaComponent,
    CardrelatoComponent,
    ViewgaleriaComponent,
    CardgaleriaComponent,
    ImagenComponent,
    BuscadorComponent,
    FormdatosinteresComponent,
    FormrelatoComponent,
    paginationss,
    FormslidesComponent,
    CardslidesComponent,
    ViewslidesComponent,
    UpdateDirective,
    SlidesEsComponent,




  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    NgxPaginationModule,
    MatChipsModule,
    MatIconModule,
    MatFormFieldModule,


  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class gestioncontenidoModule { }
