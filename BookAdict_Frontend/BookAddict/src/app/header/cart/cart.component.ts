import { Component, OnDestroy, OnInit } from '@angular/core';
import { CartItem } from '../../Models/CartItem';
import { CartApis } from '../../server/CartApi.Services';
import { AuthApis } from '../../server/Auth.services';
import { User } from '../../Models/User';
import { Subscription } from 'rxjs';
import { faCartShopping, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: '../header.component.css'
})
export class CartComponent implements OnInit, OnDestroy {
  faCartShopping = faCartShopping;
  faTrash = faTrash;
  cartItems:CartItem[] = [];
  oldCartItemNum:number = 0;
  cartItemsNum:number = 0;
  isCartEmpty:boolean = true
  user:User;
  cartStatus = {
    Added:false,
    AddedPreviously:false,
    Removed:false
  }
  private userSub:Subscription;
  constructor(private authApis:AuthApis, protected cartApi:CartApis){}
  ngOnInit(){
    console.log(this.cartItems.length)
    this.cartApi.cartItems$.subscribe({
      next: data => {
        this.cartItems = data != null ? data : []
        console.log(this.cartItems)
        this.cartItemsNum = this.cartItems.length
        console.log(this.cartItemsNum)
        this.isCartEmpty = this.cartItems.length == 0

      }

    })
    console.log(this.cartItems)
    this.userSub = this.authApis.user.subscribe(user => {
      console.log(user)
      this.user = user
    })
    this.GetCartItems()
  }

  deleteFromCart(item:CartItem){


    this.cartApi.DeleteCartItem(item).subscribe(
      (data) => {
        this.cartItems.splice(this.cartItems.indexOf(item),1);

      }
    )
    this.cartItemsNum--
    this.isCartEmpty = this.cartItemsNum <= 0
    console.log(this.cartItemsNum)
  }

  GetCartItems(){
    if(this.user)
      this.cartApi.GetCart(this.user.id).subscribe(data => this.cartItems =data);
  }
  ngOnDestroy(){
    this.userSub.unsubscribe()
  }
}
