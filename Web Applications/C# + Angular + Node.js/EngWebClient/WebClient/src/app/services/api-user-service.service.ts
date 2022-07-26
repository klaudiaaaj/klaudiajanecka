import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IdTokenGetDto } from '../models/IdTokenDto';
import { User } from '../models/UserDto';

@Injectable({
  providedIn: 'root',
})
export class ApiUserServiceService {
  constructor(protected httpClient: HttpClient) {}

  public getUserList(): Observable<User[]> {
    return this.httpClient.get<User[]>(environment.baseUrl + '/Users');
  }

  getUserDiscord() {
    return this.httpClient
      .get(environment.baseUrl + '/Users')
      .toPromise()
  }

  getUserById(): Observable<User> {
    return this.httpClient.get<User>(
      environment.baseUrl + `/Users/${localStorage.getItem('CurrentUsr')}`
    );
  }

  async discordValidation(): Promise<boolean> {
    return this.httpClient
      .get<boolean>(
        environment.baseUrl +
          `/Users/discord/${localStorage.getItem('CurrentUsr')}`
      )
      .toPromise();
  }

  async githubValidation() {
    return this.httpClient
      .get<boolean>(
        environment.baseUrl +
          `/Users/github/${localStorage.getItem('CurrentUsr')}`
      )
      .toPromise();
  }

  async userTokenUpdate(userId: number, platformId: number, idToken: number) {
    return await this.httpClient.put<IdTokenGetDto>(
      environment.baseUrl +
        `/Users/platformTokenId/${userId}/${platformId}/${idToken}`,
      {}
    );
  }
}
