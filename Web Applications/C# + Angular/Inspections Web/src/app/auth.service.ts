import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private path = "https://localhost:7298/api";

  constructor(private httpClient: HttpClient) { }

  public signOutExternal = () => {
    localStorage.removeItem("token");
    console.log("token deleted")
  }


  public tokenExpired() {
    var token = localStorage.getItem("token");
    if (token !== null) {
      const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
      var res= (Math.floor((new Date).getTime() / 1000)) <= expiry;
      return res;
    }
    else return false;
  }

}