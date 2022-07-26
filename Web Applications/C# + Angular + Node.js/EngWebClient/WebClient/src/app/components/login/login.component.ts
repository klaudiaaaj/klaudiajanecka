import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import * as bcrypt from 'bcryptjs';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/UserDto';
import { ApiUserServiceService } from 'src/app/services/api-user-service.service';
import { AuthorizationService } from 'src/app/services/authorization.service';
import { RegisterService } from 'src/app/services/register-service.service';
import { HomeComponent } from '../home/home.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./../home/home.component.css']
})
export class LoginComponent extends HomeComponent {
  usernick: string =""; 
  public loginForm!: FormGroup;

  constructor(public authService: AuthorizationService, protected router: Router,protected snackBar: MatSnackBar, protected formBuilder: FormBuilder, protected userService: ApiUserServiceService, protected toastr: ToastrService, protected registerService: RegisterService, ) { 
    super(authService,router, snackBar, formBuilder, userService, toastr, registerService);
  }

  ngOnInit(): void {
    this.createStartFormLogin();
  }
  createStartFormLogin(){
    this.loginForm = this.formBuilder.group({
      nickname:[''],
      password:['']
    })
  }
  login(){
    this.registerService.getUsers().subscribe(res =>{
        const user = res.find((user:User)=>{
          return user.appNickname === this.loginForm.value.nickname && bcrypt.compareSync(this.loginForm.value.password, user.password);
        });   
      if(user){
        this.registerService.isUserLoggedIn = true;
        this.authService.login();
        localStorage.setItem("CurrentUsr", user.userId.toString())
      }
      else{        
        this.toastr.error("User not found", "Error")
        this.submitForm;
        this.registerService.isUserLoggedIn = false;
      }
    })
  }
  
  submitForm(){
    if(this.loginForm!==undefined)
    this.loginForm.reset();
    this.createStartFormLogin();
}

}
