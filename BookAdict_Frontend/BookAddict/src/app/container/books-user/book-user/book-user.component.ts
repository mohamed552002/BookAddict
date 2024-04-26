import { Component, OnInit } from '@angular/core';
import { BookApis } from '../../../server/BookApis.service';
import { ActivatedRoute } from '@angular/router';
import { CartServices } from '../../../header/cart/cart-services.service';

@Component({
  selector: 'app-book-user',
  templateUrl: './book-user.component.html',
  styleUrl: './book-user.component.css'
})
export class BookUserComponent implements OnInit {
book:any = '';
isLoading:boolean = true;
imgUrl
constructor(private bookApi:BookApis,private route:ActivatedRoute,private cartServices:CartServices){}
ngOnInit(): void {
  this.bookApi.GetBook(this.route.snapshot.params["id"]).subscribe({
    next: data => {
      this.book = data
      this.imgUrl = this.bookApi.localhost + data.imageUrl;
      this.isLoading = false;
    },
    error: err => err
  })
}
addToCart(book,form){
  this.cartServices.addToCart(book,form.value.quantity);
}
}
