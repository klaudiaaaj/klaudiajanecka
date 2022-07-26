import { Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationService {
  constructor(public auth: AuthService) {}

  ngOnInit(): void {}

  login() {
    this.auth.loginWithRedirect({
      appState: { target: '/authorized' },
    });
  }
  getRedirected() {
    this.getUserCredentials();
    this.getAccessToken();
    this.logout();
  }
  getUserCredentials() {
    return this.auth.idTokenClaims$.pipe(filter(this.isNonNull));
  }

  getAccessToken() {
    this.auth
      .getAccessTokenSilently()
      .subscribe();
  }

  logout() {
    this.auth.logout();
  }

  isNonNull<T>(value: T): value is NonNullable<T> {
    return value != null;
  }
}
