import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule } from '@auth0/auth0-angular';
import { OAuthModule } from 'angular-oauth2-oidc';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { PlatformsComponent } from './components/platforms/platforms.component';
import { RegisterComponent } from './components/register/register.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { MaterialModule } from './material.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageNotFoundComponent,
    PlatformsComponent,
    LoginComponent, RegisterComponent, 
    SidenavComponent
  ],
  imports: [
    BrowserModule,
    MatSnackBarModule,
    AppRoutingModule, MatListModule, MatSidenavModule, MatIconModule, MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule, 
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    MatTabsModule,
    ReactiveFormsModule,
    MatCardModule, 
    FormsModule,
    OAuthModule.forRoot(),
    ToastrModule.forRoot(),
    AuthModule.forRoot({
      domain: 'dev-ohbkk21r.us.auth0.com',
      clientId: 'ky4NW1ToPGJUENs7h9CtoASwdxV5o1VA',
      redirectUri: 'https://angular-8d2bf.web.app/authorized', skipRedirectCallback: false
    }), 
  ],
  providers: [
    {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {floatLabel: 'always'}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
