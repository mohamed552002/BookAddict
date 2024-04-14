import { Component, Input, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { BookApis } from '../../../../server/BookApis.service';
import { BooksUserComponent } from '../../books-user.component';
import { Router } from '@angular/router';
import { faRightLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'relevant-books',
  templateUrl: './relevant-books.component.html',
  styleUrl: './relevant-books.component.css'
})
export class RelevantBooksComponent implements OnInit {
  books:any = "";
  host:string = this.bookApi.localhost;
  @Input() categoryId:number = 0;
  constructor(private bookApi:BookApis , private router:Router){}
  ngOnInit(): void {
    this.bookApi.getBookByCategoryid(this.categoryId).subscribe({
      next : (data) => {
        this.books = data
      }
    })
  }
  addToCart(book){
    console.log(book)
  }
  NavigateBook(book){
    this.router.navigate([`./books/${book.id}`]);
  }
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: false,
    navSpeed: 700,
    navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      940: {
        items: 4
      }
    },
    nav: true
  }
}
