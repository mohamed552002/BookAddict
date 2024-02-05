import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";
import { json } from "stream/consumers";
import { BaseApi } from "./BaseApi";
import { error } from "console";

@Injectable({
  providedIn:"root"
})
export class BookApis extends BaseApi{
  private apiUrl =  this.localhost +"api/Book/";
  constructor(private http:HttpClient){
    super()
  }
  PostBook(book:any):Observable<any>{
    return this.http.post(`${this.apiUrl}AddBook`,book).pipe();
  }
  GetBooks():Observable<any>{
    return this.http.get(`${this.apiUrl}GetAllBooks`);
  }
  GetBook(id:number):Observable<any>{
    return this.http.get(`${this.apiUrl}GetBookById/${id}`);
  }
  updateBook(book:any):Observable<any>{
    return this.http.put(`${this.apiUrl}UpdateBook`,book);
  }
}
