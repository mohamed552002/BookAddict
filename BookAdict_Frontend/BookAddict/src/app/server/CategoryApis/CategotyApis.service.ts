import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Category } from "../../Models/Category";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { BaseApi } from "../BaseApi";
@Injectable({
  providedIn:"root"
})
export class CategoryApisService extends BaseApi {
private apiUrl = this.localhost + "api/Category/";
constructor(private http:HttpClient) {
  super()
}
postCategory(Category:Category):Observable<any>{
  return this.http.post<any>(`${this.apiUrl}AddCategory`,Category);
}
getAllCategories():Observable<any>{
  return this.http.get(`${this.apiUrl}GetAllCategories`)
}
getCategory(id:number):Observable<any>{
  return this.http.get(`${this.apiUrl}GetCategory/${id}`)
}
updateCategory(categoryUpdated :Category):Observable<any>{
  return this.http.put<Category>(`${this.apiUrl}UpdateCategory`,categoryUpdated);
}
deleteCategory(categoryId):Observable<any>{
  return this.http.delete<any>(`${this.apiUrl}DeleteCategory/${categoryId}`);
}
}
