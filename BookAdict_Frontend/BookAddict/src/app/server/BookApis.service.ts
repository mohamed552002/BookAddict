import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { json } from "stream/consumers";

@Injectable({
  providedIn:"root"
})
export class BookApis{
  private apiUrl = "https://localhost:7153/api/Book/";
  constructor(private http:HttpClient){}
  PostBook(book:any):Observable<any>{
    return this.http.post(`${this.apiUrl}AddBook`,book);
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
