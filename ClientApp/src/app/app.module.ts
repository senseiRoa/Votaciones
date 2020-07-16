import { RondaVotacionDetalleComponent } from './vistas/ronda-votacion-detalle/ronda-votacion-detalle.component';
import { VotacionDetalleComponent } from './vistas/votacion-detalle/votacion-detalle.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { VotacionComponent } from './vistas/votacion/votacion.component';

import { CandidatoComponent } from './vistas/candidato/candidato.component';
import { ResultadosComponent } from './vistas/resultados/resultados.component';
import { VotarComponent } from './vistas/votar/votar.component';

import { PanelModule } from 'primeng/panel';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ToastModule } from 'primeng/toast';
import { MessageService, ConfirmationService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { StepsModule } from 'primeng/steps';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputTextModule } from 'primeng/inputtext';
import { CaptchaModule } from 'primeng/captcha';
import { FileUploadModule } from 'primeng/fileupload';
import { DialogModule } from 'primeng/dialog';
import { CheckboxModule } from 'primeng/checkbox';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { MultiSelectModule } from 'primeng/multiselect';
import { TabViewModule } from 'primeng/tabview';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ChartModule } from 'primeng/chart';
import { ConfirmDialogModule } from 'primeng/confirmdialog';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    VotacionComponent,
    CandidatoComponent,
    ResultadosComponent,
    VotarComponent,
    VotacionDetalleComponent,
    RondaVotacionDetalleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    NgbPaginationModule, NgbAlertModule,
    BrowserAnimationsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      // { path: 'counter', component: CounterComponent },
      { path: 'votacion', component: VotacionComponent, canActivate: [AuthorizeGuard] },
      { path: 'votacion/:id', component: VotacionDetalleComponent, canActivate: [AuthorizeGuard] },
      { path: 'ronda/:id', component: RondaVotacionDetalleComponent, canActivate: [AuthorizeGuard] },
      { path: 'voto/:id', component: VotarComponent, canActivate: [AuthorizeGuard] },
      { path: 'candidato', component: CandidatoComponent, canActivate: [AuthorizeGuard] },
      // { path: 'ronda', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      // { path: 'voto', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      // { path: 'resultado', component: FetchDataComponent, canActivate: [AuthorizeGuard] }

    ]),
    PanelModule,
    ScrollPanelModule,
    MessagesModule,
    MessageModule,
    ToastModule,
    StepsModule,
    ButtonModule,
    DropdownModule,
    InputTextareaModule,
    InputTextModule,
    FileUploadModule,
    CaptchaModule,
    DialogModule,
    CheckboxModule,
    TableModule,
    CalendarModule,
    MultiSelectModule,
    TabViewModule,
    RadioButtonModule,
    ChartModule,
    ConfirmDialogModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    MessageService, ConfirmationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
