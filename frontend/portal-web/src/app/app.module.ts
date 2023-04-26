import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
// import { CoreModule } from '@core/core.module';
import { ModulesModule } from './modules/modules.module';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './core/components/header/header.component';
import { SidenavComponent } from './core/components/sidenav/sidenav.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { KtdGridModule } from '@katoid/angular-grid-layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import 'img-comparison-slider'
import { gestioncontenidoModule } from './modules/gestion-contenido/gestioncontenido.module';


@NgModule({
declarations: [
    AppComponent,
    HeaderComponent,
    SidenavComponent,

  ],
  imports: [
    NgbModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    gestioncontenidoModule,
    // CoreModule,
    ModulesModule,
    HttpClientModule,
    KtdGridModule,
    ToastrModule.forRoot(),
    NgxPaginationModule,



  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
