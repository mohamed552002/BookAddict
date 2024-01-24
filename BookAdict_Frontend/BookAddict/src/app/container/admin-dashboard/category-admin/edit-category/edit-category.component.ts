import { Component, DoCheck, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, NavigationExtras, Params,Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from '../../../../Models/Category';
import { CategoryApisService } from '../../../../server/CategoryApis/CategotyApis.service';


@Component({
  selector: 'edit-category',
  templateUrl: './edit-category.component.html',
  styleUrl: './edit-category.component.css'
})
export class EditCategoryComponent implements OnInit , DoCheck , OnDestroy{
  category:any = "";
  categoryId = 0;
  formGroup:FormGroup;
  routeSubscription:Subscription;
  isLoaded:boolean = false;
  constructor(private route:ActivatedRoute, private categoryAPI:CategoryApisService , private router:Router){}
ngOnInit(){
  this.routeSubscription = this.route.params.subscribe((params:Params) => {
    this.categoryId = params["id"];
  })

  this.categoryAPI.getCategory(this.categoryId).subscribe((data)=>{
    this.category = data;
    console.log(data);
    this.isLoaded = true;
    this.handleForm()
  });

}
ngDoCheck(){

}

onFormSubmit(){
  console.log(this.formGroup);
  if(this.formGroup.valid){
    this.category = new Category(this.formGroup.get('name').value,this.formGroup.get('isactive').value,this.formGroup.get('description').value,this.categoryId);
    this.categoryAPI.updateCategory(this.category).subscribe(() => {
      this.router.navigate(["dashboard/category"])
      this.isLoaded = false
    })

  }
  }
  handleForm(){
    this.formGroup = new FormGroup({
      'name' :new FormControl(this.category?.name,[Validators.required,Validators.minLength(2)]),
      'description' :new FormControl(this.category?.description,[Validators.required,Validators.minLength(4)]),
      'isactive': new FormControl(this.category?.isActive)
    })
  }
ngOnDestroy(){
  this.routeSubscription.unsubscribe()
}
}
