import { HttpClient } from "@angular/common/http";
import { Injectable, numberAttribute } from "@angular/core";
import { Author } from "../../Models/Author";
import { Observable } from "rxjs";

@Injectable({
  providedIn:'root'
})
export class AuthorApiService{
  public localhost = "https://localhost:7153/"
  private apiUrl = this.localhost +"api/Author/";
  constructor(private http:HttpClient){}
  postAuthor(author:any):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}AddAuthor`,author)
  }

  getAllAuthors():Observable<any>{
    return this.http.get(`${this.apiUrl}GetAllAuthors`)
  }
  getAuthor(id:number):Observable<any>{
    return this.http.get(`${this.apiUrl}GetAuthor/${id}`);
  }
  updateAuthor(author:any):Observable<any>{
    return this.http.put(`${this.apiUrl}UpdateAuthor`,author);
  }
  deleteAuthor(id:number):Observable<any>{
    return this.http.delete(`${this.apiUrl}DeleteAuthor/${id}`);
  }
}
