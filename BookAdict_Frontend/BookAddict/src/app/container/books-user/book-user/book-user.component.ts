import { Component, OnInit } from '@angular/core';
import { BookApis } from '../../../server/BookApis.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-user',
  templateUrl: './book-user.component.html',
  styleUrl: './book-user.component.css'
})
export class BookUserComponent implements OnInit {
book
constructor(private bookApi:BookApis,private route:ActivatedRoute){}
ngOnInit(): void {
  this.bookApi.GetBook(this.route.snapshot.params["id"]).subscribe({
    next: data => {
      this.book = data
    },
    error: err => err
  })
}
}
