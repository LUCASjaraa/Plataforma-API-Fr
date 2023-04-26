import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
// import { FooterComponent } from './components/footer/footer.component'; 
import { MaterialModule } from '../material/material.module';
import { SidenavComponent } from './components/sidenav/sidenav.component';

@NgModule({
  declarations: [
      // FooterComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class CoreModule { }
