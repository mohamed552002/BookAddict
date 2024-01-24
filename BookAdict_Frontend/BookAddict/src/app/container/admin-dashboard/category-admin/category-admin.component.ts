import { Component, OnChanges, OnInit } from '@angular/core';
import { faPenToSquare, faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';
import { CategoryApisService } from '../../../server/CategoryApis/CategotyApis.service';

@Component({
  selector: 'app-category-dashboard',
  templateUrl: './category-admin.component.html',
  styleUrl: './category-admin.component.css'
})
export class CategoryAdminComponent implements OnInit , OnChanges {
  faPlus = faPlus;
  faPenToSquare = faPenToSquare;
  faTrash = faTrash;
  dataLoaded = false
  constructor(private categoryApi:CategoryApisService) {}
  categories:any[] = [];
  ngOnInit(){
    this.categoryApi.getAllCategories().subscribe((data) => {this.categories = data
    this.dataLoaded = true
    })
  }
  ngOnChanges(){
    this.categoryApi.getAllCategories().subscribe((data) => {this.categories = data
      this.dataLoaded = true
      })
  }
  deleteCategory(category){
    const categoryIdIndex = this.categories.indexOf(category)
    console.log(categoryIdIndex)
    this.categories.splice(categoryIdIndex,1)
    this.categoryApi.deleteCategory(category.id).subscribe();
  }
}

