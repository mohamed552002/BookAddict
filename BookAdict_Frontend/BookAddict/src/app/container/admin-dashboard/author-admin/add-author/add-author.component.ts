import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { AuthorApiService } from '../../../../server/AuthorApis/AuthorApi.service';
import { Author } from '../../../../Models/Author';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-add-author',
  templateUrl: './add-author.component.html',
  styleUrl: './add-author.component.css'
})
export class AddAuthorComponent implements OnInit {
  faPlus = faPlus;
  url:any = ""
  formgroup:FormGroup;
  formData:FormData = new FormData();
  file:File;
  isLoading:boolean = false
  constructor(private authorApi:AuthorApiService , private router : Router) {}
  ngOnInit(){
    this.formgroup = new FormGroup({
      'name' : new FormControl(null,[Validators.required,Validators.minLength(2)]),
      'biography' : new FormControl(null,[Validators.required,Validators.minLength(4)]),
      'imageUrl' : new FormControl(null)
    })
  }
  setImage(event:any){
    this.file = event.target.files[0]
    this.formData.append('Imagefile',this.file,this.file.name)
    let reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = (_event) => this.url =reader.result;
    }
    submitForm(){
      if(this.formgroup.valid){
      this.formData.append('Name',this.formgroup.get('name').value)
      this.formData.append('biography',this.formgroup.get('biography').value)
      this.authorApi.postAuthor(this.formData).subscribe(() => {
        this.isLoading = true
        this.router.navigate(["dashboard/authors"])
      })
      this.formgroup.reset();
      }
  }
}
