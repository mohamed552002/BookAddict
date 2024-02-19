import { Component, OnInit } from '@angular/core';
import { Author } from '../../Models/Author';
import { AuthorApiService } from '../../server/AuthorApis/AuthorApi.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'authors-user',
  templateUrl: './authors-user.component.html',
  styleUrl: './authors-user.component.css'
})
export class AuthorsUserComponent implements OnInit {
  host:string = this.author.localhost;
  isLoading:boolean = true;
  authors:Author[]
  error:string

  constructor(private author:AuthorApiService,private router :Router , private route:ActivatedRoute){}

  ngOnInit(): void {
    var search = this.route.snapshot.queryParams["search"]
    if(search == null)
      this.GetAllAuthor();
    else
      this.GetSearchedAuthors(search);
  }

  SearchAuthor(searchForm){
    this.isLoading = true;
    if(searchForm.value.search === ""){
      this.GetAllAuthor()
      this.error = null;
    }
    else{
      this.GetSearchedAuthors(searchForm.value.search)
      this.error = null;
    }
  }

  private GetAllAuthor(){
    this.author.getAllAuthors().subscribe({
      next: (data) => {
        this.authors = data
        this.isLoading = false
      },
      error: (err:HttpErrorResponse) => console.log(err)
    })
  }
  private GetSearchedAuthors(searchText){
    this.author.searchAuthor(searchText).subscribe({
      next: data => {
        this.authors = data;
        this.isLoading = false;
        this.router.navigate(["./authors"],{queryParams:{"search":searchText}})
      },
      error: err => {
        this.authors = []
        this.error =(err.error.message)
        console.log("ssa")
        this.isLoading = false;
      }
  })
  }
}
