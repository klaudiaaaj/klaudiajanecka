import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { RegisterUserDto, User } from '../models/UserDto';
import { LoginServiceService } from './login-service.service';

@Injectable({
  providedIn: 'root',
})
export class RegisterService extends LoginServiceService {
  isUserLoggedIn: boolean = false;
  constructor(
    protected httpClient: HttpClient,
    protected toastr: ToastrService
  ) {
    super(httpClient);
  }
  users: RegisterUserDto[] = [];

  async createNewUser(nickname: string, password: string) {
    return this.httpClient
      .post<User>(`${environment.baseUrl}/Users/Register/${nickname}`, {
        password,
      })
      .toPromise()
      .catch((err: HttpErrorResponse) => {
        this.toastr.error('Nickname is in use', 'Failed');
      });
  }
}
