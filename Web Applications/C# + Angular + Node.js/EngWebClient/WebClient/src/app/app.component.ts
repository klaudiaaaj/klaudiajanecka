import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
@Output() sidenavClose = new EventEmitter();
@ViewChild('sidenav') sidenav: MatSidenav | undefined;
 tokenicho: string|undefined ="";

  constructor(public auth: AuthService){
  }
  getUserCredentials()
  {   
   return this.auth.idTokenClaims$.subscribe({next(IdToken){
    }, error(msg?){
  }});
  }
  getAccessToken()  {
    this.auth.getAccessTokenSilently().subscribe();
  }
}