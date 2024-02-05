import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpParams, HttpRequest } from "@angular/common/http";
import { Observable, exhaustMap, take } from "rxjs";
import { AuthApis } from "../../server/Auth.services";

@Injectable()
export class AuthInterceptor implements HttpInterceptor{
  constructor(private authService : AuthApis){}
  intercept(req: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    if(typeof localStorage !== "undefined"){
    const token = localStorage.getItem("jwtToken");
    if(token){
      req = req.clone({
        setHeaders: {Authorization: `Bearer ${token}`}
      });
    }
  }
    return next.handle(req)
  }

}
