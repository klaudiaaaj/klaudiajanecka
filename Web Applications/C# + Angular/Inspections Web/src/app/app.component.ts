import { Component } from '@angular/core';
import { SocialAuthService  } from 'angularx-social-login';
import { SocialUser } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user: SocialUser | null; 
  title = 'inspection-web';
 onInit(){}
  constructor(private authService: SocialAuthService) 
  { 
	this.user = null;
	this.authService.authState.subscribe((user: SocialUser) => {
	  console.log(user);
	  this.user = user;
	});
  }

  signInWithGoogle(): void {
    console.log("log")
    console.log(this.authService);
    console.log(GoogleLoginProvider.PROVIDER_ID)

    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  signOut(): void {
    this.authService.signOut();
  }  
}