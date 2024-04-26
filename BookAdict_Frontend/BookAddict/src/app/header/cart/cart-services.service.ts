import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CartItem } from '../../Models/CartItem';
import { CartApis } from '../../server/CartApi.Services';
import { AuthApis } from '../../server/Auth.services';
import { User } from '../../Models/User';

@Injectable({
  providedIn: 'root'
})
export class CartServices {
  cartStatus$ = new BehaviorSubject<string>("")
  cartItems:CartItem[] = []
  constructor(private cartApi:CartApis,private user:AuthApis) { }

  addToCart(book,quantity=1){
    const cartItemToAdd:CartItem = new CartItem(book.id,book.imageUrl,book.title,book.price,quantity,this.getUser().id)
    this.cartApi.cartItems$.subscribe(data => {
      console.log(data)
      this.cartItems = data
    })
    if( this.cartItems== null || !this.cartItems.some(ci => ci.bookId == cartItemToAdd.bookId) ){
      this.cartApi.AddToCart(cartItemToAdd).subscribe(() =>     this.cartStatus$.next("Added"));
    }
    else
    this.cartStatus$.next("AddedPreviously")
  }
  getUser(){
    let user:User
    this.user.user.subscribe((data)=> user = data)
    return user
  }
}
