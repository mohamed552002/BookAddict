import { Component, Input, OnChanges } from '@angular/core';
import { serialize } from 'object-to-formdata';
import { OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { AuthorApiService } from '../../../../server/AuthorApis/AuthorApi.service';
import { CategoryApisService } from '../../../../server/CategoryApis/CategotyApis.service';
import { BookApis } from '../../../../server/BookApis.service';
import { Router } from '@angular/router';

@Component({
  selector: 'add-book',
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent implements OnInit {
  authors: any[] = []
  authorsChecked: any[] = [];
  formgroup:FormGroup;
  imgFile:File;
  faPlus = faPlus;
  author:any[]=[];
  categories:any[] = [];
  formData:FormData = new FormData();
  authorSelected:boolean = true;
  isCategoryLoaded = false;
  isAuthorLoaded = false;
constructor(private authorApis:AuthorApiService , private categoryApis:CategoryApisService , private bookApis:BookApis , private router:Router){}
url:any = "";
ngOnInit(){
  this.authorApis.getAllAuthors().subscribe((data) => {
    this.authors = data
    this.isAuthorLoaded = true;
  })
  this.categoryApis.getAllCategories().subscribe((data) => {
    this.categories = data
    this.isCategoryLoaded = true;
  })
  this.handleApiDataForm();

}
checked(author){
  if(!this.authorsChecked.includes(author.id)){
    this.authorsChecked.push(author.id)
    console.log(this.authorsChecked)
  }
  else{
    const indexOfAuthor = this.authorsChecked.indexOf(author.id)
    this.authorsChecked.splice(indexOfAuthor,1)
    console.log(this.authorsChecked)
  }
}
setImage(event:any){
  this.imgFile = event.target.files[0];
  this.formData.append("ImgFile",this.imgFile,this.imgFile.name);
  let reader = new FileReader();
  reader.readAsDataURL(event.target.files[0]);
  reader.onload = (_event) => this.url = reader.result;
  console.log(this.url)
}
submitForm(){
  if(this.formgroup.valid && this.authorsChecked.length>0){
  this.authorSelected = true;

  const requestData = {
    "Title" : this.formgroup.get("title").value,
    "ImgFile" : this.formData.get("ImgFile"),
    "ispn": this.formgroup.get("ISPN").value,
    "description" : this.formgroup.get("description").value,
    "price" : this.formgroup.get("price").value,
    "availableInStock" : this.formgroup.get("inStock").value,
    "numberOfSales" : this.formgroup.get("numOfSales").value,
    "isActive" : this.formgroup.get("isactive").value,
    "CategoryId" : this.formgroup.get("categories").value,
    "AuthorsIds" : this.authorsChecked
  }
  const formdata = serialize(requestData);
  this.bookApis.PostBook(formdata).subscribe(() => {
    this.router.navigate(["dashboard/book"])
  });
  }
  else {
    if(this.authorsChecked.length<1) {
    this.authorSelected = false;}
  }

}
handleApiDataForm(){
  this.formgroup = new FormGroup({
    'title' :new FormControl(null,[Validators.required,Validators.minLength(2)]),
    'ISPN' : new FormControl(null,[Validators.required]),
    'description' :new FormControl(null,[Validators.required,Validators.minLength(4)]),
    'price': new FormControl(null,[Validators.required,Validators.min(0)]),
    'inStock' : new FormControl(null,[Validators.required,Validators.min(0)]),
    'numOfSales': new FormControl(0,[Validators.required,Validators.min(0)]),
    'isactive': new FormControl(true),
    'categories': new FormControl("",Validators.required)
  })
}
}
