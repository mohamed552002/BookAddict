import { Component } from '@angular/core';
import { AuthApis } from '../../server/Auth.services';
import { error } from 'console';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ApplicationUser } from '../../Models/ApplicationUser.model';
import { userInfo } from 'os';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class AuthenticationComponent {
InLoginMode:boolean = true;
isLoading:boolean = false;
error:string;

constructor(private authApis:AuthApis , private router :Router){}

//#region  Login
Login(loginForm){
  this.authApis.Login(loginForm.value.email,loginForm.value.password).subscribe({

      next:(response) => {
        this.router.navigate([""]);
        this.isLoading = true;
        loginForm.reset();
        console.log(response)
        localStorage.setItem('jwtToken',response.token);
      },
      error:(errorMessage:HttpErrorResponse) => {this.error = errorMessage.error.message}})
    }
//#endregion

//#region Sign Up Method
signupSubmit(signupForm : NgForm){
  if(!signupForm.valid)
    return;
  const user:ApplicationUser = new ApplicationUser(signupForm.value.Fname,signupForm.value.Lname,signupForm.value.email,signupForm.value.password);
  this.authApis.SignUp(user).subscribe(res => {
    this.isLoading = true;
    this.InLoginMode = true;
    console.log(res);
    signupForm.reset();
  },error => console.log(error));
}
//#endregion

//#region Switch Mode
switchMode(){
  this.InLoginMode = !this.InLoginMode;
}
//#endregion
}
