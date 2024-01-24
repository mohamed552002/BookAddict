import { Component, OnInit } from '@angular/core';
import { FormControl,FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../../../../Models/Category';
import { CategoryApisService } from '../../../../server/CategoryApis/CategotyApis.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent implements OnInit {
formGroup:FormGroup;
category: Category;

constructor(private categoryAPI:CategoryApisService , private router:Router){

}

ngOnInit(){
  this.formGroup = new FormGroup({
    'name' :new FormControl(null,[Validators.required,Validators.minLength(2)]),
    'description' :new FormControl(null,[Validators.required,Validators.minLength(4)]),
    'isactive': new FormControl(true)
  })
}
onFormSubmit(){
console.log(this.formGroup);
if(this.formGroup.valid){
  this.category = new Category(this.formGroup.get('name').value,this.formGroup.get('isactive').value,this.formGroup.get('description').value);
  this.categoryAPI.postCategory(this.category).subscribe(data=>{
    this.router.navigate(["dashboard/category"])
  })
  this.formGroup.reset()
}
}
}
