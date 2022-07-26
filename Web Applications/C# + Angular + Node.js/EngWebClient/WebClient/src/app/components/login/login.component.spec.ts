import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthModule } from '@auth0/auth0-angular';
import { OAuthModule } from 'angular-oauth2-oidc';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './login.component';


describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({   
       imports: [
        RouterTestingModule, 
        BrowserModule,
        MatSnackBarModule, MatListModule, MatSidenavModule, MatIconModule, MatToolbarModule,
        MatFormFieldModule,
        MatInputModule,
        HttpClientModule, 
        BrowserAnimationsModule,
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
        }), , 
    ],
      declarations: [ LoginComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
