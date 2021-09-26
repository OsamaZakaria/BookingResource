import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CommonModule } from '@angular/common';
import { SharedModule } from './shared/shared.module';
import { MaterialComponentsModule } from './shared/material-components.module';
import { ResourceComponent } from './resources/resource.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookResourceDialogComponent } from './resources/bookResourceDialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ResourceComponent,
    BookResourceDialogComponent,
    HomeComponent,
    FetchDataComponent
  ],
  entryComponents: [BookResourceDialogComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MaterialComponentsModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'resource', component: ResourceComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
