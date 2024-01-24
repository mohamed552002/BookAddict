import { Component, OnInit } from '@angular/core';
import { faPlus, faPenToSquare, faTrash } from '@fortawesome/free-solid-svg-icons';
import { BookApis } from '../../../server/BookApis.service';
@Component({
  selector: 'app-book-admin',
  templateUrl: './book-admin.component.html',
  styleUrl: './book-admin.component.css'
})
export class BookAdminComponent implements OnInit {
  faPlus = faPlus;
  faPenToSquare = faPenToSquare;
  faTrash = faTrash;
  isLoaded:boolean = false;
  books:any[] = []
  constructor(private bookApis:BookApis){}
  ngOnInit(){
    this.bookApis.GetBooks().subscribe(data => {
      this.books = data;
      this.isLoaded = true;
    })
  }
}
