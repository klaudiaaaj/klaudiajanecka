import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule } from '@angular/common/http'
import { AppComponent } from './app.component';
import {FormsModule, ReactiveFormsModule } from '@angular/forms'
import { InspectionComponent } from './inspection/inspection.component';
import { ConnectApiService } from './connect-api.service';
import { GetComponent } from './inspection/get/get.component';
import { AddComponent } from './inspection/add/add.component';
import { UpdateComponent } from './inspection/update/update.component';
import { DataLoaderService } from './data-loader.service';
import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AdsenseModule } from 'ng2-adsense'; 
@NgModule({
  declarations: [
    AppComponent,
    InspectionComponent,
    GetComponent,
    AddComponent,
    UpdateComponent, 
    LoginComponent, 
    
    ],
  imports: [
    BrowserModule, 
    HttpClientModule, 
    ReactiveFormsModule, 
    FormsModule,
    SocialLoginModule, RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full'},
      { path: 'inspections', component: InspectionComponent}]), 
      AdsenseModule.forRoot({ 
        adClient: 'ca-pub-1234567890123456', //replace with your client from google adsense 
            adSlot: '1234567890'    }), 
    
  ],
  providers: [ConnectApiService, DataLoaderService, {
    provide: 'SocialAuthServiceConfig',
    useValue: {
      autoLogin: false,
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider(
            '1094329592182-jramp01r6adttbobm3sb51gqci4jan2p.apps.googleusercontent.com'
          )
        }
      ]
    } as SocialAuthServiceConfig,
}],
  bootstrap: [AppComponent]
})
export class AppModule { }
