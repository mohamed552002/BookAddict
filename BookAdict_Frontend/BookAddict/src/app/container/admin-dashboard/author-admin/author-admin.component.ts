import { Component, OnInit } from '@angular/core';
import { faPlus, faPenToSquare, faTrash } from '@fortawesome/free-solid-svg-icons';
import { AuthorApiService } from '../../../server/AuthorApis/AuthorApi.service';
import { Author } from '../../../Models/Author';
@Component({
  selector: 'author-admin',
  templateUrl: './author-admin.component.html',
  styleUrl: './author-admin.component.css'
})
export class AuthorAdminComponent implements OnInit {
  faPlus = faPlus;
  faPenToSquare = faPenToSquare;
  faTrash = faTrash;
  dataLoaded:boolean = false;
  host:string
  allAuthors:Author[] = []
  constructor(private authorApi:AuthorApiService){}
  ngOnInit(){
    this.host = this.authorApi.localhost
    this.authorApi.getAllAuthors().subscribe((data) => {
      this.allAuthors = data
      this.dataLoaded = true
    });
  }
  deleteAuthor(author){
    const authorIdIndex = this.allAuthors.indexOf(author)
    console.log(authorIdIndex)
    this.allAuthors.splice(authorIdIndex,1)
    this.authorApi.deleteAuthor(author.id).subscribe();
  }
}
