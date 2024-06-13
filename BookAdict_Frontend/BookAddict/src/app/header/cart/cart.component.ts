import { Component, OnDestroy, OnInit } from '@angular/core';
import { CartItem } from '../../Models/CartItem';
import { CartApis } from '../../server/CartApi.Services';
import { AuthApis } from '../../server/Auth.services';
import { User } from '../../Models/User';
import { Subscription } from 'rxjs';
import { faCartShopping, faTrash } from '@fortawesome/free-solid-svg-icons';
import { CartServices } from './cart-services.service';
import { Route, Router } from '@angular/router';

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
  cartStatusSub:Subscription
  user:User;
  cartStatus = {
    Added:false,
    AddedPreviously:false,
    Removed:false
  }
  private userSub:Subscription;
  constructor(private authApis:AuthApis, protected cartApi:CartApis,private cartServices:CartServices,private router:Router){}
  ngOnInit(){
    this.cartApi.cartItems$.subscribe({
      next: data => {
        this.cartItems = data != null ? data : []
        this.cartItemsNum = this.cartItems.length
        this.isCartEmpty = this.cartItems.length == 0
      }
    })
    this.HandleCartStatus()
    this.userSub = this.authApis.user.subscribe(user => {
      this.user = user
    })
    this.GetCartItems()
  }

  deleteFromCart(item:CartItem){


    this.cartApi.DeleteCartItem(item).subscribe(
      (data) => {
        this.cartItems.splice(this.cartItems.indexOf(item),1);
        this.cartServices.cartStatus$.next("Removed");
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
  HandleCartStatus(){
    this.cartServices.cartStatus$.subscribe(status => {
      switch(status){
      case "Added": this.cartStatus = {
        Added:true,
        AddedPreviously:false,
        Removed:false
      }
      break;
      case "AddedPreviously": this.cartStatus = {
        Added:false,
        AddedPreviously:true,
        Removed:false
      }
      break;
      case "Removed": this.cartStatus = {
        Added:false,
        AddedPreviously:false,
        Removed:true
      }
      break;
      default:
        break;
      }
      setTimeout(()=>  this.cartStatus = {
        Added:false,
        AddedPreviously:false,
        Removed:false
      },1500)
    })
  }
  checkout(){
    this.router.navigate(["/orderConfirmation/"])
  }

  ngOnDestroy(){
    this.userSub.unsubscribe()
    // this.cartStatusSub.unsubscribe()
  }

}
