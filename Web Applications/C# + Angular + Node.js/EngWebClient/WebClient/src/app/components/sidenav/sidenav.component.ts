import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  currentUser = {} as String| null; 
  constructor(public auth: AuthService) { }

  ngOnInit(): void {
   this.currentUser=localStorage.getItem("CurrentUsr"); 
  }

  logout(){
    localStorage.removeItem("CurrentUsr")
    this.auth.logout();
   }   
}
