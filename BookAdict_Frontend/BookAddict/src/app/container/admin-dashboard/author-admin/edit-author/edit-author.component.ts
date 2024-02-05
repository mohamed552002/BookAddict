import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { AuthorApiService } from '../../../../server/AuthorApis/AuthorApi.service';
import { ActivatedRoute,Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { error } from 'console';
import { stringify } from 'querystring';

@Component({
  selector: 'app-edit-author',
  templateUrl: './edit-author.component.html',
  styleUrl: './edit-author.component.css'
})
export class EditAuthorComponent implements OnInit,OnDestroy {
  formgroup:FormGroup;
  faPlus = faPlus;
  authorId:number = 0;
  author:any = ""
  routeSubscription:Subscription;
  url:any = "";
  isLoaded =false;
  isError = false
  formData:FormData = new FormData();
  file:File;
  constructor(private authorApi:AuthorApiService , private route:ActivatedRoute, private router:Router) {}
  ngOnInit(){
    this.routeSubscription = this.route.params.subscribe((params:Params) => {
      this.authorId = params["id"];
    })

    this.authorApi.getAuthor(this.authorId).subscribe((data)=>{
      this.author = data;
      this.url = this.authorApi.localhost + data.imageUrl
      this.initializeForm();
      this.isLoaded = true;
    })
    console.log()
  }
  submitForm(){
    if(this.formgroup.valid){
    this.formData.append('id',this.author.id)
    this.formData.append('Name',this.formgroup.get('name').value)
    this.formData.append('biography',this.formgroup.get('biography').value)
    this.formData.append('imageUrl',this.author.imageUrl)
    this.authorApi.updateAuthor(this.formData).subscribe(() => {
      this.router.navigate(["dashboard/authors"])
      this.isLoaded = false
      this.formgroup.reset();
    })
    }
}
setImage(event:any){
  this.file = event.target.files[0]
  this.formData.append('Imagefile',this.file,this.file.name)
  let reader = new FileReader();
  reader.readAsDataURL(this.file);
  reader.onload = (_event) => this.url =reader.result;
  }
  initializeForm(){
    this.formgroup = new FormGroup({
      'name' : new FormControl(this.author?.name,[Validators.required,Validators.minLength(2)]),
      'biography' : new FormControl(this.author?.biography,[Validators.required,Validators.minLength(4)]),
      'imageUrl' : new FormControl()
    })
  }
  removeImg(){
    this.url = "";
  }
  ngOnDestroy(){
    this.routeSubscription.unsubscribe()
  }
}
