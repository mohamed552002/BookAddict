import { Component, OnInit } from '@angular/core';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { CartItem } from '../../../Models/CartItem';
import { CartApis } from '../../../server/CartApi.Services';
import { AuthApis } from '../../../server/Auth.services';
import { OrderApis } from '../../../server/OrderApis/Order.Service';
import { CheckoutDto } from '../../../Models/CheckOutDto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-confirmation',
  templateUrl: './order-confirmation.component.html',
  styleUrl: './order-confirmation.component.css'
})
export class OrderConfirmationComponent implements OnInit {
  constructor( public cartApi:CartApis,public orderApis:OrderApis,public router:Router){}
  faTrashAlt = faTrashAlt
  isLoading:boolean = true
  price = {
    totalPrice : 0,
    discount : 0
  }
  cartItems:CartItem[] = [];
  ngOnInit(): void {
    this.cartApi.cartItems$.subscribe({
      next: data => {
        this.cartItems = data != null ? data : []
        data.map((d) => this.price.totalPrice +=  d.singlePrice* d.quantity)
        this.isLoading = false;
      }
    })

  }
  increaseQuantity(item:CartItem){
    ++item.quantity
    this.price.totalPrice += item.singlePrice
    console.log(this.price.totalPrice)
  }
  decreaseQuantity(item:CartItem){
    if(item.quantity>1)
    --item.quantity
  }
  confirmOrder(items:CartItem[],isCash,userID){
    var checkOut:CheckoutDto = new CheckoutDto(items,isCash,userID)
    this.orderApis.ConfirmOrder(checkOut).subscribe(data => window.location.href = data.payementLink)
  }
}
