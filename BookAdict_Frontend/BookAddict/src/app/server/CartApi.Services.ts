import { Injectable } from "@angular/core";
import { BaseApi } from "./BaseApi";
import { BehaviorSubject, Observable, map, tap } from "rxjs";
import { CartItem } from "../Models/CartItem";import { HttpClient, HttpClientModule } from "@angular/common/http";

@Injectable({
  providedIn:'root'
})
export class CartApis extends BaseApi{
  cartItems$ = new BehaviorSubject<CartItem[]>([])
  cartApiUrl:string = this.localhost + "api/Cart/"
  constructor(private http:HttpClient){
    super()
  }
  AddToCart(cartItem:CartItem):Observable<CartItem[]>{
    return this.http.post<CartItem[]>(this.cartApiUrl+"AddToCart",cartItem).pipe(tap(data => this.cartItems$.next(data)));
  }
  GetCart(userId:string):Observable<CartItem[]>{
    return this.http.get<CartItem[]>(this.cartApiUrl+`GetCart/${userId}`).
    pipe(
      tap(data =>this.cartItems$.next(data)));
  }
  DeleteCartItem(cartItem:CartItem):Observable<any>{
    this.cartItems$.pipe(map(items => items.filter(i => i.bookId != cartItem.bookId))).subscribe()
    return this.http.delete(this.cartApiUrl + `DeleteCartItem`,{body:cartItem})
  }
}
