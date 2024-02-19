import { Injectable } from "@angular/core";
import { BaseApi } from "./BaseApi";
import { BehaviorSubject, Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";
import { User } from "../Models/User";
import { ApplicationUser } from "../Models/ApplicationUser.model";

@Injectable({
  providedIn:"root"
})
export class AuthApis extends BaseApi {
  apiUrl:string = this.localhost + "api/Auth/";
  user = new BehaviorSubject<User>(null);
  constructor(private http:HttpClient){
    super();
    if(typeof localStorage !== "undefined"){
    const storedUser = localStorage.getItem('User');
    if (storedUser) {
      const parsedUser = JSON.parse(storedUser);
      this.user.next(parsedUser);
  }
}
}
  public SignUp(user : ApplicationUser):Observable<any>{
    return this.http.post<User>(this.apiUrl+"Register",user)
  }

  public Login(email:string , password:string):Observable<any>{
    return this.http.post(this.apiUrl+"GetToken",{
      Email :email,
      Password:password
    }).pipe(catchError(error =>  throwError(() => error)),tap(resData => {
      const user = new User(resData.firstName,resData.lastName,resData.email,resData.roles,resData.token,resData.expireson,resData.isAuthenticated,resData.message);
      this.user.next(user);
      localStorage.setItem("User",JSON.stringify(user));
    }))
  }
}
