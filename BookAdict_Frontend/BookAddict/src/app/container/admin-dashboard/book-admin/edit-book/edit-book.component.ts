import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { AuthorApiService } from '../../../../server/AuthorApis/AuthorApi.service';
import { CategoryApisService } from '../../../../server/CategoryApis/CategotyApis.service';
import { BookApis } from '../../../../server/BookApis.service';
import { serialize } from 'object-to-formdata';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrl: './edit-book.component.css'
})
export class EditBookComponent implements OnInit , OnDestroy {
  authors: any[] = []
  authorsChecked:number[] = [];
  formgroup:FormGroup;
  imgFile:File;
  faPlus = faPlus;
  book:any;
  bookId:number = 0;
  categories:any[] = [];
  formData:FormData = new FormData();
  authorSelected:boolean = true;
  bageLoaded:object = {
    "isCategoryLoaded" : false,
    "isAuthorLoaded" : false,
    "isBookLoaded" : false
  }
  url:any = "";
  routeSubscription:Subscription
constructor(private authorApis:AuthorApiService,
  private categoryApis:CategoryApisService,
  private bookApis:BookApis,
  private route:ActivatedRoute,
  private router:Router){}

  ngOnInit(){
    this.routeSubscription = this.route.params.subscribe((params:Params) => this.bookId = params["id"])
    this.authorApis.getAllAuthors().subscribe((data) => {
      this.authors = data
      this.bageLoaded["isAuthorLoaded"] = true;
    })
    this.categoryApis.getAllCategories().subscribe((data) => {
      this.categories = data
      this.bageLoaded["isCategoryLoaded"] = true;
    })
    this.bookApis.GetBook(this.bookId).subscribe(data => {
      this.bageLoaded["isBookLoaded"] = true
      this.book = data
      this.handleApiDataForm();
      this.url = "https://localhost:7153/" + data.imageUrl;
      this.GetBookAuthors();
    });

  }
  checked(author){
    if(!this.authorsChecked.includes(author.id)){
      this.authorsChecked.push(author.id)
    }
    else{
      const indexOfAuthor = this.authorsChecked.indexOf(author.id)
      this.authorsChecked.splice(indexOfAuthor,1)
    }

  }
  setImage(event:any){
    this.imgFile = event.target.files[0];
    this.formData.append("ImgFile",this.imgFile,this.imgFile.name);
    let reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);
    reader.onload = (_event) => this.url = reader.result;
  }
  submitForm(){
    if(this.formgroup.valid && this.authorsChecked.length>0){
    this.authorSelected = true;
    const requestData = {
      "id" : this.book.id,
      "Title" : this.formgroup.get("title").value,
      "ImgFile" : this.formData.get("ImgFile"),
      "ImgUrl" : this.book.imageUrl,
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
    this.bookApis.updateBook(formdata).subscribe(()=>{
      this.bageLoaded ={
        "isCategoryLoaded" : false,
        "isAuthorLoaded" : false,
        "isBookLoaded" : false
      }
      this.router.navigate(["dashboard/book"])
    });
    }
    else {
      if(this.authorsChecked.length<1) {
      this.authorSelected = false;}
    }
  }
  GetBookAuthors(){
    this.book.authors.forEach(a =>{
    if(!this.authorsChecked.includes(a.id))
      this.authorsChecked.push(a.id)
})}
  handleApiDataForm(){
    this.formgroup = new FormGroup({
      'title' :new FormControl(this.book.title,[Validators.required,Validators.minLength(2)]),
      'ISPN' : new FormControl(this.book.ispn,[Validators.required]),
      'description' :new FormControl(this.book.description,[Validators.required,Validators.minLength(4)]),
      'price': new FormControl(this.book.price,[Validators.required,Validators.min(0)]),
      'inStock' : new FormControl(this.book.availableInStock,[Validators.required,Validators.min(0)]),
      'numOfSales': new FormControl(this.book.numberOfSales,[Validators.required,Validators.min(0)]),
      'isactive': new FormControl(this.book.isActive),
      'categories': new FormControl(this.book.category.id,Validators.required)
    })
  }
  authorIncluded(author){
    if (!this.authorsChecked.includes(author.id))
      return false
    return true
  }
  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }
}
