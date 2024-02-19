import { Component, OnInit } from '@angular/core';
import { AuthApis } from '../../../server/Auth.services';
import { User } from '../../../Models/User';

@Component({
  selector: 'sidebar-dashboard',
  templateUrl: './sidebar-dashboard.component.html',
  styleUrl: './sidebar-dashboard.component.css'
})
export class SidebarDashboardComponent implements OnInit {
constructor(private authService : AuthApis){}
user:User;
ngOnInit(){
  this.authService.user.subscribe( {
    next : ( user ) => {this.user = user
    }
  })
}
}
