import { Component, OnInit, NgZone } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';
import { environment } from 'src/environments/environment';
import { AuthService } from '../auth.service';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private clientId = '1094329592182-jramp01r6adttbobm3sb51gqci4jan2p.apps.googleusercontent.com'
  
client: any; 

  constructor(
    private router: Router,
    private service: AuthService,
    private _ngZone: NgZone) { }

    ngOnInit(): void {
      // @ts-ignore
      window.onGoogleLibraryLoad = () => {
        // @ts-ignore
        google.accounts.id.initialize({
          client_id: this.clientId,
          callback: this.handleCredentialResponse.bind(this),
          auto_select: false,
          cancel_on_tap_outside: true
        });
        // @ts-ignore
        google.accounts.id.renderButton(
        // @ts-ignore
        document.getElementById("buttonDiv"),
          { theme: "outline", size: "large", width: "100%" } 
        );
        // @ts-ignore
        google.accounts.id.prompt((notification: PromptMomentNotification) => {});
      };
    }
    getDecodedAccessToken(token: string): any {
      try {
        return jwt_decode(token);
      } catch(Error) {
        return null;
      }
    }
    async handleCredentialResponse(response: CredentialResponse) {
      console.log('login', response)

    //  return ticket
    var res= this.getDecodedAccessToken(response.credential)

      if(res!=null)
    {
      this._ngZone.run(() => {
        localStorage.setItem("name", res.name);
        localStorage.setItem("email", res.email);
        localStorage.setItem("token", response.credential);


        this.router.navigate(['/inspections']);
      })
    }
  }
}