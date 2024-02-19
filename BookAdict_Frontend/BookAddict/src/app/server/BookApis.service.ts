import { HttpClient, HttpParams } from "@angular/common/http";
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
  GetBooks(sortBy:string = "" , categoryName:string = ""):Observable<any>{
    return this.http.get(`${this.apiUrl}GetAllBooks`,{
      params: new HttpParams().set("sortBy" , sortBy ).set("categoryName" , categoryName)
    });
  }
  SearchBooks(searchText):Observable<any>{
    return this.http.get(`${this.apiUrl}SearchBookByName`,{
      params: new HttpParams().set("searchText" , searchText)
    })
  }
  GetBook(id:number):Observable<any>{
    return this.http.get(`${this.apiUrl}GetBookById/${id}`);
  }
  updateBook(book:any):Observable<any>{
    return this.http.put(`${this.apiUrl}UpdateBook`,book);
  }
}
