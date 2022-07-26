import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RegisterUserDto, User } from '../models/UserDto';

@Injectable({
  providedIn: 'root',
})
export class LoginServiceService {
  isUserLoggedIn: boolean = false;
  constructor(protected httpClient: HttpClient) {}
  users: RegisterUserDto[] = [];

  getUsers() {
    return this.httpClient.get<User[]>(environment.baseUrl + '/Users');
  }
}
