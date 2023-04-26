import { HomeComponent } from './modules/home/home.component';
import { DashboardComponent } from './modules/dashboard/dashboard/dashboard.component';
import { GisComponent } from './modules/gis/gis.component';
import { DesastreMemoriaComponent} from './modules/desastre-memoria/desastre-memoria.component'
import { HomeInstitucionalComponent} from './modules/home-institucional/home-institucional.component'
import { HomeUsuarioComponent } from './modules/home-usuario/home-usuario.component';
import { TriviaComponent } from './modules/modulo-educativo/trivia-welcome/trivia.component';
import { PrepostcatastrofeComponent} from './modules/prepostcatastrofe/prepostcatastrofe.component';
import { ComentariosComponent } from './modules/comentarios 2/comentarios.component';
import { Home2Component } from './modules/home2/home2.component';
import { GaleriaComponent } from './modules/galeria/galeria-especifica/galeria.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { LoginComponent } from './modules/login/login.component';
import { AuthGuard } from './core/guards/auth.guard';
import { DashmapComponent } from './modules/dashboard/dashmap/dashmap.component';
import { JuegaAprendeComponent } from './modules/modulo-educativo/juega-aprende/juega-aprende.component';
import { AcercaDeComponent } from './modules/acerca-de/acerca-de.component';
import { RegistroComponent } from './modules/registro/registro.component';
import { QuizComponent } from './modules/modulo-educativo/quiz/quiz.component';
import { GaleriaGeneralComponent } from './modules/galeria/galeria-general/galeria-general.component';
import { IndexComponent } from './modules/gestion-contenido/view/index.component';
import { ViewcomentariosComponent } from './modules/comentarios/view/viewcomentarios.component';
import { SitiosInteresComponent } from './modules/modulo-educativo/sitios-interes/sitios-interes.component';
import { DatosInteresComponent } from './modules/modulo-educativo/datos-interes/datos-interes.component';


const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'login',
        pathMatch: 'full',
        component: LoginComponent
    },
    {
        path: 'home',
        component: Home2Component,
    },
    {
        path: 'dashboard',
        component: DashboardComponent,
    },
    {
        path: 'geo',
        component: GisComponent,
    },
    {
        path: 'usuario',
        pathMatch: 'full',
        component: HomeUsuarioComponent
    },
    {
        path: 'institucional',
        pathMatch: 'full',
        component: HomeInstitucionalComponent
    },
    {
        path: 'memoria',
        pathMatch: 'full',
        component: DesastreMemoriaComponent
    },
    {
        path: 'trivia',
        pathMatch: 'full',
        component: TriviaComponent
    },
    {
        path: 'comentarios',
        pathMatch: 'full',
        component: ViewcomentariosComponent
    },
    {
        path: 'prepostcatastrofe',
        pathMatch: 'full',
        component: PrepostcatastrofeComponent
    },
    {
        path: 'map',
        pathMatch: 'full',
        component: DashmapComponent
    },
    {
        path: 'login',
        pathMatch: 'full',
        component: LoginComponent
    },
    {
        path: 'galeria',
        pathMatch: 'full',
        component: GaleriaComponent
    },
    {
        path: 'juegayaprende',
        pathMatch: 'full',
        component: JuegaAprendeComponent
    },
    {
        path: 'acercade',
        pathMatch: 'full',
        component: AcercaDeComponent
    },
    {
        path: 'registro',
        pathMatch: 'full',
        component: RegistroComponent
    },
    {
        path: 'quiz',
        pathMatch: 'full',
        component: QuizComponent
    },
    {
        path: 'galeriageneral',
        pathMatch: 'full',
        component: GaleriaGeneralComponent
    },
    {
      path:'gcontenido',
      pathMatch: 'full',
      component:IndexComponent
    },
    {
       path:'sitiosinteres',
       pathMatch: 'full',
       component:SitiosInteresComponent
    },
    {
        path:'datosinteres',
        pathMatch: 'full',
        component:DatosInteresComponent
     }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
