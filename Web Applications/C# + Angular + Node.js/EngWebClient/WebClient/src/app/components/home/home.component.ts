import { Component, OnInit } from '@angular/core';
import {
  FormBuilder, FormGroup
} from '@angular/forms';
import {
  MatSnackBar
} from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApiUserServiceService } from 'src/app/services/api-user-service.service';
import { AuthorizationService } from 'src/app/services/authorization.service';
import { RegisterService } from 'src/app/services/register-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  usernick: string = '';
  public loginForm!: FormGroup;

  constructor(
    public authService: AuthorizationService,
    protected router: Router,
    protected snackBar: MatSnackBar,
    protected formBuilder: FormBuilder,
    protected userService: ApiUserServiceService,
    protected toastr: ToastrService,
    protected registerService: RegisterService
  ) {}

  ngOnInit(): void {}
}
